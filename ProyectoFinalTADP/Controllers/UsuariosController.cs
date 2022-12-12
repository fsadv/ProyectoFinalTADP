using Entidades;
using Newtonsoft.Json;
using Servicios;
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

        #region Vista de Login de usuarios
        public ActionResult Login()
        {
            return View();
        }

        #endregion


        #region Métodos POST

        [HttpPost]
        public ActionResult Auth(string mail, string password)
        {

            List<Usuario> listUsuarios = Servicios.Usuarios.Listar();

            if (listUsuarios.Any(x => x.Email == mail && x.Clave == password))
            {
                Usuario usuario = listUsuarios.Where(x => x.Email == mail && x.Clave == password).FirstOrDefault();

                Session["Usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }


        }


        [HttpPost]
        public ActionResult Create(Entidades.Usuario collection) //mockAPI no recibe el body
        {
            try
            {

                string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios", JsonConvert.SerializeObject(collection), "Post").CreateObject();
                List<Usuario> listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(listUsuariosJson);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) //mockAPI no recibe el body
        {
            try
            {
                string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "Usuarios" + "/" + id, JsonConvert.SerializeObject(collection), "PUT").CreateObject();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ProcesarForm(string name, string email, string subject, string message)
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

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);

            }


        }

        #endregion


        #region Métodos GET

        public ActionResult Index()
        {
            string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "/Usuarios").CreateObject();
            List<Usuario> listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(listUsuariosJson);

            return View(listUsuarios);
        }


        public ActionResult Details(int id)
        {

            List<Usuario> listUsuarios = Servicios.Usuarios.Listar();
            Usuario usuario = listUsuarios.Where(x => x.Id == id.ToString()).FirstOrDefault();

            return View(usuario);
        }


        public ActionResult Create()
        {
            return View(new Usuario());
        }         


        public ActionResult Edit(int id)
        {
            List<Usuario> listUsuarios = Servicios.Usuarios.Listar();
            Usuario usuario = listUsuarios.Where(x => x.Id == id.ToString()).FirstOrDefault();

            return View(usuario);
        }

        #endregion

        #region Método DELETE

        public ActionResult Delete(int id)
        {
            string listUsuariosJson = new Servicios.Rest(ConfigurationManager.AppSettings["UrlServicios"] + "Usuarios" + "/" + id, id.ToString(), "DELETE").CreateObject();
            return RedirectToAction("Index");
        }

        #endregion





        #region Métodos privados

        private string GenerarBody(string email, string message)
        {
            return "El siguiente email: " + email + " escribe: \n" + message;

        }


        #endregion

    }






}



