using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.Models;

namespace AndreTurismoAPI.HotelService.Data
{
    public class AndreTurismoAPIHotelServiceContext : DbContext
    {
        public AndreTurismoAPIHotelServiceContext (DbContextOptions<AndreTurismoAPIHotelServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoAPI.Models.Hotel> Hotel { get; set; } = default!;
    }
}
