using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;
using BulkyBookWeb.Data;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.Categories;
            return View(objCategoryList);
        }

        #region POST
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "O Nome e a Ordem de exibição não podem ser iguais");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Categoria criada com sucesso";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #endregion


        #region PUT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _context.Categories.SingleOrDefault(p => p.Id == id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "O Nome e a Ordem de exibição não podem ser iguais");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Categoria atualizada com sucesso";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #endregion


        #region DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categoryFromDb = _context.Categories.SingleOrDefault(p => p.Id == id);

            if (categoryFromDb == null)
                return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _context.Categories.SingleOrDefault(p => p.Id == id);

            if (obj == null)
                return NotFound();

            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Categoria deletada com sucesso";
            return RedirectToAction("Index");
        }

        #endregion

    }
}