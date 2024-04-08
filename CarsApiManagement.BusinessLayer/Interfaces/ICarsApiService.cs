using CarsApiManagement.BusinessLayer.ViewModels;
using CarsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsApiManagement.BusinessLayer.Interfaces
{
    public interface ICarsApiService
    {
        List<Car> GetAllCars();
        Task<Car> CreateShopProduct(Car car);
        Task<Car> GetCarById(long id);
        Task<ShopProduct> UpdateCar(Car car);
    }
}
