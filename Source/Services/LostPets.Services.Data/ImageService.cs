namespace LostPets.Services.Data
{
    using LostPets.Data.Common.Repositories;
    using LostPets.Data.Models;
    using Web;

    public class ImageService : IImageService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDeletableEntityRepository<Photo> images;

        public ImageService(IDeletableEntityRepository<Photo> images, IIdentifierProvider identifierProvider)
        {
            this.images = images;
            this.identifierProvider = identifierProvider;
        }

        public Photo GetById(int id)
        {
            return this.images.GetById(id);
        }

        public void Update()
        {
            this.images.SaveChanges();
        }

        public void Add(Photo image)
        {
            this.images.Add(image);
        }
    }
}
