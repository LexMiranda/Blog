using MeuBlog.DAO;
using MeuBlog.Models;
using MeuBlog.ViewModels;
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
        [Route("posts", Name="ListaPosts")]
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        [HttpPost]
        public ActionResult Adiciona(PostViewModel viewModel) {

            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido",
                    "Posts Publicados precisam de data");
            }
            if (ModelState.IsValid)
            {
                PostDAO postDao = new PostDAO();
                TagDAO tagDao = new TagDAO();
                Post post = viewModel.CriaPost(tagDao);
                postDao.Adiciona(post);
                return RedirectToAction("Index"); 
            }
            else
            {

                return View("Form", viewModel);
            }


        }
       [HttpPost]
        public ActionResult Remove(int id)
        {
            
            Post post = dao.BuscaPorId(id);
            dao.Remover(post);
            return RedirectToAction("Index");
        }

        public ActionResult Atualiza(Post post)
        {
            if (ModelState.IsValid)
            {
                PostDAO dao = new PostDAO();
                dao.Atualizar(post);
                return RedirectToAction("Index"); 
            }
            else
            {
                return View("Visualiza", post);
            }
        }
        [Route("posts/{id}", Name="VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);

        }

	}
}