using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogHomekit.Datos;
using BlogHomekit.Model.Posts;
using BlogHomekit.ViewModels.Posts;
using BlogHomekit.Model.Dtos;
using BlogHomekit.Services;

namespace BlogHomekit.Web.Controllers
{
    public class PostsController : Controller
    {
        private ContextDB db = new ContextDB();

        private readonly ServicePost _servicePost;

        public PostsController() : this(new ContextDB())
        {
        }

        public PostsController(ContextDB Context) :
            this(new ServicePost(Context))
        { }

        public PostsController(ServicePost servicePost)
        {
            _servicePost = servicePost;

        }

        // GET: Posts
        public async Task<ActionResult> Index()
        {
            return View(await db.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }


        public ActionResult Create()
        {
            var viewModel = new EditPostViewModel(new Post())
            {
                EditPost = new EditPost(Post.CreateNewPost())
            };
            return View(viewModel);
        }

        // POST: Posts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EditPostViewModel post)        
        {
            if (ModelState.IsValid)
            {
                await _servicePost.CreatePost(post.ToDto());
            }

            return View(post);

        }

        // GET: Posts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EditPostViewModel(post)
            {
                EditPost = new EditPost(post)
            };

            return View(viewModel);
        }

        // POST: Posts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditPostViewModel post)
        {
            if (ModelState.IsValid)

            {
                await UpdatePost(post.ToDto());
            }

            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private async Task UpdatePost(PostDto postDto)
        {
            await _servicePost.UpdatePost(postDto);
        }
    }
}
