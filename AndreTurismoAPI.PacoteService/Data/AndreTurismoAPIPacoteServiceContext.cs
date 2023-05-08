using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.Models;
using System.Reflection.Metadata;

namespace AndreTurismoAPI.PacoteService.Data
{
    public class AndreTurismoAPIPacoteServiceContext : DbContext
    {
        public AndreTurismoAPIPacoteServiceContext (DbContextOptions<AndreTurismoAPIPacoteServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAPI.Models.Pacote> Pacote { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Passagem>()
                        .HasOne(c => c.Origem)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Passagem>()
                       .HasOne(c => c.Destino)
                       .WithMany()
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Passagem>()
                      .HasOne(c => c.Cliente)
                      .WithMany()
                      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pacote>()
                      .HasOne(c => c.Hotel)
                      .WithMany()
                      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pacote>()
                      .HasOne(c => c.Passagem)
                      .WithMany()
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
