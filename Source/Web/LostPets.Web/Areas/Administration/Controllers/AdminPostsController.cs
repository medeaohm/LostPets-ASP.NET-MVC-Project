namespace LostPets.Web.Areas.Administration.Controllers.Posts
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.AdminPosts;

    public class AdminPostsController : AdminController
    {
        private const int ItemsPerPage = 4;

        private IPostService posts;
        private IImageService images;
        private IPetService pets;
        private ILocationService locations;

        public AdminPostsController(
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
        public ActionResult All(PostType? postType = null, PetType? petType = null, City? city = null, int id = 1)
        {
            AdminPageableListPostViewModel viewModel;
            var page = id;
            var allItemsCount = this.posts.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var queryPosts = this.posts.GetAll();

            if (postType != null)
            {
                queryPosts = queryPosts.Where(p => p.PostType == postType);
            }

            if (petType != null)
            {
                queryPosts = queryPosts.Where(p => p.Pet.PetType == petType);
            }

            if (city != null)
            {
                queryPosts = queryPosts.Where(p => p.Location.City == city);
            }

            queryPosts = queryPosts.OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage);

            var posts = queryPosts.To<AdminPostViewModel>().ToList();

            viewModel = new AdminPageableListPostViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Posts = posts
            };

            return this.View(viewModel);
        }

        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.posts.GetById(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<AdminEditPostViewModel>(post);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(AdminEditPostViewModel post, int id)
        {
            var databasePost = this.posts.GetById(id);
            databasePost.PostType = post.PostType;
            databasePost.Title = post.Title;
            databasePost.Content = post.Content;

            var pet = this.pets.GetById(post.PetId);
            pet.PetType = post.Pet.PetType;
            pet.Name = post.Pet.Name;
            pet.Age = post.Pet.Age;
            pet.Description = post.Pet.Description;
            pet.Color = post.Pet.Color;

            var location = this.locations.GetById(post.LocationId);
            location.City = post.Location.City;
            location.Street = post.Location.Street;
            location.AdditionalInfo = post.Location.AdditionalInfo;

            if (post.UploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    post.UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    var image = new Photo
                    {
                        Content = content,
                        FileExtension = post.UploadedImage.FileName.Split(new[] { '.' }).Last()
                    };
                    this.images.Update();
                    databasePost.Gallery.Add(image);
                }
            }

            this.pets.Update();
            this.locations.Update();
            this.posts.Update();

            this.TempData["Notification"] = "Post Edited Succesfully!";
            return this.RedirectToAction("All");
        }

        [Authorize]
        public ActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var post = this.posts.GetById(id);
            if (post == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<AdminPostViewModel>(post);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.posts.Delete(id);
            this.posts.Update();
            this.TempData["Notification"] = "Post Deleted Succesfully!";
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
