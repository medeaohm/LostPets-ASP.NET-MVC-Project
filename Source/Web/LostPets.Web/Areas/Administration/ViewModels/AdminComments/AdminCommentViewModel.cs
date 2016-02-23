namespace LostPets.Web.Areas.Administration.ViewModels.AdminComments
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class AdminCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set;  }

        public string Content { get; set; }

        public User Author { get; set; }

        public Post Post { get; set; }

        public string PostUrl
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Posts/Details/{identifier.EncodeId(this.Post.Id)}";
            }
        }

        public string UserUrl
        {
            get
            {
                return $"/Profile/ViewUserProfile/{this.Author.Id}";
            }
        }
    }
}
