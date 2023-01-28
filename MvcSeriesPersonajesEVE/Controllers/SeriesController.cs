using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MvcSeriesPersonajesEVE.Models;
using MvcSeriesPersonajesEVE.Repositories;

namespace MvcSeriesPersonajesEVE.Controllers
{
    public class SeriesController : Controller
    {
        private RepositorySeries repo;
        
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        //MOSTRAMOS TODAS LAS SERIES
        public IActionResult Index()
        {
            List<Serie> series = this.repo.GetSeries();
            return View(series);
        }

        //MOSTRAMOS LOS DETALLES DE UNA SOLA SERIE
        public IActionResult Detalles(int id)
        {
            Serie serie = this.repo.FindSerie(id);
            return View(serie);
        }

        //MOSTRAMOS UNA VISTA PARA INSERTAR UNA NUEVA SERIE
       public IActionResult InsertarSerie()
       {
           return View();
       }

        [HttpPost]
        public IActionResult InsertarSerie(Serie seri)
        {
            this.repo.InsertarSerie(seri.IdSerie, seri.Nombre, seri.Imagen, seri.Anyo);
            return RedirectToAction("Index");
        }

        //MOSTRAMOS LA VISTA DE LOS PERSONAJES
        public IActionResult Personajes(int id)
        {
            Personaje personajes = this.repo.FindPersonajes(id);
            return View(personajes);
        }
    }
}
