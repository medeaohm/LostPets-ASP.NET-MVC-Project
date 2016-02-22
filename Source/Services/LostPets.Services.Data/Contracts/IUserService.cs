namespace LostPets.Services.Data
{
    using System.Linq;
    using LostPets.Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(object id);

        void Update();

        void Delete(string id);
    }
}
