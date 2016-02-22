namespace LostPets.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Comments;
    using ViewModels.Posts;

    public class HomeController : BaseController
    {
        private readonly IPostService posts;

        public HomeController(IUserService users, IPostService posts)
            : base(users)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            var posts =
                this.Cache.Get(
                    "posts",
                    () => this.posts.GetMostRecent(4).To<PostViewModel>().ToList(),
                    10 * 60);

            var viewModel = new ListPostViewModel
            {
                Posts = posts
            };

            return this.View(viewModel);
        }
    }
}
