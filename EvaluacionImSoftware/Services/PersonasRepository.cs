using EvaluacionImSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluacionImSoftware.Services
{
    public class PersonsRepository
    {
        //Contexto de base de datos
        private MydbEntities db = new MydbEntities();


        public Boolean create(Persona person)
        {
            //Guarda el nuevo modelo
            Persona entity = db.personas.Add(person);

            db.SaveChanges();

            return entity!=null;
        }

        public Boolean update(int id, Persona person)
        {
            //Obtiene de la base de datos por id
            Persona per = db.personas.Find(id);

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
            Persona per = db.personas.Find(id);

            //Borrala
            db.personas.Remove(per);

            return true;
        }

        public Persona get(int id)
        {
            //Obtiene de la base de datos por id
            Persona per = db.personas.Find(id);

            return per;
        }

        public Persona getByName(String name)
        {
            //Obtiene de la base de datos por id
            Persona per = (from person in db.personas
                            where person.nombre == name select person).First();

            return per;

        }
        public List<Persona> getAll()
        {
            return db.personas.ToList();
        }
    }
}