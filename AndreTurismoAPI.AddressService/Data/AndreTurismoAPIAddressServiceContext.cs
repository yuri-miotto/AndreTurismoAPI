using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.Models;

namespace AndreTurismoAPI.AddressService.Data
{
    public class AndreTurismoAPIAddressServiceContext : DbContext
    {
        public AndreTurismoAPIAddressServiceContext (DbContextOptions<AndreTurismoAPIAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAPI.Models.Cidade> Cidade { get; set; } = default;

        public DbSet<AndreTurismoAPI.Models.Endereco>? Endereco { get; set; }

        public DbSet<AndreTurismoAPI.Models.Cliente>? Cliente { get; set; } 
    }
}
