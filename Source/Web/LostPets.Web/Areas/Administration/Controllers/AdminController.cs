namespace LostPets.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;
    using Services.Data;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        private IPostService posts;
        private IImageService images;
        private IPetService pets;
        private ILocationService locations;

        public AdminController(
            IPostService posts,
            IImageService images,
            IUserService users,
            IPetService pets,
            ILocationService locations)
            : base(users)
        {
            this.posts = posts;
            this.images = images;
            this.pets = pets;
            this.locations = locations;
        }
    }
}
