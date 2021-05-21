using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Web;
using Entidades;

namespace Datos
{
    public class M_Personal
    {
        private TvAztecaIrvingEntities1 db = new TvAztecaIrvingEntities1();
        public List<PersonalTvAzteca> ConsulPersonal()
        {
            var personal = db.PersonalTvAzteca;
            return personal.ToList();
        }
        public PersonalTvAzteca ConsPersonalId(int id)
        {
            PersonalTvAzteca personal = db.PersonalTvAzteca.Find(id);
            return personal;
        }
        public PersonalTvAzteca AgregarPersonal(PersonalTvAzteca personal)
        {
            db.PersonalTvAzteca.Add(personal);
            db.SaveChanges();
            return personal;
        }

        public PersonalTvAzteca EditarPersonal(PersonalTvAzteca personal)
        {
            db.Entry(personal).State = EntityState.Modified;
            db.SaveChanges();
            return personal;
        }
        public PersonalTvAzteca EliminarPersonal(PersonalTvAzteca personal)
        {
            db.PersonalTvAzteca.Remove(personal);
            db.SaveChanges();
            return personal;
        }
    }
}
