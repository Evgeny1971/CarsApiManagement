using CarsApiManagement.BusinessLayer.ViewModels;
using CarsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsApiManagement.BusinessLayer.Services.Repository
{
    public interface IProductsApiRepository
    {
        List<ShopProduct> GetAllProducts();
        Task<ShopProduct> CreateShopProduct(ShopProduct ShopProduct);
        Task<ShopProduct> GetShopProductById(long id);
        Task<bool> DeleteShopProductById(long id);
        Task<ShopProduct> UpdateShopProduct(ShopProduct model);
    }
}
