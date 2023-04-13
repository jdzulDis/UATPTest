using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RapidPay.DTOS;
using RapidPay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay
{
    public class Fees : IFees

    {
        private readonly AplicationDbContext _context;
       
        public Fees(AplicationDbContext context)
        {
            _context = context;
        }

        public decimal GetFee()
        {
            var fees = _context.Fees.FirstOrDefault();

            _context.Entry(fees).State = EntityState.Modified;

            Random rnd = new Random();
            int rand = rnd.Next(3);

            var _newfee = Convert.ToDecimal(rand) * Convert.ToDecimal(fees.LastAmount);
            fees.LastAmount = _newfee;
             _context.SaveChanges();

            return _newfee;
            

            
        }
    }
}
