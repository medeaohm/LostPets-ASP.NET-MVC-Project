namespace LostPets.Web.Areas.Administration.ViewModels.AdminUsers
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class AdminUserViewModel : IMapFrom<User>
    {
        public string Id { get; set;  }

        public string UserName { get; set; }

        public string Email { get; set; }

        public Photo ProfilePicture { get; set; }
    }
}
