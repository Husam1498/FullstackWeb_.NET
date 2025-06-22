
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
            /*
             Product bir model oluşturiçerisinde id name,price gibi özelikler olsun sadece category colors ve sizes olmasın
             
             */
            if (ModelState.IsValid) { 
            
                Product product1 = new Product();
                
            
            }



            return PartialView("_addProductWithDetailPartial");
        }

       
      
    }
}
