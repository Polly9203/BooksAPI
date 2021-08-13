using BooksAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksContext Db;
        public BooksController(BooksContext context)
        {
            Db = context;
            if(!Db.Books.Any())
            {
                Db.Books.Add(new Book { Name = "Vanish", Author = "Sophie Jordan", Annotation = "An Impossible Romance.Bitter Rivalries..." });
                Db.Books.Add(new Book { Name = " Sharp Objects", Author = "Gillian Flynn", Annotation = "Fresh from a brief stay..." });
                Db.Books.Add(new Book { Name = "Peter Pan", Author = "J. M. Barrie", Annotation = "Peter Pan is a character..." });
                Db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await Db.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await Db.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            Db.Books.Add(book);
            await Db.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!Db.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }

            Db.Update(book);
            await Db.SaveChangesAsync();
            return CreatedAtAction("Book was created", new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            Book book = Db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Db.Books.Remove(book);
            await Db.SaveChangesAsync();
            return NoContent();
        }
    }
}
