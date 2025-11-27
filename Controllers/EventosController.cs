using Microsoft.AspNetCore.Mvc;
using CalendarioEventos.Models;

namespace CalendarioEventos.Controllers
{
    public class EventosController : Controller
    {
        private static List<Evento> eventos = new List<Evento>();
        private static int contadorId = 1;

        public IActionResult Index()
        {
            return View(eventos.OrderBy(e => e.FechaInicio).ToList());
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Evento evento)
        {
            evento.Id = contadorId++;
            eventos.Add(evento);
            return Json(new { success = true, evento });
        }

        [HttpPost]
        public IActionResult Editar([FromBody] Evento evento)
        {
            var eventoExistente = eventos.FirstOrDefault(e => e.Id == evento.Id);
            if (eventoExistente != null)
            {
                eventoExistente.Titulo = evento.Titulo;
                eventoExistente.Descripcion = evento.Descripcion;
                eventoExistente.FechaInicio = evento.FechaInicio;
                eventoExistente.FechaFin = evento.FechaFin;
                eventoExistente.Categoria = evento.Categoria;
                eventoExistente.Color = evento.Color;
                eventoExistente.TieneRecordatorio = evento.TieneRecordatorio;
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.Id == id);
            if (evento != null)
            {
                eventos.Remove(evento);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult ObtenerEventos(string fecha)
        {
            if (DateTime.TryParse(fecha, out DateTime fechaBuscada))
            {
                var eventosDia = eventos.Where(e => e.FechaInicio.Date == fechaBuscada.Date).ToList();
                return Json(eventosDia);
            }
            return Json(eventos);
        }
    }
}