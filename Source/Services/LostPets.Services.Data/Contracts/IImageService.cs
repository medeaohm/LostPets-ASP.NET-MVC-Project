namespace LostPets.Services.Data
{
    using LostPets.Data.Models;

    public interface IImageService
    {
        Photo GetById(int id);

        void Update();

        void Add(Photo image);
    }
}
