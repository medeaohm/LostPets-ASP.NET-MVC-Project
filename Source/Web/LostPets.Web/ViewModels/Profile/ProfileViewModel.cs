namespace LostPets.Web.ViewModels.Profile
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;

    public class ProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [StringLength(30)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "City")]
        public City HomeCity { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        [Display(Name = "Facebook Profile")]
        public string FacebookProfile { get; set; }

        public int? ProfilePictureId { get; set; }

        public int? NumberOfPosts { get; set; }

        public int? NumberOfComments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, ProfileViewModel>()
                .ForMember(x => x.NumberOfComments, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.NumberOfPosts, opt => opt.MapFrom(x => x.Posts.Count));
        }
    }
}
