using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarsApiManagement.Entities
{
  public class FeedbackType
      {
          public string Type { get; set; }
          public string Description { get; set; }
      }    
}