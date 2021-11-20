using EvaluacionImSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluacionImSoftware.Services
{
    public class PersonsRepository
    {
        //Contexto de base de datos
        private mydbEntities db = new mydbEntities();


        public Boolean create(Persona person)
        {
            //Guarda el nuevo modelo
            Persona entity = db.Persona.Add(person);

            db.SaveChanges();

            return entity!=null;
        }

        public Boolean update(int id, Persona person)
        {
            //Obtiene de la base de datos por id
            Persona per = db.Persona.Find(id);

            //Actualiza el modelo en memoria
            per.nombre = person.nombre;
            per.edad = person.edad;
            per.email = person.email;

            db.SaveChanges();

            return true;
        }

        public Boolean delete(int id)
        {
            //Obtiene de la base de datos por id
            Persona per = db.Persona.Find(id);

            //Borrala
            db.Persona.Remove(per);
            db.SaveChanges();

            return true;
        }

        public Persona get(int id)
        {
            //Obtiene de la base de datos por id
            Persona per = db.Persona.Find(id);

            return per;
        }

        public Persona getByName(String name)
        {
            try
            {

                //Obtiene de la base de datos por nombre
                Persona per = (from person in db.Persona
                               where person.nombre == name
                                select person).First();

                return per;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
        public List<Persona> getAll()
        {
            return db.Persona.ToList();
        }
    }
}