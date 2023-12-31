﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dkshopDb.Models;

namespace dkshopDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingDetailsController : ControllerBase
    {
        private readonly dkshopDbContext _context;

        public BillingDetailsController(dkshopDbContext context)
        {
            _context = context;
        }

        // GET: api/BillingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillingDetail>>> GetBillingDetails()
        {
            return await _context.BillingDetails.ToListAsync();
        }

        // GET: api/BillingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillingDetail>> GetBillingDetail(int id)
        {
            var billingDetail = await _context.BillingDetails.FindAsync(id);

            if (billingDetail == null)
            {
                return NotFound();
            }

            return billingDetail;
        }

        // PUT: api/BillingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillingDetail(int id, BillingDetail billingDetail)
        {
            if (id != billingDetail.BillingId)
            {
                return BadRequest();
            }

            _context.Entry(billingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BillingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillingDetail>> PostBillingDetail(BillingDetail billingDetail)
        {
            _context.BillingDetails.Add(billingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillingDetail", new { id = billingDetail.BillingId }, billingDetail);
        }

        // DELETE: api/BillingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillingDetail(int id)
        {
            var billingDetail = await _context.BillingDetails.FindAsync(id);
            if (billingDetail == null)
            {
                return NotFound();
            }

            _context.BillingDetails.Remove(billingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillingDetailExists(int id)
        {
            return _context.BillingDetails.Any(e => e.BillingId == id);
        }
    }
}
