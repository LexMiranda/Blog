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
        private PostDAO dao;
        private TagDAO tagDao;


        public PostController(PostDAO dao, TagDAO tagDao)
        {
            this.dao = dao;
            this.tagDao = tagDao;
        }

        public ActionResult Form()
        {
         
            return View();
        }
       
        // GET: /Post/
        [Route("posts", Name="ListaPosts")]
        public ActionResult Index()
        {
           
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
                
                Post post = viewModel.CriaPost(tagDao);
                dao.Adiciona(post);
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

        public ActionResult Atualiza(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                
                Post post = viewModel.CriaPost(tagDao);
                dao.Atualizar(post);
                return RedirectToAction("Index"); 
            }
            else
            {
                return View("Visualiza", viewModel);
            }
        }


        [Route("posts/{id}", Name="VisualizaPost")]

        public ActionResult Visualiza(int id)
        {
            
            Post post = dao.BuscaPorId(id);
            PostViewModel viewModel = new PostViewModel(post);

            return View(viewModel);

        }

	}
}