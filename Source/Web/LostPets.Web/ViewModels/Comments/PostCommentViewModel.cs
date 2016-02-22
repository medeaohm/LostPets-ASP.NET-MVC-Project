namespace LostPets.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public PostCommentViewModel()
        {
        }

        public PostCommentViewModel(int postId)
        {
            this.PostId = postId;
        }

        public int PostId
        {
            get; set;
        }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
        [UIHint("MultiLineText")]
        [Display(Name = "Comment")]
        public string Content
        {
            get; set;
        }
    }
}
