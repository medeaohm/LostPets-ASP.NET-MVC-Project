namespace LostPets.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.AdminComments;

    public class AdminCommentsController : AdminController
    {
        private const int ItemsPerPage = 4;

        private ICommentService comments;

        public AdminCommentsController(
            IPostService posts,
            IImageService images,
            IUserService users,
            IPetService pets,
            ILocationService locations,
            ICommentService comments)
            : base(posts, images, users, pets, locations)
        {
            this.comments = comments;
        }

        [Authorize]
        [HttpGet]
        public ActionResult All(int id = 1)
        {
            AdminPageableListCommentViewModel viewModel;
            var page = id;
            var allItemsCount = this.comments.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var queryComments = this.comments
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage);

            var comments = queryComments.To<AdminCommentViewModel>().ToList();

            viewModel = new AdminPageableListCommentViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Comments = comments
            };

            return this.View(viewModel);
        }

        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.comments.GetById(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<AdminEditCommentViewModel>(comment);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(AdminEditCommentViewModel comment, int id)
        {
            var databaseComment = this.comments.GetById(id);
            databaseComment.Content = comment.Content;

            this.comments.Update();

            this.TempData["Notification"] = "Comment Edited Succesfully!";
            return this.RedirectToAction("All");
        }

        [Authorize]
        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = this.comments.GetById(id);
            if (comment == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = this.Mapper.Map<AdminCommentViewModel>(comment);
            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.comments.Delete(id);
            this.comments.Update();
            this.TempData["Notification"] = "Comment Deleted Succesfully!";
            return this.RedirectToAction("All");
        }
    }
}
