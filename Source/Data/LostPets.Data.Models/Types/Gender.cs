namespace LostPets.Data.Models.Types
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "Not Given")]
        NotGiven = 0,
        Female = 1,
        Male = 2
    }
}
