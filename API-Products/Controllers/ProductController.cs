using Microsoft.AspNetCore.Mvc;
using API_Products;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Products.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            return new List<Product>
            {
                new Product
                {
                    Title = "Produto 1",
                    Price = 20.0,
                    Quantify = 32,
                }
            };
        }
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

