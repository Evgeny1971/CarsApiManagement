using CarsApiManagement.BusinessLayer.Interfaces;
using CarsApiManagement.BusinessLayer.Services.Repository;
using CarsApiManagement.BusinessLayer.ViewModels;
using CarsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsApiManagement.BusinessLayer.Services
{
    public class CarsApiService : ICarsApiService
    {
        private readonly ICarsApiRepository _carsApiRepository;

        public CarsApiService(ICarsApiRepository carsApiRepository)
        {
            _carsApiRepository = carsApiRepository;
        }

        public async Task<ShopProduct> CreateShopProduct(ShopProduct ShopProduct)
        {
            return await _carsApiRepository.CreateShopProduct(ShopProduct);
        }

        public async Task<bool> DeleteShopProductById(long id)
        {
            return await _carsApiRepository.DeleteShopProductById(id);
        }

        public List<ShopProduct> GetAllProducts()
        {
            return _carsApiRepository.GetAllProducts();
        }

        public async Task<ShopProduct> GetShopProductById(long id)
        {
            return await _carsApiRepository.GetShopProductById(id);
        }

        public async Task<ShopProduct> UpdateShopProduct(ShopProduct model)
        {
            return await _carsApiRepository.UpdateShopProduct(model);
        }
    }
}