namespace LostPets.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Models.Types;

    public class PageableListPostViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        [Display(Name = "Post Type")]
        public PostType? PostType { get; set; }

        [Display(Name = "Pet Type")]
        public PetType? PetType { get; set; }

        [Display(Name = "City")]
        public City? City { get; set; }

        [Display(Name = "Order By")]
        public string OrderBy { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
