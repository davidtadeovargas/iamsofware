using EvaluacionImSoftware.Models;
using EvaluacionImSoftware.Services;
using EvaluacionImSoftware.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EvaluacionImSoftware.Controllers
{
    public class PersonaController : Controller
    {
        //Repositorio de personas
        private PersonsRepository personsRepository;



        public PersonaController()
        {
            personsRepository = new PersonsRepository();
        }


        private void validaModelo(Persona person)
        {
            //Valida el modelo
            if (person.nombre.Length > 50)
            {
                throw new HttpException("Nombre mayor a 50");
            }
            else if (person.email.Length>70)
            {
                throw new HttpException("Email mayor a 70");
            }
            else if (!person.email.Contains("@"))
            {
                throw new HttpException("Formarto invalido de correo");
            }
        }

        [HttpGet]
        public ActionResult verPersonas(Persona person)
        {
            //Obtiene todas las personas
            List<Persona> personas = personsRepository.getAll();

            //Crea el modelo de vista
            VerPersonasViewModel verPersonasViewModel = new VerPersonasViewModel();
            verPersonasViewModel.personas = personas;

            //Pasa el modelo a la vista
            return View(verPersonasViewModel);
        }

        [HttpPost]
        public ActionResult create(Persona persona)
        {
            //Si el modelo ya existe entonces regresa FALSE
            if (personsRepository.getByName(persona.nombre) != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            //Valida el modelo
            try
            {
                validaModelo(persona);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(-1, e.Message);
            }

            //Guarda a la nueva persona
            bool res = personsRepository.create(persona);

            String res_;
            String error;

            //Crea el resultado
            if (res)
            {
                res_ = "ok";
                error = "";

            } else {

                res_ = "error";
                error = "Undefined"; //Pendiente de definir logica para manejo de excepciones y errores de la capa de BD

            }

            return Json(new { res = res_, error = error });
        }

        [HttpPut]
        public Boolean update(int id, Persona person)
        {
            //Si el modelo no existe entonces no hay nada que actualizar y regresa FALSE
            if (personsRepository.get(id) == null)
            {
                return false;

            }

            //Actualiza el modelo y retorna el boleano correspondiente
            return personsRepository.update(id,person);
        }

        [HttpDelete]
        public Boolean delete(int id)
        {
            //Si el modelo no existe entonces no hay nada que borrar y regresa FALSE
            if (personsRepository.get(id)==null)
            {
                return false;
            }

            //Borra el modelo y retorna el boleano correspondiente
            return personsRepository.delete(id);
        }

        [HttpGet]
        public Persona get(int id)
        {
            return personsRepository.get(id);
        }

        [HttpGet]
        public List<Persona> getAll()
        {
            return personsRepository.getAll();
        }
    }
}