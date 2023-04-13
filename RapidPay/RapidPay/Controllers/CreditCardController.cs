using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidPay.DTOS;
using RapidPay.Interfaces;
using RapidPay.Models;
using RapidPay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        
        private readonly IFees _charge;
        public CreditCardController(AplicationDbContext context, IFees charge)
        {
          
            _context = context;
            _charge = charge;
        }

        //GET:api/CreditCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCard()
        {
            return await _context.CreditCard.ToListAsync();
        }

        //GET: api/CreditCard/5
        [HttpGet("{id}")]

        public async Task<ActionResult<BalanceViewModel>> GetCreditCard(int id)
        {
            var cardnumber = await _context.CreditCard.FindAsync(id);

            if (cardnumber == null)
            {
                return NotFound();
            }
            BalanceViewModel _balance = new BalanceViewModel();

            _balance.id = cardnumber.Id;
            _balance.balance = cardnumber.balance;
            
            return _balance;
        }

        
        [Authorize]
        [HttpPost("Create_Card")]
        public async Task<ActionResult<CreditCard>> Create(CreditCard creditcard)
        {
            _context.CreditCard.Add(creditcard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCard", new { id = creditcard.Id }, creditcard);
        }



        // PUT api/<ValuesController>/5
        [Authorize]
        [HttpPut("{id}")]
        
        public async Task<ActionResult<decimal>> Put(int id,[FromBody] ChargeDto charge)
        {

            var cardnumber = await _context.CreditCard.SingleOrDefaultAsync(x => x.Id == charge.Id);


            if (cardnumber == null)
            {
                return BadRequest();
            }

            decimal fee = _charge.GetFee();
            decimal _balance = charge.Charge;
             

            _context.Entry(cardnumber).State = EntityState.Modified;
            _balance = _balance + fee;
             cardnumber.balance = _balance;
            _context.SaveChanges();

            return _balance;
             
       }

  
    }
                
    
}
