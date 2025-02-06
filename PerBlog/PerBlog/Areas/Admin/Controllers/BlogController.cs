using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerBlog.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PerBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly BlogDBContext dbContext;
        
        public BlogController(BlogDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Blog> lstBlogs = dbContext.Blogs.ToList();
            return View(lstBlogs);
        }

        public IActionResult Create()
        {
            Blog blog = new Blog();
            List<Category> categories = dbContext.Categories.ToList();
            ViewBag.Categories = categories;
            return View(blog);
        }
        [BindProperty]
        public Blog Blog { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id)
        {
            if (ModelState.IsValid)
            {
                Blog.Category = dbContext.Categories.First(cate => cate.Id == Blog.CateId);
                dbContext.Blogs.Add(Blog);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var postToDelete = dbContext.Blogs.FirstOrDefault(u => u.Id == id);
            if (postToDelete != null)
            {
                dbContext.Blogs.Remove(postToDelete);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            /*add using Microsoft.EntityFrameworkCore; to fix bug*/
            Blog = dbContext.Blogs.Include(u => u.Category).FirstOrDefault(blog => blog.Id == id);
            if (Blog != null)
            {
                return View(Blog);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Blog = dbContext.Blogs.FirstOrDefault(blog => blog.Id == id);
            if (Blog != null)
            {
                List<Category> categories = dbContext.Categories.ToList();
                ViewBag.Categories = categories;
                return View(Blog);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Blog");
            }
            if (ModelState.IsValid)
            {
                Blog.Category = dbContext.Categories.FirstOrDefault(cate => cate.Id == Blog.CateId);
                dbContext.Update(Blog);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Blog");
        }
    }
}
