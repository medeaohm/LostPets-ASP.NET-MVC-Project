namespace LostPets.Web.Areas.Administration.ViewModels.AdminPosts
{
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;
    using Services.Web;

    public class AdminPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set;  }

        public string Title { get; set; }

        public string Content { get; set; }

        public Photo Photo { get; set; }

        public PostType PostType { get; set; }

        public Pet Pet { get; set; }

        public User Author { get; set; }

        public Location Location { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Posts/Details/{identifier.EncodeId(this.Id)}";
            }
        }

        public string UserUrl
        {
            get
            {
                return $"/Profile/ViewUserProfile/{this.Author.Id}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<AdminPostViewModel, Location>()
                .ReverseMap();
            configuration.CreateMap<Pet, AdminPostViewModel>()
                .ReverseMap();
            configuration.CreateMap<User, AdminPostViewModel>()
                .ReverseMap();
            configuration.CreateMap<Post, AdminPostViewModel>()
                .ForMember(x => x.Photo, opt => opt.MapFrom(x => x.Gallery.OrderBy(f => f.Id).FirstOrDefault()))
                .ReverseMap();
        }
    }
}
