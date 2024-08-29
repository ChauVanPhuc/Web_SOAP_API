using Microsoft.AspNetCore.Mvc;
using Web_SOAP_API.Model;
using Web_SOAP_API.Service;

namespace Web_SOAP_API.Controllers
{

    [ApiController]
    [Route("api/Blog")]
    public class BlogController : ControllerBase , IBlogService
    {
        private static List<Blog> blogs = new List<Blog>();


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void AddBlog(string Title, string Content)
        {
            Blog blog = new Blog();

            blog.Title = Title;
            blog.Content = Content;
            blog.Id = blogs.Count + 1;
            blog.CreatedDate = DateTime.Now;
            blogs.Add(blog);
        }


        [HttpGet("{id:int}", Name = "GetBlog")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Blog GetBlog(int id)
        {
            return blogs.FirstOrDefault(b => b.Id == id)!;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Blog> GetAllBlogs()
        {
            return blogs;
        }


        [HttpPut("{id:int}", Name = "UpdateBlog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void UpdateBlog(int id, string Title, string Content)
        {
            var existingBlog = blogs.FirstOrDefault(b => b.Id == id);
            if (existingBlog != null)
            {
                existingBlog.Title = Title;
                existingBlog.Content = Content;
            }
        }


        [HttpDelete("{id:int}", Name = "DeleteBlog")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void DeleteBlog(int id)
        {
            var blog = blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                blogs.Remove(blog);
            }
        }
    }
}
