using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Deneme_Net_Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _servisProduct;
        private ICategoryService _servisCategory;
        private ISizesService _servisSizes;
        private IColorService _servisColor;
        private IPhotoService _servisPhoto;

        public ProductsController(IProductService servisProduct, ICategoryService servisCategory, ISizesService servisSizes, IColorService servisColor, IPhotoService servisPhoto)
        {
            _servisProduct = servisProduct;
            _servisCategory = servisCategory;
            _servisSizes = servisSizes;
            _servisColor = servisColor;
            _servisPhoto = servisPhoto;
        }

        public IActionResult ProductsIndex()
        {
            return PartialView("_ProductsIndexPartial");
        }

        #region Urun Listeleme 
        public IActionResult ListProducts()
        {
            IEnumerable<Product> products = _servisProduct.GetWithIncludes();

            return PartialView("_listProducts",products);
        }

        #endregion

        #region ProductsEkleme
        public IActionResult AddProducts()
        {
            AddProductModel model = new AddProductModel();
     
            return PartialView("_AddProductsPartial", CategorySızeColorAdd(model));
        }
        [HttpPost]
        public IActionResult AddProducts(AddProductModel model)
        {
            if (ModelState.IsValid) {
                //Ekleme işlemleri
                AddProductModel addProductModel= CategorySızeColorAdd(model);

                Product product = new Product
                {
                    ProductId=Guid.NewGuid(),
                    ProductName=addProductModel.ProductName,
                    Description=addProductModel.Description,
                    Price=addProductModel.Price,
                    Photos = new List<Photo>(),
                    ProductCategories = new List<ProductCategory>(),
                    ProductColors = new List<ProductColor>(),
                    ProductSizes = new List<ProductSize>()
                };

                foreach (int categoryId in model.SelectedCategoryIds)
                {
                    product.ProductCategories.Add(new ProductCategory
                    {
                        CategoryId = categoryId,
                    });

                }

                foreach (int colorId in model.SelectedColorIds)
                {
                    product.ProductColors.Add(new ProductColor
                    {
                        ColorId = colorId,
                    });

                }

                foreach (int sizeId in model.SelectedSızeIds)
                {
                    product.ProductSizes.Add(new ProductSize
                    {
                        SizeId = sizeId,
                    });

                }

                foreach (var f in model.Files) {

                    string fileName = $"{product.ProductId}_{f.FileName.Split('.')[0]}.{f.ContentType.Split('/')[1]}";

                    Stream stream = new FileStream($"wwwroot/uploads/ProductsPhoto/{fileName}", FileMode.OpenOrCreate);

                    product.Photos.Add(new Photo
                    {
                        url= fileName,
                    });
                    f.CopyTo(stream);
                    stream.Close();
                    stream.Dispose();                          
                }

                _servisProduct.Create(product);

                return PartialView("_AddProductsPartial", new AddProductModel { Done="Urun Ekleme Basarili bir şekilde Gerçekleşti"});
            }

            #region Arayuzdeki Category-Color-Sıze seçilmemişse
            if (model.SelectedCategoryIds.Count == 0)
            {
                ModelState.AddModelError("SelectedCategoryIds", "En az 1 kategori seçmek zorunlu");
            }
            if (model.SelectedColorIds.Count == 0)
            {
                ModelState.AddModelError("SelectedColorIds", "En az 1 Renk seçmek zorunlu");
            }
            if (model.SelectedSızeIds.Count == 0)
            {
                ModelState.AddModelError("SelectedSızeIds", "En az 1 beden seçmek zorunlu");
            }

                #endregion

            return PartialView("_AddProductsPartial", CategorySızeColorAdd(model));
        }
        #endregion



        //Database de var olan Category-Color-Sıze ları UI de göstermek için
        private AddProductModel CategorySızeColorAdd(AddProductModel model)
        {           
            model.Categories= _servisCategory.GetAll();
            model.Sizes= _servisSizes.GetAll();
            model.Colors= _servisColor.GetAll();

            return model;
        }
    }
}
