using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuBlog.DAO;
using MeuBlog.Models;
using NHibernate.Mapping;

namespace MeuBlog.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            usuarioDAO.Adiciona(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }

    public ActionResult Form()
        {
            return View();
        }
    }
}