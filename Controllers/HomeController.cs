using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChefNDish.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChefNDish.Controllers {
    public class HomeController : Controller {

        private MyContext _context;
        public HomeController (MyContext context) {
            _context = context;
        }

        //********************* GET METHOD

        [HttpGet ("")]
        public IActionResult Index () {
            List<Chef> AllChefs = _context.Chefs
                .Include (c => c.CreatedDishes)
                .ToList ();
            return View (AllChefs);
        }

        [HttpGet ("dishpage")]
        public IActionResult Dishes () {
            List<Dish> AllDishes = _context.Dishes
                .Include (d => d.Creator)
                .ToList ();
            return View (AllDishes);
        }

        [HttpGet ("newchef")]
        public IActionResult AddChef () {
            return View ();
        }

        [HttpGet ("newdish")]
        public IActionResult AddDish () {
            ViewBag.Chefs = _context.Chefs.ToList ();
            return View ();
        }

        //********************* POST METHODS

        [HttpPost ("addchef")]
        public IActionResult NewChef (Chef newChef) {
            if (ModelState.IsValid) {
                Console.WriteLine ($"{newChef.FirstName} {newChef.LastName}\n{newChef.Age()}\n{newChef.Birthday}\nNumber of Dishes: {newChef.CreatedDishes.Count}\n");
                _context.Chefs.Add (newChef);
                _context.SaveChanges ();
                return RedirectToAction ("");
            } else {
                return View ("AddChef");
            }
        }

        [HttpPost ("adddish")]
        public IActionResult NewDish (Dish newDish) {
            if (ModelState.IsValid) {
                Console.WriteLine ($"{newDish.DishName}\n{newDish.Description}\n{newDish.Calories}\n{newDish.Taste}\nChef's id:{newDish.ChefId}\n");
                _context.Dishes.Add (newDish);
                _context.SaveChanges ();
                return RedirectToAction ("");
            } else {
                return View ("AddDish");
            }
        }

    }
}