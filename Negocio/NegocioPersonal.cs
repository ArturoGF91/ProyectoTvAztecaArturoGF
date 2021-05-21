using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NegocioPersonal
    {
        private M_Personal  _MPersonal = new M_Personal();

        public NegocioPersonal() { }
        //Consultar todo
        public List<PersonalTvAzteca> ConsulPersonal() => _MPersonal.ConsulPersonal();
        //consultar por id
        public PersonalTvAzteca ConslPersonalId(int? id) => _MPersonal.ConsPersonalId((int) id);
        // agregar
        public PersonalTvAzteca AgregarPersonal(PersonalTvAzteca personal) => _MPersonal.AgregarPersonal(personal);
        // actualizar
        public PersonalTvAzteca EditarPersonal(PersonalTvAzteca personal) => _MPersonal.EditarPersonal(personal);

        //Eliminar
        public PersonalTvAzteca EliminarPersonal(PersonalTvAzteca personal) => _MPersonal.EliminarPersonal(personal);
    }
}
