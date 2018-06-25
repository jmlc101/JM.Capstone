﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            User user = context.Users.Single(u => u.Email == HttpContext.Session.GetString("_Email"));

            List<Message> unViewedMessages = new List<Message>();
            foreach (Message message in context.Messages)
            {
                if (message.ReceiverID == user.ID)
                {
                    if (message.Viewed == false)
                    {
                        unViewedMessages.Add(message);
                    }
                }
            }
            if (unViewedMessages.Count > 0)
            {
                string newMessageAlert = string.Format("{0} New!", unViewedMessages.Count);
                ViewBag.NewMessageAlert = newMessageAlert;
            }

            List<FriendRequest> friendrequests = new List<FriendRequest>();
            foreach (FriendRequest friendrequest in context.FriendRequests)
            {
                if (friendrequest.RequestedUserID == user.ID)
                {
                    friendrequests.Add(friendrequest);
                }
            }
            if (friendrequests.Count > 0)
            {
                string friendRequestAlert = string.Format("{0} request!", friendrequests.Count);
                ViewBag.FriendRequestAlert = friendRequestAlert;
            }

            ViewBag.User = user;// TODO - with This I can eliminate the two viewbags below. email and screen name.
            ViewBag.SessionEmail = HttpContext.Session.GetString("_Email");
            ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");
            ViewBag.TrailsBlazed = user.TrailsBlazed;
            ViewBag.ReviewsMade = user.ReviewsMade;
            ViewBag.answer = "yes";

            ViewBag.DbSubmissionAlert = TempData["Alert"];
            

            return View();
        }

        public ActionResult SendFriendRequest(ProfileViewModel profileViewModel)
        {
            User requestingUser = context.Users.Single(u => u.Email == (HttpContext.Session.GetString("_Email")));
            User requestedUser = context.Users.Single(u => u.ScreenName == profileViewModel.ProfileUserScreenName);

            FriendRequest friendRequest = new FriendRequest
            {
                RequestingUserID = requestingUser.ID,
                RequestingUserScreenName = requestingUser.ScreenName,
                RequestedUserID = requestedUser.ID,
                RequestedUserScreenName = requestedUser.ScreenName
            };
            context.FriendRequests.Add(friendRequest);
            context.SaveChanges();

            TempData["Alert"] = "Friend request has been sent!";
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
                List<FriendRequest> getFriendRequests = new List<FriendRequest>();
                foreach (FriendRequest fr in context.FriendRequests)
                {
                    if (fr.RequestedUserID == getUser.ID)
                    {
                        getFriendRequests.Add(fr);
                    }
                }
                getFriendRequests.Reverse();
                if (getFriendRequests.Count() > 0)
                {
                    // TODO - New Mail? Unread Mail? Replied to Mail?
                    ViewBag.FriendRequestList = getFriendRequests;
                }
                ViewBag.User = getUser;// TODO - with This I can eliminate the two viewbags below. email and screen name.
                ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");

                return View("Index");
            }

            return Redirect("/User");
        }

        public ActionResult DenyFriendRequest(int id)
        {
            FriendRequest friendRequest = context.FriendRequests.Single(fr => fr.ID == id);
            context.FriendRequests.Remove(friendRequest);
            context.SaveChanges();

            TempData["Alert"] = "Denied friend request.";
            return Redirect("/User");
        }

        public ActionResult AcceptFriendRequest(ProfileViewModel profileViewModel)
        {
            User requestor = context.Users.Single(u => u.ScreenName == profileViewModel.ProfileUserScreenName);
            User requested = context.Users.Single(u => u.Email == (HttpContext.Session.GetString("_Email")));

            Friendships friendship = new Friendships
            {
                ScreenNameA = requested.ScreenName,
                ScreenNameB = requestor.ScreenName
            };

            context.Friendships.Add(friendship);

            foreach (var request in context.FriendRequests)
            {
                if (request.RequestedUserID == requested.ID)
                {
                    if (request.RequestingUserID == requestor.ID)
                    {
                        context.FriendRequests.Remove(request);
                    }
                }
            }

            context.SaveChanges();

            TempData["Alert"] = "Friend request has been Accepted!";
            return Redirect("/User");
        }

        public ActionResult DisplayFriends()
        {
            User getUser = context.Users.Single(u => u.Email == (HttpContext.Session.GetString("_Email")));
            List<string> friendScreenNames = new List<string>();
            foreach (var friendship in context.Friendships)
            {
                if (friendship.ScreenNameA == getUser.ScreenName)
                {
                    friendScreenNames.Add(friendship.ScreenNameB);
                }
                if (friendship.ScreenNameB == getUser.ScreenName)
                {
                    friendScreenNames.Add(friendship.ScreenNameA);
                }
            }
            friendScreenNames.Reverse();
            ViewBag.FriendsNames = friendScreenNames;
            ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");
            return View("Index");
        }

        public ActionResult Profile(string screenname)
        {
            string userEmail = HttpContext.Session.GetString("_Email");
            if (userEmail is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/User/LogOn");
            }
            User activeUser = context.Users.Single(u => u.Email == userEmail);
            User profilesUser = context.Users.Single(u => u.ScreenName == screenname);

            foreach (var item in context.Friendships)
            {
                if (item.ScreenNameA == profilesUser.ScreenName || item.ScreenNameA == activeUser.ScreenName)
                {
                    if (item.ScreenNameB == profilesUser.ScreenName || item.ScreenNameB == activeUser.ScreenName)
                    {
                        ViewBag.IsFriends = true;
                    }
                }
            }
            ViewBag.ProfileUserScreenName = profilesUser.ScreenName;
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }

        [HttpPost]
        public ActionResult Profile(ProfileViewModel profileViewModel)
        {
            // TODO - Do I need check that ViewModel isValid?
            User profilesUser = context.Users.Single(u => u.ScreenName == profileViewModel.ProfileUserScreenName);
            List<Route> favoriteRoutes = new List<Route>();
            if (profileViewModel.StatsButtonCheck != null)
            {
                ViewBag.Stats = profilesUser;
                ViewBag.TrailsBlazed = profilesUser.TrailsBlazed;
                ViewBag.ReviewsMade = profilesUser.ReviewsMade;
            }
            else if (profileViewModel.FavoriteRoutesButtonCheck != null)
            {
                foreach (UserRoute favorite in context.UserRoutes)
                {
                    if (favorite.UserID == profilesUser.ID)
                    {
                        Route route = context.Routes.Single(r => r.ID == favorite.RouteID);
                        favoriteRoutes.Add(route);
                    }
                }
                ViewBag.FavoriteRoutes = favoriteRoutes;
            }
            ViewBag.IsFriends = true;
            ViewBag.ProfileUserScreenName = profileViewModel.ProfileUserScreenName;
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }

        public ActionResult DisplayMail()
        {
            var email = HttpContext.Session.GetString("_Email");
            User getUser = context.Users.Single(u => u.Email == email);
            if (getUser == null)
            {

            }
            else
            {
                List<Message> getMail = new List<Message>();
                foreach (Message message in context.Messages)
                {
                    if (message.ReceiverID == getUser.ID)
                    {
                        getMail.Add(message);
                        message.Viewed = true;
                        
                    }
                }
                context.SaveChanges();
                getMail.Reverse();
                if (getMail.Count() > 0)
                {
                    // TODO - New Mail? Unread Mail? Replied to Mail?
                    ViewBag.MailList = getMail;
                }
                ViewBag.User = getUser;// TODO - with This I can eliminate the two viewbags below. email and screen name.
                ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");

                TempData["Alert"] = TempData["Alert"];
                ViewBag.DbSubmissionAlert = TempData["Alert"];


                return View("Index");
            }

            return Redirect("/User");
        }

        public ActionResult RemoveMail(int id)
        {
            string email = HttpContext.Session.GetString("_Email");
            User user = context.Users.Single(u => u.Email == email);
            List<Message> existingMessages = new List<Message>();
            var messages = context.Messages.All(m => m.ReceiverID == user.ID);
            foreach (Message message in context.Messages)
            {
                if (message.ReceiverID == user.ID)
                {
                    if (message.ID == id)
                    {
                        existingMessages.Add(message);
                    }
                    
                }
            }
            if (existingMessages.Count != 0)
            {
                foreach (Message message in existingMessages)
                {
                    context.Messages.Remove(message);
                }
                context.SaveChanges();
            }
            return Redirect("/User/DisplayMail");
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

                if ( registerUserViewModel.PhoneNumber != null)
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

                var newSalt = HashHelp.GeneratePassword(10);
                var passwordHash = HashHelp.EncodePassword(registerUserViewModel.Password, newSalt);
                User newUser = new User
                {
                    ScreenName = registerUserViewModel.ScreenName,
                    Email = registerUserViewModel.Email,
                    PasswordHash = passwordHash,
                    HashCode = newSalt,
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhoneNumber = formattedPhoneNumber,
                    TrailsBlazed = 0,
                    ReviewsMade = 0
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

        public IActionResult Remove()// TODO - this is unused so far.
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

        /*
        public IActionResult SendMessage(string profileUserScreenName)
        {
            User recievingUser = context.Users.Single(u => u.ScreenName == profileUserScreenName);
            string sendingUsersEmail = HttpContext.Session.GetString("_Email");
            User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
            ViewBag.SendMessge = "Send Message";
            ViewBag.SendersID = sendingUser.ID;
            ViewBag.RecieversID = recievingUser.ID;
            return View();
        }
        */
        [HttpPost]
        public IActionResult WriteMessage(ProfileViewModel profileViewModel)
        {
            User receivingUser = new User();
            if (profileViewModel.ProfileUserScreenName != null)
            {
                receivingUser = context.Users.Single(u => u.ScreenName == profileViewModel.ProfileUserScreenName);
                string sendingUsersEmail = HttpContext.Session.GetString("_Email");
                User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
                ViewBag.ReceivingUser = receivingUser;
                ViewBag.SendMessge = "Send Message";
                ViewBag.SendersID = sendingUser.ID;
                ViewBag.SendingUserScreenName = sendingUser.ScreenName;
                ViewBag.RecieversID = receivingUser.ID;
                return View();
            }

            /*
            if (profileViewModel.Body != null)
            {
                Message newMessage = new Message
                {

                    CreationTime = DateTime.Now,
                    Body = profileViewModel.Body,
                    ReceiverID = profileViewModel.RecieversID,
                    SendersID = profileViewModel.SendersID
                };

                context.Messages.Add(newMessage);
                context.SaveChanges();
            }
            */
            return View(string.Format("Profile?screenname={0}", receivingUser.ScreenName));
        }
        [HttpPost]
        public IActionResult SendMessage(WriteMessageViewModel writeMessageViewModel)
        {
            if (HttpContext.Session.GetString("_Email") is null)
            {
                return Redirect("/Welcome");
            }
            string sendingUsersEmail = HttpContext.Session.GetString("_Email");
            User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
           
            /*
            if (sendMessageViewModel.SendAMessageButtonCheck == "Send A Message")
            {
                User recievingUser = context.Users.Single(u => u.ScreenName == sendMessageViewModel.ProfileUserScreenName);
                string sendingUsersEmail = HttpContext.Session.GetString("_Email");
                User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
                ViewBag.SendMessge = "Send Message";
                ViewBag.SendersID = sendingUser.ID;
                ViewBag.RecieversID = recievingUser.ID;
                return View();
            }
            */
            if (writeMessageViewModel.Body != null)
            {
                Message newMessage = new Message
                {

                    CreationTime = DateTime.Now,
                    Body = writeMessageViewModel.Body,
                    ReceiverID = writeMessageViewModel.RecieversID,
                    ReceiverScreenName = writeMessageViewModel.ProfileUserScreenName,
                    SendersID = writeMessageViewModel.SendersID,
                    SenderScreenName = sendingUser.ScreenName,
                    Viewed = false
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();
            }

            //return View("/User/Profile/sendMessageViewModel.RecieversID");
            TempData["Alert"] = "Message has been Sent!";
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