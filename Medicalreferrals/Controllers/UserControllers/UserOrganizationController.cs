using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class UserOrganizationController : Controller
    {
        private void OrganizeViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;
        }

        public ActionResult ReadUserOrganizations([DataSourceRequest]DataSourceRequest request, string id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<UserOrganizationItem> userOrganization = db.UserOrganizationItems.Where(p => p.Id == id);
                DataSourceResult result = userOrganization.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateUserOrganization(string id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new UserOrganization();
                    item.Id = id;
                    return View("UserOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateUserOrganization(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    UserOrganization item = db.UserOrganizations.Find(id);
                    return View("UserOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteUserOrganization([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new UserOrganization()
                        {
                            UserOrganizationId = Convert.ToInt32(id),
                        };
                        db.UserOrganizations.Attach(item);
                        db.UserOrganizations.Remove(item);
                        db.SaveChanges();
                    }
                }
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveUserOrganization(UserOrganization userOrganization)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.UserOrganizations.Where(p => p.UserOrganizationId == userOrganization.UserOrganizationId).Count();

                    if (cnt == 0)
                    {
                        db.UserOrganizations.Add(userOrganization);
                    }
                    else
                    {
                        db.UserOrganizations.Attach(userOrganization);
                        db.Entry(userOrganization).State = EntityState.Modified;
                    }

                    db.SaveChanges();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}