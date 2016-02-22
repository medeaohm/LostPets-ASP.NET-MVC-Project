namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Common.Repositories;
    using LostPets.Data.Models;

    public class UserService : IUserService
    {
        private IDeletableEntityRepository<User> users;

        public UserService(IDeletableEntityRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(object id)
        {
            return this.users.GetById(id);
        }

        public void Update()
        {
            this.users.SaveChanges();
        }

        public void Delete(string id)
        {
            this.users.Delete(this.users.GetById(id));
        }
    }
}
