using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Concrete
{
    [Table("Rentals")]
    public class Rentals:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

