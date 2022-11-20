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


        /*
         Método encargado de validar la información del formulario de Login, en el cual la misma se cruza
         con la data de los usuarios almacenados en MockApi. En caso de encontrar coincidencias, redirige a 
         la pantalla de inicio. Caso contrario, vuelve a cargar la vista.         
         */

        [HttpPost]
        public ActionResult Auth(string mail, string password)
        {

            List<Usuario> listUsuarios = Servicios.Usuarios.Listar();

            if (listUsuarios.Any(x => x.Email == mail && x.Clave == password))
            {
                Usuario usuario = listUsuarios.Where(x => x.Email == mail && x.Clave == password).FirstOrDefault();
                Session["Usuario"] = JsonConvert.SerializeObject(usuario);                
                //Session["Usuario"] = usuario;
                //Usuario actual = (Usuario)Session["Usuario"];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }


        }



        /*
         Vista del ABM de usuarios. En la misma se realiza un consumo de la lista de usuarios 
         en Mockapi y se muestran sus datos en un formato de tabla.
         */

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


        /*
         En el siguiente método se procesa el formulario de Contacto de la página web. 
         El mismo tiene como fin enviar las consultas de los posibles clientes a un email
         que se encarga de la distribución a los integrantes del equipo.
         Al no tener ese mail creado, se utiliza el mismo remitente y destinatario, con fines
         de comprobar su funcionamiento.
         */

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



