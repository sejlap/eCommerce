using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //need to inject storecontext into a product controller
    public class ProductsController : Controller
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]

        // Synchronous request - > ActionResult<List<Product>> req will be blocked until req finished 
        //The best option is using an asynchronous method and it would be waiting
        //use delegate to something else - scalable solution


        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public IActionResult Index()
        {
            return View();
        }



    }
}
