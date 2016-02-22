namespace LostPets.Web.Areas.Administration.ViewModels.AdminComments
{
    using System.Collections.Generic;

    public class AdminPageableListCommentViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AdminCommentViewModel> Comments { get; set; }
    }
}
