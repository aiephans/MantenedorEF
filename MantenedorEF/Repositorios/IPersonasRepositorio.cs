using MantenedorEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantenedorEF.Repositorios
{
    public interface IPersonasRepositorio
    {
        Task<PersonaEdicionModel> BuscarPersonaPorId(int id);
        Task EliminarPersona(int id);
        Task GuardarPersona(PersonaCreacionModel model);
        Task<List<PersonaModel>> ObtenerPersonas();
    }
}
