using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using BlogHomekit.Datos;
using BlogHomekit.Model.Posts;
using BlogHomekit.ViewModels.Blog;
using BlogHomekit.Services;

namespace BlogHomekit.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ServiceBlog _ServiceBlog;

        private readonly ContextDB _db;

        public HomeController()
        {
            _db = new ContextDB();
            _ServiceBlog = new ServiceBlog(_db);
        }


        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, VaryByParam = "none", NoStore = true)]
        public async Task<ActionResult> Index()
        {

            var viewModel = await GetCoverPosts();
            return View(viewModel);

        }

        private async Task<BlogPostsSummaryList> GetCoverPosts()
        {
            return new BlogPostsSummaryList
            {
                PostsSummaryList = await _ServiceBlog.GetPostSummariesPublished(6)
            };
        }

        public IQueryable<Post> Posts()
        {
            return _db.Posts;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}