using Day1of_WenApi.DTO;
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

   
    public class CategoryController : ControllerBase
    {
        ICategory_Repository CategoryRepositoty;

        public CategoryController(ICategory_Repository CatogRepo)
        {
            CategoryRepositoty = CatogRepo;
        }
        [HttpGet]
        public IActionResult AllProducts()
        {
            
            List<Category> CategoryList = CategoryRepositoty.GetAll();
            if (CategoryList == null)
            {
                return BadRequest("There Are No categories");
            }
            return Ok(CategoryList);
        }
        [HttpGet("{id:int}", Name = "GetRoute")]

        public IActionResult GetDetails(int id)
        {
            Category CategoryList = CategoryRepositoty.GetById(id);
            if (CategoryList == null)
            {
                return BadRequest("There Are No Category Same That You Want");
            }
            return Ok(CategoryList);
        }
        [HttpPost]
        public IActionResult AddNewCategory (Category catog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoryRepositoty.Insert(catog);
                    string url = Url.Link("GetRoute", new { id = catog.Id });
                    return Created(url, catog);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Category categ)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    CategoryRepositoty.Update(id, categ);

                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpGet("Details/{Category_Id:int}")]
        public IActionResult GetCategoryWithitsProducts(int Category_Id)
        {
            Category CategoryModel = CategoryRepositoty.GetById(Category_Id);
             
            CategoryWithProductNames CategoryDto = new CategoryWithProductNames()
            {
                Category_Id = CategoryModel.Id,
                Category_Name = CategoryModel.Name
            };
            foreach (var item in CategoryModel.products)
            {
                CategoryDto.ProductsName.Add(new ProductDTO { Product_Id=item.Id,Products_Name=item.Name});
            }

            return Ok(CategoryDto);
        }

       [HttpDelete("{id:int}")]
      public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                   CategoryRepositoty.Delete(id);
                   
                    return StatusCode(204, "Category Deleted Sucessfully");
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
