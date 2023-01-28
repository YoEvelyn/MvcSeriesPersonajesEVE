using Microsoft.EntityFrameworkCore;
using MvcSeriesPersonajesEVE.Models;

namespace MvcSeriesPersonajesEVE.Data
{
    public class SeriesContext: DbContext
    {
        public SeriesContext
            (DbContextOptions<SeriesContext> options) : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
