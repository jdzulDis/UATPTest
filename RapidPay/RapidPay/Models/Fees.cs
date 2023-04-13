using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Models
{
    public class Fees
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastAmount { get; set; }
    }
}
