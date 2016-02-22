namespace LostPets.Web.ViewModels.Account
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;

    public class RegisterViewModel : IMapFrom<User>
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [UIHint("RegisterSingleLineText")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name = "Username")]
        [UIHint("RegisterSingleLineText")]
        public string UserName { get; set; }

        [StringLength(30)]
        [Display(Name = "First name")]
        [UIHint("RegisterSingleLineText")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last name")]
        [UIHint("RegisterSingleLineText")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        [DefaultValue(Gender.NotGiven)]
        public Gender Gender { get; set; }

        [Display(Name = "City")]
        [DefaultValue(City.NotGiven)]
        public City HomeCity { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be exactly 10 digits. ")]
        [Display(Name = "Phone Number")]
        [UIHint("RegisterSingleLineText")]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        [Display(Name = "Facebook Profile")]
        [UIHint("RegisterSingleLineText")]
        public string FacebookProfile { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [UIHint("RegisterPassword")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [UIHint("RegisterPassword")]
        public string ConfirmPassword { get; set; }
    }
}
