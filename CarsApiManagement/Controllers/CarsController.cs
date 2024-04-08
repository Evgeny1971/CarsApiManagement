using CarsApiManagement.BusinessLayer.Interfaces;
using CarsApiManagement.BusinessLayer.ViewModels;
using CarsApiManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsApiManagement.Controllers
{
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsApiService _carsApiService;
        public CarsController(ICarsApiService carsApiService)
        {
            _carsApiService = carsApiService;
        }

        [HttpPost]
        [Route("create-order")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder([FromBody] List<Car> model)
        {
            var policyExists = await _carsApiService.GetShopProductById(model.ID);
            if (policyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy already exists!" });
            var result = await _carsApiService.CreateShopProduct(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Insurance Policy creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Product created successfully!" });

        }


        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateShopProduct([FromBody] ShopProduct model)
        {
            var policy = await _carsApiService.UpdateShopProduct(model);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"product With Id = {model.ID} cannot be found" });
            }
            else
            {
                var result = await _CarsApiService.UpdateShopProduct(model);
                return Ok(new Response { Status = "Success", Message = "product updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteShopProduct(long id)
        {
            var policy = await _CarsApiService.GetShopProductById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"product With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _CarsApiService.DeleteShopProductById(id);
                return Ok(new Response { Status = "Success", Message = "product deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-product-by-id")]
        public async Task<IActionResult> GetShopProductById(long id)
        {
            var policy = await _CarsApiService.GetShopProductById(id);
            if (policy == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"product With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(policy);
            }
        }

        [HttpGet]
        [Route("get-all-products")]
        public async Task<IEnumerable<ShopProduct>> GetAllProducts()
        {
            return _CarsApiService.GetAllProducts();
        }

        
    }
}