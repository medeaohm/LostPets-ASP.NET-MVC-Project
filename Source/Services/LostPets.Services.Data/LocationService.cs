namespace LostPets.Services.Data
{
    using System.Linq;

    using LostPets.Data.Common.Repositories;
    using LostPets.Data.Models;
    using LostPets.Data.Models.Types;
    using Web;

    public class LocationService : ILocationService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDeletableEntityRepository<Location> locations;

        public LocationService(IDeletableEntityRepository<Location> locations, IIdentifierProvider identifierProvider)
        {
            this.locations = locations;
            this.identifierProvider = identifierProvider;
        }

        public Location GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var location = this.locations.GetById(intId);
            return location;
        }

        public Location GetById(int id)
        {
            var location = this.locations.GetById(id);
            return location;
        }

        public IQueryable<Location> GetAll()
        {
            return this.locations.All().OrderByDescending(p => p.CreatedOn);
        }

        public IQueryable<Location> GetByCity(City city)
        {
            return this.locations.All().Where(l => l.City == city);
        }

        public void Update()
        {
            this.locations.SaveChanges();
        }

        public void Add(Location location)
        {
            this.locations.Add(location);
        }
    }
}
