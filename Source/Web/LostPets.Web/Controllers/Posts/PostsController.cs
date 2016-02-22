namespace LostPets.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Data.Models.Types;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Posts;

    public class PostsController : BaseController
    {
        private const int ItemsPerPage = 4;

        private IPostService posts;
        private IImageService images;
        private IPetService pets;
        private ILocationService locations;

        public PostsController(
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

        public ActionResult Details(string id)
        {
            var post = this.posts.GetById(id);
            var viewModel = this.Mapper.Map<PostViewModel>(post);
            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Add()
        {
            var addPostViewModel = new AddPostViewModel();

            return this.View(addPostViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddPostViewModel post)
        {
            if (post != null && this.ModelState.IsValid)
            {
                var pet = new Pet
                {
                    PetType = post.AnimalType,
                    Name = post.PetName,
                    Age = post.PetAge,
                    Color = post.PetColor,
                    Description = post.PetDescription,
                };
                this.pets.Add(pet);
                this.pets.Update();

                var location = new Location
                {
                    City = post.LocationCity,
                    Street = post.LocationStreet,
                    AdditionalInfo = post.LocationAdditionalInfo
                };
                this.locations.Add(location);
                this.locations.Update();

                var databasePost = new Post
                {
                    PostType = post.PostType,
                    Title = post.Title,
                    Content = post.Content,
                    LocationId = location.Id,
                    PetId = pet.Id,
                    AuthorId = this.CurrentUser.Id
                };

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
                        this.images.Add(image);
                        this.images.Update();
                        databasePost.Gallery.Add(image);
                    }
                }

                this.posts.Add(databasePost);
                this.posts.Update();

                this.TempData["Notification"] = "Post Added Succesfully!";
                return this.RedirectToAction("All", "Posts");
            }

            return this.View(post);
        }

        [HttpGet]
        public ActionResult All(PostType? postType = null, PetType? petType = null, City? city = null, int id = 1)
        {
            PageableListPostViewModel viewModel;
            if (this.HttpContext.Cache["Post page_" + id] != null)
            {
                viewModel = (PageableListPostViewModel)this.HttpContext.Cache["Post page_" + id];
            }
            else
            {
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

                var posts = queryPosts.To<PostViewModel>().ToList();

                viewModel = new PageableListPostViewModel()
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    Posts = posts
                };

                this.HttpContext.Cache["Post page_" + id] = viewModel;
            }

            return this.View(viewModel);
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
