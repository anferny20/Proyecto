using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            NorthWindContext contexto = new  NorthWindContext();

            List<Models.Categories> lista = (from u in contexto.Categories
                                             select new Models.Categories
                                             {
                                                 CategoryId = u.CategoryId,
                                                 CategoryName = u.CategoryName,
                                                 Description = u.Description,
                                                 Picture = u.Picture


                                             }).ToList();

            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NorthWindContext contexto = new NorthWindContext();
                    Categories categoria = new Categories
                    {
                        CategoryId = model.CategoryId,
                        CategoryName = model.CategoryName,
                        Description = model.Description,                       
                    };


                    contexto.Categories.Add(categoria);
                    contexto.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            NorthWindContext contexto = new NorthWindContext();

            Models.Categories categoria = (from a in contexto.Categories
                                               where a.CategoryId == id
                                               select new Models.Categories
                                               {
                                                   CategoryId = a.CategoryId,
                                                   CategoryName = a.CategoryName,
                                                   Description = a.Description

                                               }).FirstOrDefault();


            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(Models.Categories model)
        {
            if (ModelState.IsValid)
            {
                NorthWindContext contexto = new NorthWindContext();
                Categories categoria = (from a in contexto.Categories
                                       where a.CategoryId == model.CategoryId
                                        select a).FirstOrDefault();
                categoria.CategoryId = model.CategoryId;
                categoria.CategoryName = model.CategoryName;
                categoria.Description = model.Description;
                contexto.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Delete(int id, Models.Categories model)
        {
            NorthWindContext contexto = new NorthWindContext();

            Models.Categories categoria = (from a in contexto.Categories
                                            where a.CategoryId == id
                                               select new Models.Categories
                                               {
                                                   CategoryId = a.CategoryId,
                                                   CategoryName = a.CategoryName,
                                                   Description = a.Description

                                               }).FirstOrDefault();


            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            NorthWindContext contexto = new NorthWindContext();
            try
            {
                Categories categoria = (from a in contexto.Categories
                                         where a.CategoryId == id
                                       select a).FirstOrDefault();
                contexto.Categories.Remove(categoria);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {


            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
