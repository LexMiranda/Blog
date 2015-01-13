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
        private UsuarioDAO usuarioDao;
        
        public PostController(PostDAO postDao, TagDAO tagDao, UsuarioDAO usuarioDao)
        {
            this.dao = postDao;
            this.tagDao = tagDao;
            this.usuarioDao = usuarioDao;
        }

        public ActionResult Form()
        {

            ViewBag.Usuarios = usuarioDao.Lista();
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
                
                Post post = viewModel.CriaPost(tagDao,usuarioDao);
                dao.Adiciona(post);
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewBag.Usuarios = usuarioDao.Lista();
                return View("Form", viewModel);
            }


        }
       
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
                Post post = viewModel.CriaPost(tagDao, usuarioDao);
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