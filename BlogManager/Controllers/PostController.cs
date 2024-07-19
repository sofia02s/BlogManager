using System.Collections.Generic;
using System.Linq;
using BlogManager.Models;

namespace BlogManager.Controllers
{
    public class PostController
    {
        private static List<Post> _posts = new List<Post>();
        private static int _nextId = 1;

        public List<Post> GetAllPosts() => _posts;

        public void AddPost(string title, string content)
        {
            _posts.Add(new Post { Id = _nextId++, Title = title, Content = content });
        }

        public void UpdatePost(int id, string title, string content)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.Title = title;
                post.Content = content;
            }
        }

        public void DeletePost(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                _posts.Remove(post);
            }
        }
    }
}