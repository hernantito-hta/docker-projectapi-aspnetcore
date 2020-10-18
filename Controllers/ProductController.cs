using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;
using ProjectAPI.Services;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _productService.Get();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var s = await _productService.Get(id);
            if(s == null)
            {
                return NotFound();
            }

            return s;
        }



        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product s)
        {
            await _productService.Create(s);
            return CreatedAtRoute("Get", new { id = s.Id.ToString() }, s);

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public  async Task<ActionResult<Product>> Put(string id, [FromBody] Product su)
        {
            var s = await _productService.Get(id);
            if (s == null)
            {
                return NotFound();
            }
            su.Id = s.Id;

            await _productService.Update(id, su);
            return CreatedAtRoute("Get", new { id = su.Id.ToString() }, su);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(string id)
        {
            var s = await _productService.Get(id);
            if (s == null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}