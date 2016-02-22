namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Models;
    using LostPets.Data.Models.Types;

    public interface IPostService
    {
        Post GetById(string id);

        Post GetById(int? id);

        IQueryable<Post> GetAll();

        IQueryable<Post> GetMostRecent(int count);

        IQueryable<Post> GetByUserId(string userId);

        IQueryable<Post> GetByType(PostType postType);

        IQueryable<Post> GetByAnimalType(PetType animalType);

        void Update();

        void Add(Post post);

        void Delete(int id);
    }
}
