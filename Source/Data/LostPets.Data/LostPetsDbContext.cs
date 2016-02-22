namespace LostPets.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class LostPetsDbContext : IdentityDbContext<User>
    {
        public LostPetsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Photo> Images { get; set; }

        public IDbSet<Pet> Pets { get; set; }

        public static LostPetsDbContext Create()
        {
            return new LostPetsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
