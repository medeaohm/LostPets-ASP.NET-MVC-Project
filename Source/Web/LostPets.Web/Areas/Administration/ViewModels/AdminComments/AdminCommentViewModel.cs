namespace LostPets.Web.Areas.Administration.ViewModels.AdminComments
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set;  }

        public string Content { get; set; }

        public User Author { get; set; }

        public Post Post { get; set; }
    }
}
