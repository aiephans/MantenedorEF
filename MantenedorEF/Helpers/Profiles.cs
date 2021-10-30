using AutoMapper;
using MantenedorEF.Models;
using MantenedorEF.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantenedorEF.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Persona, PersonaModel>();
            CreateMap<Persona, PersonaCreacionModel>().ReverseMap();
            CreateMap<Persona, PersonaEdicionModel>();
        }
    }
}
