using AutoMapper;
using HotelListing.Data;
using HotelListing.Models.Country;
using HotelListing.Models.Hotel;

namespace HotelListing.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Country Mappers
            CreateMap<Country, CreateCountryModel>().ReverseMap();
            CreateMap<Country, GetCountryModel>().ReverseMap();
            CreateMap<Country, GetCountryDetailModel>().ReverseMap();
            CreateMap<Country, UpdateCountryModel>().ReverseMap();

            // Hotel Mappers
            CreateMap<Hotel, GetHotelModel>().ReverseMap();
        }
    }
}
