using MeuBlog.DAO;
using MeuBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuBlog.Controllers
{
    public class PostController : Controller
    {

        public ActionResult Form()
        {
            ViewBag.Post = new Post();
            return View();
        }
       
        // GET: /Post/
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            ViewBag.Posts = dao.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post) {

            if(post.Publicado && !post.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido",
                    "Posts publicados precisam de data");
            }
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewBag.Post = post;
                return View("Form");
            }


        }
	}
}