using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.Models;

namespace AndreTurismoAPI.PassagemService.Data
{
    public class AndreTurismoAPIPassagemServiceContext : DbContext
    {
        public AndreTurismoAPIPassagemServiceContext (DbContextOptions<AndreTurismoAPIPassagemServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAPI.Models.Passagem> Passagem { get; set; } = default!;
    }
}
