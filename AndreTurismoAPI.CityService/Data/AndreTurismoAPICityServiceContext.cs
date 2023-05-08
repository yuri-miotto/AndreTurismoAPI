using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.Models;

namespace AndreTurismoAPI.CityService.Data
{
    public class AndreTurismoAPICityServiceContext : DbContext
    {
        public AndreTurismoAPICityServiceContext (DbContextOptions<AndreTurismoAPICityServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAPI.Models.Cidade> Cidade { get; set; } = default!;
    }
}
