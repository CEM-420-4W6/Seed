﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : BaseController
    {

        public CatsController(WebAPIContext context): base(context) { }

        // GET: api/Cats
        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetCat()
        {

            return _context.Cats.ToList();
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            if (_context.Cats == null)
            {
                return NotFound();
            }
            var cat = await _context.Cats.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            string? userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //DemoUser user = _context.Users.Single(u => u.Id == userid);

            Cat? catdb = _context.Cats.SingleOrDefault(c => c.Id == id && c.DemoUser!.Id == userid);
            if (catdb == null)
            {
                throw new Exception("DONT TOUCH MY CAT!");
            }


            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
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

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            if (_context.Cats == null)
            {
                return Problem("Entity set 'WebAPIContext.Cat'  is null.");
            }


            string? userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            DemoUser user = _context.Users.Single(u => u.Id == userid);



            _context.Cats.Add(cat);
            cat.DemoUser = user;


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCat", new { id = cat.Id }, cat);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            if (_context.Cats == null)
            {
                return NotFound();
            }
            var cat = await _context.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatExists(int id)
        {
            return (_context.Cats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
