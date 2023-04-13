using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.DTOS
{
    public class ChargeDto
    {
        public int Id { get; set; }
        public decimal Charge { get; set; }
        public string  CardNumber { get; set; }


    }
}
