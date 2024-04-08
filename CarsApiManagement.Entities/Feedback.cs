using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsApiManagement.Entities
{
  public class Feedback
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeedbackType { get; set; }
        public string Comment { get; set; }
    }
}