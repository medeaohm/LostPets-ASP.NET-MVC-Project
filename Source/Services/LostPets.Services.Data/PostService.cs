namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Common.Repositories;
    using LostPets.Data.Models;
    using LostPets.Data.Models.Types;
    using Web;

    public class PostService : IPostService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDeletableEntityRepository<Post> posts;

        public PostService(IDeletableEntityRepository<Post> posts, IIdentifierProvider identifierProvider)
        {
            this.posts = posts;
            this.identifierProvider = identifierProvider;
        }

        public Post GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var post = this.posts.GetById(intId);
            return post;
        }

        public Post GetById(int? id)
        {
            return this.posts.GetById(id);
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts.All().OrderByDescending(p => p.CreatedOn);
        }

        public IQueryable<Post> GetMostRecent(int count)
        {
            return this.posts.All().OrderByDescending(p => p.CreatedOn).Take(count);
        }

        public IQueryable<Post> GetByUserId(string userId)
        {
            return this.posts.All().Where(p => p.AuthorId == userId);
        }

        public IQueryable<Post> GetByType(PostType postType)
        {
            return this.posts.All().Where(p => p.PostType == postType);
        }

        public IQueryable<Post> GetByAnimalType(PetType animalType)
        {
            return this.posts.All().Where(p => p.Pet.PetType == animalType);
        }

        public void Update()
        {
            this.posts.SaveChanges();
        }

        public void Add(Post post)
        {
            this.posts.Add(post);
        }

        public void Delete(int id)
        {
            var post = this.posts.GetById(id);
            post.Pet.IsDeleted = true;
            post.Location.IsDeleted = true;

            foreach (var comment in post.Comments)
            {
                comment.IsDeleted = true;
            }

            foreach (var image in post.Gallery)
            {
                image.IsDeleted = true;
            }

            post.IsDeleted = true;
        }
    }
}
