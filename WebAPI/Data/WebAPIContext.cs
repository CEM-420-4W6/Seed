using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : IdentityDbContext<DemoUser>
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var hasher = new PasswordHasher<DemoUser>();
            DemoUser u1 = new DemoUser
            {
                // Primary key au format GUID
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "jim@test.com",
                Email = "jim@test.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "JIM@TEST.COM",
                NormalizedUserName = "JIM@TEST.COM"
            };
            // On encrypte le mot de passe
            u1.PasswordHash = hasher.HashPassword(u1, "Passw0rd!");
            builder.Entity<DemoUser>().HasData(u1);

            var c1 = new
            {
                Id = 1,
                Name = "Dali",
                DemoUserId = "11111111-1111-1111-1111-111111111111"
            };

            var c2 = new
            {
                Id = 2,
                Name = "Linda",
                DemoUserId = "11111111-1111-1111-1111-111111111111"
            };

            builder.Entity<Cat>().HasData(c1, c2);


            var m1 = new
            {
                Id = 1,
                Address = "123 Whatever st."
            };

            builder.Entity<House>().HasData(m1);

            builder.Entity<House>()
                .HasMany(house => house.Cats)
                .WithMany(cat => cat.Houses)
                .UsingEntity(cathouse =>
                {
                    cathouse.HasData(new { CatsId = 1, HousesId =1 });
                    cathouse.HasData(new { CatsId = 2, HousesId = 1 });
                });
        }

        public DbSet<Cat> Cats { get; set; } = default!;
        public DbSet<House> Houses { get; set; } = default!;
    }
}
