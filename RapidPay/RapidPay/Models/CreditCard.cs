using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Models
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15)]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string ExpDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CVV { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal balance { get; set; }

        

    }
}
