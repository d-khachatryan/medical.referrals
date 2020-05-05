using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserRoleController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        private void OrganizeViewBugs()
        {
            var lRoles = new List<SelectListItem>();
            lRoles = context.Roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.vbRoles = lRoles;
        }

        public ActionResult ReadUserRoles([DataSourceRequest]DataSourceRequest request, string Id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<UserRoleItem> userRoles = db.UserRoleItems.Where(p => p.UserId == Id);
                DataSourceResult result = userRoles.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult Create(string id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs();
                    var item = new UserRoleItem();
                    item.UserId = id;
                    return View("UserRoleTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(UserRoleItem userRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    ApplicationUser applicationUser = userManager.FindById(userRole.UserId);
                    IdentityRole role = context.Roles.Where(p => p.Id == userRole.RoleId).First();
                    userManager.AddToRole(applicationUser.Id, role.Name);
                    context.SaveChanges();
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(string userId, string roleName)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                ApplicationUser user = userManager.FindById(userId);
                if (userManager.IsInRole(user.Id, roleName))
                {
                    userManager.RemoveFromRole(user.Id, roleName);
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