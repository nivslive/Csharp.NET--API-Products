using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using API_Products.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Azure.Core;

namespace API_Products.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            Console.WriteLine(products);
            return Ok(products);
        }

        // GET: api/values
        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Print the product in the console.
            Console.WriteLine(product);

            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {

            string? quantifyRequested = Request.Form["quantify"],
                    priceRequested = Request.Form["price"];


            if (quantifyRequested == null)
            {
                return NotFound("left quantify data!");
            }

            if(priceRequested == null)
            {
                return NotFound("left price data!");
            }

            int quantify = int.Parse(quantifyRequested);
            double price = double.Parse(priceRequested);

            // Create a new product.
            Product product = new()
            {
                Title = value,
                Quantify = quantify,
                Price = price
            };

            // Save the product to the database.
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

