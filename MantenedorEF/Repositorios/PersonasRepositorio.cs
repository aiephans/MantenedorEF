using AutoMapper;
using MantenedorEF.Models;
using MantenedorEF.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantenedorEF.Repositorios
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonasRepositorio(ApplicationDbContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PersonaModel>> ObtenerPersonas()
        {
            var personasDb = await _context.Personas.ToListAsync();
            //Mapeo de entidades
            var listaModel = _mapper.Map<List<PersonaModel>>(personasDb);
            //var listaModel = new List<PersonaModel>();
            //foreach (var item in personasDb)
            //{
            //    var nuevaPersonaModel = new PersonaModel() { Id = item.Id, Nombre = item.Nombre };
            //    listaModel.Add(nuevaPersonaModel);
            //}
            return listaModel;

        }

        public async Task GuardarPersona(PersonaCreacionModel model)
        {
            var entidad = _mapper.Map<Persona>(model);
            _context.Personas.Add(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonaEdicionModel> BuscarPersonaPorId(int id)
        {
            var personaDb = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<PersonaEdicionModel>(personaDb);
            return model;
        }

        public async Task EliminarPersona(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }
    }
}
