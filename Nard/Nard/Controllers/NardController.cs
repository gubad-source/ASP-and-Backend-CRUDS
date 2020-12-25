using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nard.Data;
using Nard.Models;

namespace Nard.Controllers
{
    public class NardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var nards = _context.Nerds.Include(b=>b.Category).ToList();
            return View(nards);
        }
        public IActionResult Create()
        {
            ViewBag.Categories=_context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value=c.Id.ToString()
            }).ToList();
            return View ();
        }
        [HttpPost]
        public IActionResult Create( Nerd nerd)
        {
            if (nerd.Upload == null)
            {
                ModelState.AddModelError("Upload", "Sekil yuklemek mecburidir");
            }
            else
            {
                if (nerd.Upload.ContentType != "image/jpeg" && nerd.Upload.ContentType != "image/gif" && nerd.Upload.ContentType != "image/png")
                {
                    ModelState.AddModelError("Upload", "sekil yalniz jpeg,gif ve ya png formatlarinda ola biler");
                }
                if(nerd.Upload.Length> 1048576)
                {
                    ModelState.AddModelError("Upload", "Sekil 1MB-dan artiq ola bilmez");
                }
            }

            if (ModelState.IsValid)
            {

                var fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetExtension(nerd.Upload.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    nerd.Upload.CopyTo(stream);
                }
                nerd.Photo = fileName;
                _context.Nerds.Add(nerd);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(nerd);
        }

        public IActionResult Edit(int id)
        {
            Nerd nerd = _context.Nerds.Find(id);
            if (nerd == null) return NotFound();
            ViewBag.Categories = _context.Categories.Select(c =>new SelectListItem{
                Text=c.Name,
                Value=c.Id.ToString()
            }).ToList();
            return View(nerd);
        }
        [HttpPost]
        public IActionResult Edit(Nerd nerd)
        {
            if (nerd.Upload != null)
            {
                if (nerd.Upload.ContentType != "image/jpeg" && nerd.Upload.ContentType != "image/gif" && nerd.Upload.ContentType != "image/png")
                {
                    ModelState.AddModelError("Upload", "sekil yalniz jpeg,gif ve ya png formatlarinda ola biler");
                }
                if (nerd.Upload.Length > 1048576)
                {
                    ModelState.AddModelError("Upload", "Sekil 1MB-dan artiq ola bilmez");
                }
            }
            
            if (ModelState.IsValid)
            {
                if(nerd.Upload != null)
                {
                    var oldFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", nerd.Photo);
                    System.IO.File.Delete(oldFile);
                    var fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetExtension(nerd.Upload.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        nerd.Upload.CopyTo(stream);
                    }
                    nerd.Photo = fileName;
                }
               
                _context.Entry(nerd).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
           
            ViewBag.Categories = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            return View(nerd);
        }
        

        public IActionResult Delete(int id)
        {
            Nerd nerd = _context.Nerds.Find(id);
            if (nerd == null) return NotFound();
            var photo =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",nerd.Photo);
            System.IO.File.Delete(photo);
            _context.Nerds.Remove(nerd);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
