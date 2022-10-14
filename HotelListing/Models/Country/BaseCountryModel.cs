using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models.Country
{
    public abstract class BaseCountryModel
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
