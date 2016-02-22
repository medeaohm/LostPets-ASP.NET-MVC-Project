namespace LostPets.Web.Controllers
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
    using ViewModels.Posts;

    public class UserPostsController : BaseController
    {
        private const int ItemsPerPage = 4;

        private IPostService posts;
        private IImageService images;
        private IPetService pets;
        private ILocationService locations;

        public UserPostsController(
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

        [Authorize]
        [HttpGet]
        public ActionResult AllByUser(PostType? postType = null, PetType? petType = null, City? city = null, int id = 1)
        {
            PageableListPostViewModel viewModel;
            var page = id;
            var allItemsCount = this.posts.GetByUserId(this.CurrentUser.Id).Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var queryPosts = this.posts.GetByUserId(this.CurrentUser.Id);

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

            var posts = queryPosts.To<PostViewModel>().ToList();

            viewModel = new PageableListPostViewModel()
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

            var viewModel = this.Mapper.Map<EditPostViewModel>(post);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(EditPostViewModel post, int id)
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
            return this.RedirectToAction("AllByUser");
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

            var viewModel = this.Mapper.Map<PostViewModel>(post);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.posts.Delete(id);
            this.posts.Update();
            this.TempData["Notification"] = "Post Deleted Succesfully!";
            return this.RedirectToAction("AllByUser");
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
