namespace LostPets.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Data.Common.Models;
    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;

    public class EditPostViewModel : BaseModel<int>, IMapFrom<Post>
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Content too long")]
        [UIHint("MultiLineText")]
        public string Content { get; set; }

        [Display(Name = "Post Type")]
        public PostType PostType { get; set; }

        [Display(Name = "Animal Type")]
        public PetType AnimalType { get; set; }

        public User Author { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}
