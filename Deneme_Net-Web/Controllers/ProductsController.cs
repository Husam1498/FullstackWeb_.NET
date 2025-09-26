using AutoMapper;
using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Deneme_Net_Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _servisProduct;
        private ICategoryService _servisCategory;
        private ISizesService _servisSizes;
        private IColorService _servisColor;
        private IPhotoService _servisPhoto;
        private readonly IMapper _mapper;

        public ProductsController(IProductService servisProduct, ICategoryService servisCategory, 
            ISizesService servisSizes, IColorService servisColor, 
            IPhotoService servisPhoto, IMapper mapper)
        {
            _servisProduct = servisProduct;
            _servisCategory = servisCategory;
            _servisSizes = servisSizes;
            _servisColor = servisColor;
            _servisPhoto = servisPhoto;
            _mapper = mapper;
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
                    ProductSizes = new List<ProductSize>(),
                    
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

        #region Urun Gunceleme
        public IActionResult UpdateProducts(Guid productId)
        {
            if(productId != Guid.Empty)
            {
                Product product = _servisProduct.GetWithIncludesProduct(productId);
                var editProductModel = new EditProductModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    SelectedCategoryIds = product.ProductCategories.Select(pc => pc.CategoryId).ToList(),
                    SelectedColorIds = product.ProductColors.Select(pc => pc.ColorId).ToList(),
                    SelectedSızeIds = product.ProductSizes.Select(ps => ps.SizeId).ToList(),
                    FilesName =product.Photos.Select(ps => ps.url).ToList(),
                    Photos = product.Photos.ToList()
                    
                };
                return PartialView("_UpdateProductsPartial", CategorySızeColorAdd_edit(editProductModel));
            }

            return PartialView("_UpdateProductsPartial");
        }

        [HttpPost]
        public IActionResult UpdateProducts(EditProductModel model)
        {
            if (ModelState.IsValid) { 
                if(model.SelectedCategoryIds?.Count>0 && model.SelectedColorIds.Count>0 && model.SelectedSızeIds?.Count > 0)
                {
                    Product product = _servisProduct.GetWithIncludesProduct(model.ProductId);

                    product.ProductName = model.ProductName;
                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.ProductCategories.Clear();
                    product.ProductColors.Clear();
                    product.ProductSizes.Clear();
                    // product.Photos.Clear();

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

                    foreach (var f in model.Files)
                    {
                        string fileName = $"{product.ProductId}_{f.FileName.Split('.')[0]}.{f.ContentType.Split('/')[1]}";

                        Stream stream = new FileStream($"wwwroot/uploads/ProductsPhoto/{fileName}", FileMode.OpenOrCreate);

                        product.Photos.Add(new Photo
                        {
                            url = fileName,
                            ProductId = model.ProductId,
                        });
                        f.CopyTo(stream);
                        stream.Close();
                        stream.Dispose();
                    }

                    model.Photos = product.Photos?.ToList() ?? new List<Photo>();

                    _servisProduct.UpdateProduct(product);

                    model.Done = "Ürün Başarı bir şekilde güncelendi";
                    return PartialView("_UpdateProductsPartial", CategorySızeColorAdd_edit(model));


                } else if(model.SelectedCategoryIds?.Count == 0)
                {
                    ModelState.AddModelError("SelectedCategoryIds", "En az 1 kategori seçmek zorunlu");
                }
                  else if(model.SelectedColorIds?.Count == 0)
                {
                    ModelState.AddModelError("SelectedColorIds", "En az 1 Color seçmek zorunlu");
                } 
                  else if(model.SelectedSızeIds?.Count == 0)
                {
                    ModelState.AddModelError("SelectedSızeIds", "En az 1 Beden seçmek zorunlu");
                }
               

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

            return PartialView("_UpdateProductsPartial", CategorySızeColorAdd_edit(model));
        }


        [HttpGet]
        public IActionResult DeletePhotoUppdate(int photoId, Guid productId)
        {
            _servisProduct.DeletePhoto(photoId);
            var product = _servisProduct.GetWithIncludesProduct(productId);
            var photos = product.Photos?.ToList() ?? new List<Photo>();
            return PartialView("~/Views/Products/_photoDeletePartial.cshtml", photos);            

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
        private EditProductModel CategorySızeColorAdd_edit(EditProductModel model)
        {           
            model.Categories= _servisCategory.GetAll();
            model.Sizes= _servisSizes.GetAll();
            model.Colors= _servisColor.GetAll();

            return model;
        }



    }
}
