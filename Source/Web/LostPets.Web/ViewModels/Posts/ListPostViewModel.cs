namespace LostPets.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class ListPostViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
