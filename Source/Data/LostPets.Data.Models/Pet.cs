namespace LostPets.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Types;

    public class Pet : BaseModel<int>
    {
        [Required]
        [DefaultValue(PetType.NotGiven)]
        public PetType PetType { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Age { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Color { get; set; }
    }
}
