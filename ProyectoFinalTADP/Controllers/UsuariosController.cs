using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalTADP.Controllers
{
    public class UsuariosController : Controller
    {


        public ActionResult Login()
        {
            return View();
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios").CreateObject();
            List<Usuario> listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(listUsuariosJson);

            return View(listUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View(new Entidades.Usuario());
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Entidades.Usuario collection)
        {
            try
            {
                string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios", JsonConvert.SerializeObject(collection),"Post").CreateObject();
                List<Usuario> listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(listUsuariosJson);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ProcesarForm(string name, string email, string subject, string message) //Metodo que procesa el formulario de envio de correo
        {
            try
            {
                Utilidades.Email.EnviarEmail(
                           ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                           ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                           name,
                           "Daily.Web",
                           ConfigurationManager.AppSettings["UsuarioCorreo"].ToString(),
                           ConfigurationManager.AppSettings["Clave"].ToString(),
                           subject,
                           GenerarBody(email, message), false,
                           ConfigurationManager.AppSettings["Host"].ToString(),
                           Convert.ToInt32(ConfigurationManager.AppSettings["Puerto"].ToString()),
                           Convert.ToBoolean(ConfigurationManager.AppSettings["UsaSSL"].ToString()));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Error");

            }       

           
        }

        private string GenerarBody (string email, string message) //Metodo para llenar el cuerpo del mail
        {
            return "El siguiente email: " + email + " escribe: \n" + message;

        }
    }

      
    }



