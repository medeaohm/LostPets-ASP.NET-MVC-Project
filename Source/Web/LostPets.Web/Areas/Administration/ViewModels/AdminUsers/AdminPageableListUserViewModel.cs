namespace LostPets.Web.Areas.Administration.ViewModels.AdminUsers
{
    using System.Collections.Generic;

    public class AdminPageableListUserViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AdminUserViewModel> Users { get; set; }
    }
}
