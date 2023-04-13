using Microsoft.EntityFrameworkCore;
using RapidPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay
{
    public class AplicationDbContext : DbContext

    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
        }
        
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public DbSet<Models.Fees> Fees { get; set; }
    }
}
