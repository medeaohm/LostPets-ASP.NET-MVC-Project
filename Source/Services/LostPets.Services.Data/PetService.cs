namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Common.Repositories;
    using LostPets.Data.Models;
    using Web;

    public class PetService : IPetService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDeletableEntityRepository<Pet> pets;

        public PetService(IDeletableEntityRepository<Pet> pets, IIdentifierProvider identifierProvider)
        {
            this.pets = pets;
            this.identifierProvider = identifierProvider;
        }

        public Pet GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var pet = this.pets.GetById(intId);
            return pet;
        }

        public Pet GetById(int id)
        {
            var pet = this.pets.GetById(id);
            return pet;
        }

        public IQueryable<Pet> GetAll()
        {
            return this.pets.All().OrderByDescending(p => p.CreatedOn);
        }

        public void Update()
        {
            this.pets.SaveChanges();
        }

        public void Add(Pet pet)
        {
            this.pets.Add(pet);
        }
    }
}
