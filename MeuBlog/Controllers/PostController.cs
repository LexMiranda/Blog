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
         
            return View();
        }
       
        // GET: /Post/
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        [HttpPost]
        public ActionResult Adiciona(Post post) {

          
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index"); 
            }
            else
            {
               
                return View("Form", post);
            }


        }
	}
}