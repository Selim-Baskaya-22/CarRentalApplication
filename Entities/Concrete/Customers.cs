using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites.Abstract;

namespace Entities.Concrete
{
    [Table("Customer")]
    public class Customers:IEntity
    {
        [Key]
        public int CustomerId { get ; set ; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }

}
