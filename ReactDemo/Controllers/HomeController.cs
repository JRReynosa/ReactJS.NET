using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactDemo.Data;
using ReactDemo.Models;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        // Using Dependency Injection (for simplicity) rather than making a Services folder
        private readonly CommentContext _context;
        public HomeController(CommentContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Comment.AsNoTracking().ToList());
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_context.Comment.AsNoTracking().ToList());
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                // handleSubmit handles validation, but I put this in here anyway
                return RedirectToAction(nameof(Index));
            }
            _context.Add(comment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
