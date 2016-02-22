namespace LostPets.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Types;

    public class Location : BaseModel<int>
    {
        [Required]
        [DefaultValue(City.NotGiven)]
        public City City { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(300)]
        public string AdditionalInfo { get; set; }
    }
}
