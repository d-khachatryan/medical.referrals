using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserController : Controller
    {
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ApplicationUser> users = context.Users;
            DataSourceResult result = users.ToDataSourceResult(request);
            return Json(result);
        }

        public ActionResult Create()
        {
            try
            {
                var item = new UserItem();
                return View("Create", item);
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(UserItem user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var applicationUser = new ApplicationUser
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PositionName = user.PositionName
                    };
                    IdentityResult result = UserManager.Create(applicationUser, user.Password);
                    if (result.Succeeded)
                    {
                        //return Json("1", JsonRequestBehavior.AllowGet);
                        string code = UserManager.GenerateEmailConfirmationToken(applicationUser.Id);
                        string callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = applicationUser.Id, code = code }, protocol: Request.Url.Scheme);
                        UserManager.SendEmail(applicationUser.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                        return Json("1", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(result.Errors.First(), JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Model is invalid", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Update(string id)
        {
            var model = new UserItem();
            IQueryable<ApplicationUser> q = from user in context.Users where user.Id.Equals(id) select user;
            ApplicationUser applicationUser = q.First();
            model.Id = applicationUser.Id;
            model.UserName = applicationUser.UserName;
            model.Email = applicationUser.Email;
            model.FirstName = applicationUser.FirstName;
            model.LastName = applicationUser.LastName;
            model.PositionName = applicationUser.PositionName;
            return View("Update", model);
        }

        [HttpPost]
        public ActionResult Update(UserItem user)
        {
            try
            {
                ApplicationUser applicationUser = UserManager.FindById(user.Id.ToString());
                if (user != null)
                {
                    applicationUser.Email = user.Email;
                    applicationUser.UserName = user.UserName;
                    applicationUser.FirstName = user.FirstName;
                    applicationUser.LastName = user.LastName;
                    applicationUser.PositionName = user.PositionName;
                    IdentityResult result = UserManager.Update(applicationUser);
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    ApplicationUser user = UserManager.FindById(id);
                    ICollection<IdentityUserLogin> logins = user.Logins;
                    foreach (var login in logins.ToList())
                    {
                        UserManager.RemoveLogin(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }
                    IList<string> rolesForUser = UserManager.GetRoles(id);
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            IdentityResult result = UserManager.RemoveFromRole(user.Id, item);
                        }
                    }
                    UserManager.Delete(user);
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}