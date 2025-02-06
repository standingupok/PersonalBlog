using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerBlog.Models;
using System.Collections.Generic;
using System.Linq;

namespace PerBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly BlogDBContext dbContext;
        public CategoryController(BlogDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> lstCategories = dbContext.Categories.ToList();
            return View(lstCategories);
        }

        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [BindProperty]
        public Category Category { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(Category);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var categoryToDelete = dbContext.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryToDelete != null)
            {
                dbContext.Categories.Remove(categoryToDelete);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            /*add using Microsoft.EntityFrameworkCore; to fix bug*/
            Category = dbContext.Categories.FirstOrDefault(category => category.Id == id);
            if (Category != null)
            {
                return View(Category);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Category = dbContext.Categories.FirstOrDefault(category => category.Id == id);
            if (Category != null)
            {
                return View(Category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            if (ModelState.IsValid)
            {
                dbContext.Update(Category);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Category");
        }
    }
}
