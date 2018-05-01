using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RouteController : Controller
    {
        private JMCapstoneDbContext context;
        public RouteController(JMCapstoneDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Route
        public ActionResult Index()
        {
            List<Route> routes = new List<Route>();
            ViewBag.Routes = context.Routes.ToList<Route>();
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }

        public ActionResult SubmitSearchFilters()
        {
            return View();
        }

        public ActionResult SaveRoute()
        {
            ViewBag.SaveRoute = 1;
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }
        // TODO - Make sure User is Logged in in order to save a route! Must check session! 
        // TODO - Make sure User gets to confirm route map before submitting it to database!
        [HttpPost]
        public ActionResult SaveRoute(SaveRouteViewModel saveRouteViewModel)
        {
            if (ModelState.IsValid)
            {
                string waypoints = ""; // TODO - need to change Waypoints from saveRouteViewModel to Google API query format.
                if (saveRouteViewModel.Waypoint1 == null) { }
                else
                { 
                    foreach (char character in saveRouteViewModel.Waypoint1)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint2 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint2)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint3 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint3)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint4 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint4)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint5 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint5)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint6 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint6)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint7 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint7)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint8 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint8)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint9 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint9)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint10 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint10)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint11 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint11)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint12 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint12)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint13 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint13)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint14 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint14)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint15 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint15)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint16 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint16)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint17 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint17)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint18 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint18)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint19 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint19)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint20 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint20)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }

                string destination = "";// TODO - need to change Destination from saveRouteViewModel to Google API query format.
                foreach (char character in saveRouteViewModel.Destination)
                {
                    char item = character;
                    if (item == ' ')
                    {
                        destination = destination + '+';
                    }
                    else
                    {
                        destination = destination + character;
                    }
                }

                string origin = "";// TODO - need to change Origin from saveRouteViewModel to Google API query format.
                foreach (char character in saveRouteViewModel.Origin)
                    {
                    char item = character;
                    if (item == ' ')
                    {
                        origin = origin + '+';
                    }
                    else
                    {
                        origin = origin + character;
                    }
                }

                Route newRoute = new Route
                {
                    RouteName = saveRouteViewModel.RouteName,
                    Origin = origin,
                    Waypoints = waypoints,
                    Destination = destination,
                    Review = saveRouteViewModel.Review, // TODO - change this to a list of User's reviews somehow.
                };// TODO - Why would I need to "Clear a ModelState"?
                context.Routes.Add(newRoute);
                context.SaveChanges();

                ViewBag.Origin = origin; // TODO - I'm not sure I need these 3 lines anymore...
                ViewBag.Waypoints = waypoints;
                ViewBag.Destination = destination;

                return RedirectToAction("DisplaySelectRoute", new { id = newRoute.ID }); ; // TODO - NEED to REDIRECT TO A CONFIRMATION PAGE TO VERIFY THE MAPPED ROUTE FOR THE USER!!!!!
            }
            return View(saveRouteViewModel);
        }

        
        public ActionResult DisplaySelectRoute(int id)
        {
            Route theRoute = context.Routes.Single(c => c.ID == id);
            ViewBag.Origin = theRoute.Origin;
            ViewBag.Waypoints = theRoute.Waypoints;
            ViewBag.Destination = theRoute.Destination;
            ViewBag.Review = theRoute.Review;
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }

        public ActionResult DisplayFavorites()
        {
            ViewBag.Favorites = "";
            return Redirect("/User");
        }

        public ActionResult SaveFavoriteRoute()
        {
            return View();
        }

        public ActionResult RemoveFavoriteRoute()
        {
            return View();
        }

        // TODO - ELIMINATE BAD PATHWAYS BELOW!!!
        // TODO - try rewriting to use the functions given below.
        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}