namespace LostPets.Web.Areas.Administration.Controllers.Users
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.AdminUsers;

    public class AdminUsersController : AdminController
    {
        private const int ItemsPerPage = 15;

        private IPostService posts;
        private IImageService images;
        private IPetService pets;
        private ILocationService locations;

        public AdminUsersController(
            IPostService posts,
            IImageService images,
            IUserService users,
            IPetService pets,
            ILocationService locations)
            : base(posts, images, users, pets, locations)
        {
            this.posts = posts;
            this.images = images;
            this.pets = pets;
            this.locations = locations;
        }

        [Authorize]
        [HttpGet]
        public ActionResult All(int page = 1)
        {
            AdminPageableListUserViewModel viewModel;
            var allItemsCount = this.posts.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var queryUsers = this.users
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage);

            var users = queryUsers.To<AdminUserViewModel>().ToList();

            viewModel = new AdminPageableListUserViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Users = users
            };

            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult DeleteUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = this.users.GetById(id);
            if (user == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<AdminUserViewModel>(user);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            this.users.Delete(id);
            this.users.Update();
            this.TempData["Notification"] = "User Deleted Succesfully!";
            return this.RedirectToAction("All");
        }

        public ActionResult Image(int id)
        {
            var image = this.images.GetById(id);

            if (image == null)
            {
                return this.File(this.images.GetById(0).Content, "image/" + image.FileExtension);
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}
