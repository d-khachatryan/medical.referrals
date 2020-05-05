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
    public class ReferralSocialGroupController : Controller
    {
        private void OrganizeViewBugs(StoreContext db)
        {
            var lSocialGroups = new List<SelectListItem>();
            lSocialGroups = db.SocialGroups.Select(x => new SelectListItem { Text = x.SocialGroupName, Value = x.SocialGroupId.ToString() }).ToList();
            ViewBag.vbSocialGroups = lSocialGroups;
        }

        public ActionResult ReadReferralSocialGroups([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralSocialGroupItem> referralSocialGroups = db.ReferralSocialGroupItems.Where(p => p.ReferralId == id);
                DataSourceResult result = referralSocialGroups.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateReferralSocialGroup(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new ReferralSocialGroup();
                    item.ReferralId = id;
                    return View("ReferralSocialGroupTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateReferralSocialGroup(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    ReferralSocialGroup item = db.ReferralSocialGroups.Find(id);
                    return View("ReferralSocialGroupTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteReferralSocialGroup([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new ReferralSocialGroup()
                        {
                            ReferralSocialGroupId = Convert.ToInt32(id),
                        };
                        db.ReferralSocialGroups.Attach(item);
                        db.ReferralSocialGroups.Remove(item);
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
        public ActionResult SaveReferralSocialGroup(ReferralSocialGroup referralSocialGroup)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.ReferralSocialGroups.Where(p => p.ReferralSocialGroupId == referralSocialGroup.ReferralSocialGroupId).Count();

                    if (cnt == 0)
                    {
                        db.ReferralSocialGroups.Add(referralSocialGroup);
                    }
                    else
                    {
                        db.ReferralSocialGroups.Attach(referralSocialGroup);
                        db.Entry(referralSocialGroup).State = EntityState.Modified;
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