namespace LostPets.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using AutoMapper;
    using Data.Common.Models;
    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;

    public class AddPostViewModel : BaseModel<int>, IMapFrom<Post>, IHaveCustomMappings
    {
        [Required]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [Display(Name = "Post Type")]
        public PostType PostType { get; set; }

        [Display(Name = "Animal Type")]
        public PetType AnimalType { get; set; }

        public User Author { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Pet Name")]
        public string PetName { get; set; }

        [UIHint("Integer")]
        [Display(Name = "Pet Age")]
        public int? PetAge { get; set; }

        [UIHint("MultiLineText")]
        [Display(Name = "Pet Description")]
        public string PetDescription { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Pet Color")]
        public string PetColor { get; set; }

        [Display(Name = "City")]
        public City LocationCity { get; set; }

        [UIHint("SingleLineText")]
        [Display(Name = "Street")]
        public string LocationStreet { get; set; }

        [UIHint("MultiLineText")]
        [Display(Name = "Additional Information")]
        public string LocationAdditionalInfo { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, AddPostViewModel>()
                .ForMember(x => x.PostType, opt => opt.MapFrom(x => x.PostType))
                .ForMember(x => x.AnimalType, opt => opt.MapFrom(x => x.Pet.PetType.ToString()))
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(x => x.PetName, opt => opt.MapFrom(x => x.Pet.Name))
                .ForMember(x => x.PetAge, opt => opt.MapFrom(x => x.Pet.Age))
                .ForMember(x => x.PetDescription, opt => opt.MapFrom(x => x.Pet.Description))
                .ForMember(x => x.PetColor, opt => opt.MapFrom(x => x.Pet.Color))
                .ForMember(x => x.LocationCity, opt => opt.MapFrom(x => x.Location.City.ToString()))
                .ForMember(x => x.LocationStreet, opt => opt.MapFrom(x => x.Location.Street))
                .ForMember(x => x.LocationAdditionalInfo, opt => opt.MapFrom(x => x.Location.AdditionalInfo))
                .ReverseMap();
        }
    }
}
