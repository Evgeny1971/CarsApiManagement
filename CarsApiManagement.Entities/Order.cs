using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsApiManagement.Entities
{
 public class Order
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyHp { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public List<Car> ListCars {get; set;}
    }
}