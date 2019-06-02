using PagedList;
using BlogHomekit.Model.Posts;
using System.Collections.Generic;

namespace BlogHomekit.ViewModels.Blog
{
    public class BlogPostsSummaryList
    {
        public BlogPostsSummaryList()
        {
        }
        public IList<PostSummary> PostsSummaryList { get; set; }
    }
}
