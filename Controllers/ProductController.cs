using Day1of_WenApi.Model;
using Day1of_WenApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Day1of_WenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        IProduct_Repository ProductRepositoty;

        public ProductController(IProduct_Repository produRepo)
        {
            ProductRepositoty = produRepo;
        }
        [HttpGet]
        public IActionResult AllProducts()
        {
           
            List<Product> ProductList = ProductRepositoty.GetAll();
            if (ProductList == null)
            {
                return BadRequest("There Are No Products");
            }
            return Ok(ProductList);
        }
        [HttpGet("{id:int}", Name = "getOneRoute")]

        public IActionResult GetDetails(int id)
        {
            Product ProductList = ProductRepositoty.GetById(id);
            if (ProductList == null)
            {
                return BadRequest("There Are No Product Same That You Want");
            }
            return Ok(ProductList);
        }

        [HttpGet("catid")]
        public IActionResult GetProductsbyCategoryID(int catogid)
        {
            List<Product> ProductList = ProductRepositoty.GetAllProductsByCatID(catogid);
            if (ProductList == null)
            {
                return BadRequest("There Are No Product Same That You Want");
            }
            return Ok(ProductList);
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductRepositoty.Insert(product);
                    string url = Url.Link("getOneRoute", new { id = product.Id });
                    return Created(url, product);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    ProductRepositoty.Update(id, product);
                   
                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
          [HttpDelete("{id:int}")]
            public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    ProductRepositoty.Delete(id);
                   
                    return StatusCode(204, "Product Deleted Sucessfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }

    }
}
