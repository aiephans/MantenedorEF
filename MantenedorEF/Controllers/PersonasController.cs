using MantenedorEF.Models;
using MantenedorEF.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantenedorEF.Controllers
{
    public class PersonasController : Controller
    {
        private readonly IPersonasRepositorio _personasRepositorio;

        public PersonasController(IPersonasRepositorio personasRepositorio )
        {
            _personasRepositorio = personasRepositorio;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _personasRepositorio.ObtenerPersonas();
            return View(list);
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevoPost(PersonaCreacionModel model )
        {
            await _personasRepositorio.GuardarPersona(model);
            var list = await _personasRepositorio.ObtenerPersonas();
            return View("Index", list);
        }
        public async Task<IActionResult> Editar([FromRoute] int id)
        {
            var model = await _personasRepositorio.BuscarPersonaPorId(id);
            return View(model);
        }
        public async Task<IActionResult> EliminarPersona([FromRoute] int id)
        {
            await _personasRepositorio.EliminarPersona(id);
            var list = await _personasRepositorio.ObtenerPersonas();
            return View("Index", list);
        }


    }
}
