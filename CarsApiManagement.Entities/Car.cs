using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsApiManagement.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}
