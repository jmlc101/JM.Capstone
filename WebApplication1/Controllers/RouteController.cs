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
            return View();
        }

        public ActionResult SubmitSearchFilters()
        {
            return View();
        }

        public ActionResult SaveRoute()
        {
            ViewBag.SaveRoute = 1;
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
                string destination = "";// TODO - need to change Destination from saveRouteViewModel to Google API query format.
                string origin = "";// TODO - need to change Origin from saveRouteViewModel to Google API query format.

                List<string> reviews = new List<string>();
                reviews.Add(saveRouteViewModel.Review);

                Route newRoute = new Route
                {
                    RouteName = saveRouteViewModel.RouteName,
                    Origin = origin,
                    Waypoints = waypoints,
                    Destination = destination,
                    Reviews = reviews,
                };// TODO - Why would I need to "Clear a ModelState"?
                context.Routes.Add(newRoute);
                context.SaveChanges();
                return Redirect("/User"); // TODO - NEED to REDIRECT TO A CONFIRMATION PAGE TO VERIFY THE MAPPED ROUTE FOR THE USER!!!!!
            }
            return View(saveRouteViewModel);
        }

        public ActionResult DisplaySelectRoute()
        {
            return View();
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