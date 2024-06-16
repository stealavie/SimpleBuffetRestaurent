using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NhaHangBuffetPBL3.Models;
using NhaHangBuffetPBL3.Repository;
using NhaHangBuffetPBL3.Repository.IRepository;


namespace NhaHangBuffetPBL3.Areas.Customers.Controllers
{
    [Area("Customers")]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _context;

        public MenuController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Menus
        public IActionResult Index()
        {
            ViewBag.MenuName = (_context.Food.GetAll()).Select(menu => menu.Type).Distinct().ToList();
            ViewBag.Food = _context.Food.GetAll();
            return View();
        }
    }
}
