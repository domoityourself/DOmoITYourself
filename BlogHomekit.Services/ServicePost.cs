using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHomekit.Datos;
using BlogHomekit.Model.Posts;
using BlogHomekit.ViewModels.Posts;
using BlogHomekit.ViewModels.Posts.Converters;
using System.Data.Entity;
using BlogHomekit.Model.Dtos;

namespace BlogHomekit.Services
{
    public class ServicePost
    {
        private readonly ContextDB _db;
        public ServicePost(ContextDB contextDB)
        {
            _db = contextDB;
        }

        private IQueryable<Post> Posts()
        {
            return _db.Posts;                
        }

        public async Task UpdatePost(PostDto postDto)
        {
            var post = await GetPost(postDto.Id);
            post.CopyValues(postDto);
            await _db.SaveMyChanges();
        }


        public async Task<Post> GetPost(int id) {
            return await Posts()
                .Include(m => m.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);                   

        }
        public async Task CreatePost(PostDto postDto)
        {
            var Post = new Post();
            Post.CopyValues(postDto);
            _db.Posts.Add(Post);
            await _db.SaveMyChanges();
            postDto.Id = Post.Id;

        }
    }
}
