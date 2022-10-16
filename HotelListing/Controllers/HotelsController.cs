using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using AutoMapper;
using HotelListing.Models.Hotel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using HotelListing.Repository;
using HotelListing.Contract;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            this._hotelRepository = hotelRepository;
            this._mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelModel>>> GetHotels()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHotelModel>>(hotels);

            return Ok(records);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetHotelModel>> GetHotel(int id)
        {
            var hotel = await _hotelRepository.GetAsync(id);

            if (hotel is null)
            {
                return NotFound();
            }

            var hotelModel = _mapper.Map<GetHotelModel>(hotel);

            return hotelModel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelModel hotelModel)
        {
            if (id != hotelModel.Id)
            {
                return BadRequest();
            }

            var hotel = await _hotelRepository.GetAsync(id);

            if (hotel is null)
            {
                return BadRequest();
            }

            //_context.Entry(hotel).State = EntityState.Modified;
            _mapper.Map(hotelModel, hotel);

            try
            {
                await _hotelRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelModel hotelModel)
        {
            var hotel = _mapper.Map<Hotel>(hotelModel);

            await _hotelRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelRepository.DeleteAsync(id);

            if (hotel is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelRepository.Exists(id);
        }
    }
}
