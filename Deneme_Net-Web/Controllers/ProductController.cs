
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Deneme_Net_Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _servisProduct;
        private ICategoryService _servisCategory;
        private ISizesService _servisSizes;
        private IColorService _servisColor;
        private IPhotoService _servisPhoto;

        public ProductController(IProductService servisProduct, ICategoryService servisCategory, ISizesService servisSizes, IColorService servisColor, IPhotoService servisPhoto)
        {
            _servisProduct = servisProduct;
            _servisCategory = servisCategory;
            _servisSizes = servisSizes;
            _servisColor = servisColor;
            _servisPhoto = servisPhoto;
        }

        public IActionResult ProductIndex()
        {
            return View();
        }

        public IActionResult ProductDetails() { 
        
            return View();
        }
        
        public IActionResult ProductSettings() { 
        
            return PartialView("_ProductSettingsPartial");
        }


       
        public IActionResult AddProductWithDetail() {
            
            
            ViewBag.Categories = _servisCategory.GetAll();
            ViewBag.Colors=_servisColor.GetAll();
            ViewBag.Sizes=_servisSizes.GetAll();



            return PartialView("_addProductWithDetailPartial");
        }
        [HttpPost]
        public IActionResult AddProductWithDetail(Product product, List<int> categoryIds, List<int> colorIds, List<int> sizeIds, List<string> photoUrls) { 
        
            return PartialView("_addProductWithDetailPartial");
        }

       
      
    }
}
