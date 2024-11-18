using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class PostRepository : IPostRepository
    {
        //private static readonly ISet<Post> _posts = new HashSet<Post>()
        //{
        //new Post(1, "Tytuł 1", "Treść 1"),
        //new Post(2, "Tytuł 2", "Treść 2"),
        //new Post(3, "Tytuł 3", "Treść 3"),
        //};

        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            //return _posts;
            return _context.Posts;
        }

        public Post? GetById(int id)
        {
            //return _posts.FirstOrDefault(post => post.Id == id);
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        public Post Add(Post post)
        {
            //post.Id = _posts.LastOrDefault().Id + 1;
            post.Created = DateTime.Now;
            //_posts.Add(post);
            //return post;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Update(Post post)
        {
            post.LastModified = DateTime.Now;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            //_posts.Remove(post);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
