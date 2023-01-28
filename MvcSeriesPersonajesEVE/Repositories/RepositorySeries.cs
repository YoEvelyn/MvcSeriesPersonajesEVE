using Microsoft.AspNetCore.Mvc;
using MvcSeriesPersonajesEVE.Data;
using MvcSeriesPersonajesEVE.Models;

namespace MvcSeriesPersonajesEVE.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        //METODO PARA RECUPERAR TODAS LAS SERIES
        public List<Serie> GetSeries()
        {
            var consulta = from datos in this.context.Series
                           select datos;
            return consulta.ToList();
        }

        //METODO PARA RECUPERAR DATOS DE UNA SERIE
        public Serie FindSerie(int id)
        {
            var consulta = from datos in this.context.Series
                           where datos.IdSerie == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        //METODO PARA RECUPERAR LOS PERSONAJES
        public Personaje FindPersonajes(int id)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        //METODO PARA AÑADIR NUEVA SERIE
        public void InsertarSerie(int id, string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = id;
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
    }
}
