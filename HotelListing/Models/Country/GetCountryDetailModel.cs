using HotelListing.Models.Hotel;

namespace HotelListing.Models.Country
{
    public class GetCountryDetailModel : BaseCountryModel
    {
        public int Id { get; set; }
        public List<GetHotelModel> Hotels { get; set; }
    }
}
