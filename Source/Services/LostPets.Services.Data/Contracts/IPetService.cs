namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Models;

    public interface IPetService
    {
        Pet GetById(string id);

        Pet GetById(int id);

        IQueryable<Pet> GetAll();

        void Update();

        void Add(Pet pet);
    }
}
