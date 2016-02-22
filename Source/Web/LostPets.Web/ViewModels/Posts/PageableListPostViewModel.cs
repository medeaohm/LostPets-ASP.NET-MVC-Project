namespace LostPets.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Data.Models.Types;

    public class PageableListPostViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public PostType? PostType { get; set; }

        public PetType? PetType { get; set; }

        public City? City { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
