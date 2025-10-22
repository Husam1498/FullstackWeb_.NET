using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Deneme_Net_Web.Controllers.Settings
{
    public class KategoriController : Controller
    {
        private ICategoryService _categoryService;

        public KategoriController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAll();
            return PartialView("_CategoryListPartial", categories);
        }
        [HttpPost]
        public IActionResult CategoryAdd([Required(ErrorMessage ="Bir isim giriniz lütfen")][MinLength(5,ErrorMessage ="En az 4 karakterde olmalı")] string categoryName)
        {
            if (ModelState.IsValid) {
                Category category = new Category
                {
                    CategoryName = categoryName
                };
                _categoryService.Create(category);

                TempData["CategoryName"] = "Basarili";
                return CategoryList();
            }
            TempData["CategoryName"] = "Başarısız";
            return CategoryList();
        }      
        
      
        public IActionResult CategoryUpdate(int id)
        {
            Category cat =_categoryService.GetById(id);

            return PartialView("__CategoryUpdatePartial", cat);
        } 
        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            if (ModelState.IsValid) {
                var catgory= _categoryService.GetById(c.CategoryId);
                catgory.CategoryName = c.CategoryName;
                _categoryService.Update(catgory);
                TempData["CategoryUpdate"] = "Basarili";
                return CategoryList();
            }
            TempData["CategoryUpdate"] = "Başarısız";

            return CategoryList();
        }


        public IActionResult CategoryDelete(int id)
        {
            if (id!=0)//silerken ilişkili tablolarıda sil
            {
                      
                _categoryService.CategoryDeleteProduct(id);
                TempData["CategoryDelete"] = "Basarili";
                return CategoryList();
            }
            TempData["CategoryDelete"] = "Başarısız";

            return CategoryList();
        }
    }
}
