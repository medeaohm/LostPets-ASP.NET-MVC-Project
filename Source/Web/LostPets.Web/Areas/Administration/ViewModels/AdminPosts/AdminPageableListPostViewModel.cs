namespace LostPets.Web.Areas.Administration.ViewModels.AdminPosts
{
    using System.Collections.Generic;

    using Data.Models.Types;

    public class AdminPageableListPostViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public PostType? PostType { get; set; }

        public PetType? PetType { get; set; }

        public City? City { get; set; }

        public IEnumerable<AdminPostViewModel> Posts { get; set; }
    }
}
