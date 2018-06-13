using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private JMCapstoneDbContext context;
        private string formattedPhoneNumber;

        public UserController(JMCapstoneDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: User
        public ActionResult Index()
        {
            var existingFriendRequests = context.UserFriendRequests.ToList();
            ViewBag.FRTest = existingFriendRequests;

            string email = HttpContext.Session.GetString("_Email");
            string screenName = HttpContext.Session.GetString("_ScreenName");
            try {
                User getUser = context.Users.Single(u => u.ScreenName == screenName);
            ViewBag.RequestingUser = getUser;
            } catch (System.InvalidOperationException) { }// where is getUser Then?
            if (email is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            /*
            User user = context.Users.Single(u => u.Email == email);
            var exisitngFriendRequests = context.UserFriendRequests.Where(r => r.UserID == user.ID).ToList();

            IList<User> requestingUsers = new List<User>();

            foreach (UserFriendRequest request in exisitngFriendRequests)
            {
                requestingUsers.Add(request.User);
            }
            if (requestingUsers.Count > 0) { 
            ViewBag.ListRequestingUsers = requestingUsers;
            }
            */
            ViewBag.SessionEmail = email;
            ViewBag.SessionScreenName = screenName;
            ViewBag.answer = "yes";

            ViewBag.DbSubmissionAlert = TempData["Alert"];

            /*
            User loggedUser = context.Users.Single(u => u.Email == email);
            var exisitngFriendRequests = context.UserFriendRequests.Where(r => r.User == loggedUser).ToList();

            IList<int> requestingUsers = new List<int>();

            foreach (UserFriendRequest request in exisitngFriendRequests)
            {
                requestingUsers.Add(request.FriendRequest.RequestingUserID);

            }
            if (requestingUsers.Count > 0)
            {
                List<string> screenNames = new List<string>();
                foreach (int userID in requestingUsers)
                {
                    User requestingUser = context.Users.Single(u => u.ID == userID);
                    string userScreenName = requestingUser.ScreenName;
                    screenNames.Add(userScreenName);
                }
                 
                ViewBag.ListRequestingUsers = screenNames;
            }
            */

            return View();
        }

        public ActionResult Profile(string screenname)
        {
            string loggedUserEmail = HttpContext.Session.GetString("_Email");
            if (loggedUserEmail is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/User/LogOn");
            }
            User profilesUser = context.Users.Single(u => u.ScreenName == screenname);
            User loggedUser = context.Users.Single(u => u.Email == loggedUserEmail);
            ViewBag.UserIDB = profilesUser.ID;
            ViewBag.UserIDA = loggedUser.ID;
            ViewBag.ProfileUserScreenName = profilesUser.ScreenName;
            return View();
        }

        public ActionResult SendFriendRequest(int requestedUserID)
        {
            var email = HttpContext.Session.GetString("_Email");
            User requestingUser = context.Users.Single(u => u.Email == email);
            User userRequested = context.Users.Single(u => u.ID == requestedUserID);

            FriendRequest friendRequest = new FriendRequest {
                RequestingUserID = requestingUser.ID
            };
            
            UserFriendRequest userFriendRequest = new UserFriendRequest
            {
                User = userRequested,
                FriendRequest = friendRequest
            };

            context.UserFriendRequests.Add(userFriendRequest);
            context.SaveChanges();

            return Redirect("/User");
        }
        public ActionResult ConfirmFriendRequest(int requestingUserId)
        {
            string sessionEmail = HttpContext.Session.GetString("_Email");
            User requestingUser = context.Users.Single(u => u.ID == requestingUserId);
            User loggedUser = context.Users.Single(u => u.Email == sessionEmail);
            UserUser newUserUser = new UserUser
            {
                UserA = requestingUser,
                UserB = loggedUser,
            };

            context.UserUsers.Add(newUserUser);
            context.SaveChanges();

            return Redirect("/User");
        }
        public ActionResult DenyFriendRequest()
        {
            return Redirect("/User");
        }

        public ActionResult DisplayFriendRequests()
        {
            var email = HttpContext.Session.GetString("_Email");
            User getUser = context.Users.Single(u => u.Email == email);
            if (getUser == null)
            {

            }
            else
            {
                //IList<UserFriendRequest> existingFriendRequests = getUser.UserFriendRequests.ToList();

                IList<UserFriendRequest> existingRequests = context.UserFriendRequests
                    .Where(ur => ur.UserID == getUser.ID).ToList();
                List<string> screenNames = new List<string>();
                foreach (UserFriendRequest userFriendRequest in existingRequests)
                {
                    int friendRequestID = userFriendRequest.FriendRequestID;
                    FriendRequest friendRequest = context.FriendRequests.Single(fr => fr.ID == friendRequestID);
                    int requestingUserID = friendRequest.RequestingUserID;
                    User requestingUser = context.Users.Single(u => u.ID == requestingUserID);
                    string screenName = requestingUser.ScreenName;
                    screenNames.Add(screenName);

                }

                
                


                /*
                foreach (UserFriendRequest friendRequest in existingFriendRequests)
                {
                    int id = friendRequest.FriendRequest.RequestingUserID;
                    int requestingUserId = id;
                    User requestingUser = context.Users.Single(u => u.ID == requestingUserId);
                    users.Add(requestingUser);
                    string userScreenName = requestingUser.ScreenName;
                    screenNames.Add(userScreenName);

                }
                */




                ViewBag.FR = screenNames;
                ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");

                TempData["Alert"] = TempData["Alert"];
                ViewBag.DbSubmissionAlert = TempData["Alert"];
            }


            /*
            ////
            string email = HttpContext.Session.GetString("_Email");
            User user = context.Users.Single(u => u.Email == email);
            var exisitngFriendRequests = context.UserFriendRequests.Where(r => r.UserID == user.ID).ToList();

            IList<User> requestingUsers = new List<User>();

            foreach (UserFriendRequest request in exisitngFriendRequests)
            {
                requestingUsers.Add(request.User);
            }
            if (requestingUsers.Count > 0)
            {
                ViewBag.ListRequestingUsers = requestingUsers;
            }
            ///
            /*
            string email = HttpContext.Session.GetString("_Email");
            User user = context.Users.Single(u => u.Email == email);
            var exisitngFriendRequests = context.UserFriendRequests.Where(r => r.UserID == user.ID).ToList();

            IList<User> requestingUsers = new List<User>();

            foreach (UserFriendRequest request in exisitngFriendRequests)
            {
                requestingUsers.Add(request.User);
            }
            if (requestingUsers.Count > 0)
            {
                ViewBag.ListRequestingUsers = requestingUsers;
                // ViewBag.Favorites = routeNames;
                

            */
            return View("Index");
            
            
            
        }




        public ActionResult DisplayFavorites()
        {
            var email = HttpContext.Session.GetString("_Email");
            User getUser = context.Users.Single(u => u.Email == email);
            if (getUser == null)
            {

            }
            else
            {
                IList<UserRoute> existingFavoriteRelationships = context.UserRoutes
                    .Where(ur => ur.UserID == getUser.ID).ToList();
                List<string> routeNames = new List<string>();
                List<Route> routes = new List<Route>();
                foreach (UserRoute userRoute in existingFavoriteRelationships)
                {
                    int routeID = userRoute.RouteID;
                    Route route = context.Routes.Single(r => r.ID == routeID);
                    routes.Add(route);
                    string routeName = route.RouteName;
                    routeNames.Add(routeName);

                }
                // ViewBag.Favorites = routeNames;
                ViewBag.FavoriteRoutes = routes;
                ViewBag.Favorites = existingFavoriteRelationships;
                ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");

                TempData["Alert"] = TempData["Alert"];
                ViewBag.DbSubmissionAlert = TempData["Alert"];


                return View("Index");
            }

            return Redirect("/User");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost] // TODO - Need Better validation on all entry Fields!!.
        public IActionResult Register(RegisterUserViewModel registerUserViewModel)
        {

            if (ModelState.IsValid)
            {
                int errorCount = 0;

                //Check if "password" and "confirm password" match:
                if (registerUserViewModel.Password != registerUserViewModel.ConfirmPassword)
                {
                    errorCount++;
                    ViewBag.PasswordMatchError = "Passwords do not match";
                }

                // Check if Email is already used in DB.
                IList<User> usersMatchingEmail = context.Users
                    .Where(u => u.Email == registerUserViewModel.Email)
                    .ToList();
                if (usersMatchingEmail.Count > 0)
                {
                    ViewBag.EmailInUse = "Email is already in use.";
                    errorCount++;
                }
                // Check if Screen Name is already used in DB.
                IList<User> usersMatchingScreenName = context.Users
                    .Where(u => u.ScreenName == registerUserViewModel.ScreenName)
                    .ToList();
                if (usersMatchingScreenName.Count > 0)
                {
                    ViewBag.ScreenNameInUse = "Screen Name is already in use.";
                    errorCount++;
                }


                //// stackoverflow.com/questions/5342375/regex-email-validation
                try
                {
                    MailAddress m = new MailAddress(registerUserViewModel.Email);
                }
                catch (FormatException)
                {
                    ViewBag.EmailError = "Invalid Email address.";
                    errorCount++;
                    //return View(registerUserViewModel);
                }
                ////

                if (registerUserViewModel.PhoneNumber != null)
                {

                    ////www.safaribooksonline.com/library/view/regular-expressions-cookbook/9781449327453/ch04s02.html
                    Regex phoneRegex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

                    if (phoneRegex.IsMatch(registerUserViewModel.PhoneNumber))
                    {
                        formattedPhoneNumber = phoneRegex.Replace(registerUserViewModel.PhoneNumber, "($1) $2-$3");
                    }
                    else
                    {
                        // TODO - Invalid phone number ViewBag.error
                        errorCount++;
                        ViewBag.PhoneNumberError = "Invalid Phone Number";
                        //return View(registerUserViewModel);
                    }
                    ////
                }

                if (errorCount > 0)
                {
                    return View(registerUserViewModel);
                }

                var newSalt = HashHelp.GeneratePassword(5);
                var passwordHash = HashHelp.EncodePassword(registerUserViewModel.Password, newSalt);
                /*
                IList<string> friendRequests = new List<string>();
                try
                {
                    User masterUser = context.Users.Single(u => u.ID == 1);
                    friendRequests.Add(masterUser.ScreenName);
                }
                catch (System.InvalidOperationException)
                {
                    User master = new User
                    {
                        ScreenName = "master1",
                        Email = "master1@master1.com",
                        PasswordHash = "1234",
                        HashCode = "",
                        CreationTime = DateTime.Now,
                        ModificationTime = DateTime.Now,
                        PhoneNumber = formattedPhoneNumber
                    };
                    context.Users.Add(master);
                    context.SaveChanges();

                    User masterUser = context.Users.Single(u => u.ID == 1);
                    friendRequests.Add(masterUser.ScreenName);
                }
                */
                User newUser = new User
                {
                    ScreenName = registerUserViewModel.ScreenName,
                    Email = registerUserViewModel.Email,
                    PasswordHash = passwordHash,
                    HashCode = newSalt,
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhoneNumber = formattedPhoneNumber
                };// TODO - Why would I need to "Clear a ModelState"?
                context.Users.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("_Email", registerUserViewModel.Email); // TODO - added as per session guide.
                HttpContext.Session.SetString("_ScreenName", registerUserViewModel.ScreenName);
                return Redirect("/User");
            }
            return View(registerUserViewModel);
        }

        public IActionResult Remove()
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            return View();
        }

        public IActionResult LogOn()
        {
            return View();
        }
        [HttpPost] // TODO - is this password validation location?
        public IActionResult LogOn(LogOnViewModel logOnViewModel)
        {
            if (ModelState.IsValid)
            {
                string email = logOnViewModel.Email;
                string password = logOnViewModel.Password;
                // TODO - if (chkUser == null) {} ....
                //var getUser = (from s in context.ObjRegisterUser where s.UserName == userName || s.EmailId == userName select s).FirstOrDefault(); (((( Just an example for ideas that I copied))
                var getUser = (from s in context.Users where s.Email == email || s.PasswordHash == email select s).FirstOrDefault();
                if (getUser != null)
                {
                    var hashCode = getUser.HashCode;
                    //Password Hasing Process Call Helper Class Method    
                    var encodingPasswordString = HashHelp.EncodePassword(password, hashCode);
                    //Check Login Detail User Name Or Password    
                    var query = (from s in context.Users where (s.Email == email || s.PasswordHash == email) && s.PasswordHash.Equals(encodingPasswordString) select s).FirstOrDefault();
                    if (query != null)
                    {
                        string screenName = getUser.ScreenName;
                        HttpContext.Session.Clear();
                        HttpContext.Session.SetString("_Email", email); // TODO - added as per session guide.
                        HttpContext.Session.SetString("_ScreenName", screenName);
                        return Redirect("/Welcome");
                    }
                    ViewBag.ErrorMessage = "Invalid User Name and/or Password ";
                    return View();
                }
                ViewBag.ErrorMessage = "Invalid User Name and/or Password ";
                return View();
            }
            return View(logOnViewModel);
        }

        public IActionResult LogOff()
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            HttpContext.Session.Clear();
            // TODO - Need a before action handler that checks if user's logged on.
            return Redirect("/User");
        }
        // TODO - ELIMINATE BAD PATHWAYS BELOW!!!
        // TODO - try rewriting to use the functions given below.
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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