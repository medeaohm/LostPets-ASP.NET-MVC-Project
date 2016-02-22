namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Models;
    using LostPets.Data.Models.Types;

    public interface ILocationService
    {
        Location GetById(string id);

        Location GetById(int id);

        IQueryable<Location> GetAll();

        IQueryable<Location> GetByCity(City city);

        void Update();

        void Add(Location location);
    }
}
