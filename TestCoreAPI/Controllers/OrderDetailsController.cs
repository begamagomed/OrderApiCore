﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreAPI.Models;

namespace TestCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly Context _context;

        public OrderDetailsController(Context context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.Where(w=>w.OrderId==id).Include(i=>i.Order.Status).ToListAsync();

            if (orderDetails == null)
            {
                return NotFound();
            }

            return orderDetails;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetails(int id, OrderDetails orderDetails)
        {
            if (id != orderDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> PostOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetails", new { id = orderDetails.Id}, orderDetails);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDetails>> DeleteOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();

            return orderDetails;
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id== id);
        }
    }
}
