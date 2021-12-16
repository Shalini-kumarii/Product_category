using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pro_cat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;  //This is where session comes from
namespace Pro_cat.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {

        private MyContext _context;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]      // Both lines can be written in one line

        public ViewResult Index()
        {

            ViewBag.Product =_context.Products.ToList();
         
            return View("Index");
        }

        [HttpGet("product")]      // Both lines can be written in one line

        public ViewResult ProductView()
        {

            ViewBag.Product =_context.Products.ToList();
         
            return View("Index");
        }


        [HttpPost("product/newproduct")]
        public IActionResult NewProduct(Product fromForm)
        {
            if (ModelState.IsValid)
            {

                _context.Add(fromForm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("product/{ProductId}")]
        public IActionResult ProductInfo(int ProductId)
        {
            IndexView ViewModel = new IndexView()
            {
                ToRender = _context.Products
                    .Include(m => m.ProductCategories) // but this is a middle table, so
                        .ThenInclude(plm => plm.AllCategory)
                    .FirstOrDefault(m => m.ProductId == ProductId),
                // List of Products that this Category has not already been part of
                ToProductTo = _context.Categories
                    .Include(p => p.CategoryProducts) 
                    .Where(p => !p.CategoryProducts.Any(mk => mk.ProductId == ProductId))
                    .ToList()
            };
            
            return View("ProductInfo", ViewModel);
        }

        [HttpPost("product/{productId}/Add")]
        public IActionResult AddCategory(int productId, IndexView viewModel)
        {
            if(ModelState.IsValid)
            {
                Association fromForm = viewModel.ProductForm;
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("ProductInfo", new { productId = productId });
            }
            else 
            {
                return ProductInfo(productId);
            }
        }

        [HttpGet("Category")]
        public ViewResult Category()
        {
            ViewBag.Category =_context.Categories.ToList();
            return View("Category");
        }
         [HttpPost("category/newcategory")]
        public IActionResult NewCategory(Category fromForm)
        {
            if (ModelState.IsValid)
            {

                _context.Add(fromForm);
                _context.SaveChanges();
                return RedirectToAction("Category");
            }
            else
            {
                return View("Category");
            }
        }

          [HttpGet("category/{CategoryId}")]
        public IActionResult CategoryInfo(int CategoryId)
        {
            CategoryView ViewModel = new CategoryView()
            {
                RenderCategory = _context.Categories
                    .Include(m => m.CategoryProducts) // but this is a middle table, so
                        .ThenInclude(plm => plm.AllProduct)
                    .FirstOrDefault(m => m.CategoryId == CategoryId),
                // List of Products that this Category has not already been part of
                ToGetCategory = _context.Products
                    .Include(p => p.ProductCategories) 
                    .Where(p => !p.ProductCategories.Any(mk => mk.CategoryId == CategoryId))
                    .ToList()
            };
            
            return View("CategoryInfo", ViewModel);
        }

        [HttpPost("category/{categoryId}/Add")]
        public IActionResult AddProduct(int categoryId, CategoryView viewModel)
        {
            if(ModelState.IsValid)
            {
                Association fromForm = viewModel.CategoryForm;
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("CategoryInfo", new { categoryId = categoryId });
            }
            else 
            {
                return ProductInfo(categoryId);
            }
        }
        }
    }