using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuBlog.DAO;
using MeuBlog.Models;

namespace MeuBlog.Controllers
{
    public class HomeController : Controller
    {
        private PostDAO postadDao;
        public HomeController(PostDAO postDao)
        {
            this.postadDao = postDao;
        }
        public ActionResult Index()
        {
            IList<Post> posts = postadDao.ListaPublicados();
            return View(posts);
        }
    }
}