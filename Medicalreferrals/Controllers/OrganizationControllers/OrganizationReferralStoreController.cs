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
    public class OrganizationReferralStoreController : Controller
    {
        private void OrganizeViewBugs(StoreContext db)
        {
            var lSocialGroups = new List<SelectListItem>();
            lSocialGroups = db.SocialGroups.Select(x => new SelectListItem { Text = x.SocialGroupName, Value = x.SocialGroupId.ToString() }).ToList();
            ViewBag.vbSocialGroups = lSocialGroups;
        }

        public ActionResult ReadOrganizationReferralStores([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<OrganizationReferralStoreItem> referralSocialGroups = db.OrganizationReferralStoreItems.Where(p => p.OrganizationId == id);
                DataSourceResult result = referralSocialGroups.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateOrganizationReferralStore(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new OrganizationReferralStore();
                    item.OrganizationId = id;
                    return View("OrganizationReferralStoreTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateOrganizationReferralStore(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    OrganizationReferralStore item = db.OrganizationReferralStores.Find(id);
                    return View("OrganizationReferralStoreTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteOrganizationReferralStore([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new OrganizationReferralStore()
                        {
                            OrganizationReferralStoreId = Convert.ToInt32(id),
                        };
                        db.OrganizationReferralStores.Attach(item);
                        db.OrganizationReferralStores.Remove(item);
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
        public ActionResult SaveOrganizationReferralStore(OrganizationReferralStore organizationReferralStore)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.OrganizationReferralStores.Where(p => p.OrganizationReferralStoreId == organizationReferralStore.OrganizationReferralStoreId).Count();

                    if (cnt == 0)
                    {
                        db.OrganizationReferralStores.Add(organizationReferralStore);
                    }
                    else
                    {
                        db.OrganizationReferralStores.Attach(organizationReferralStore);
                        db.Entry(organizationReferralStore).State = EntityState.Modified;
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