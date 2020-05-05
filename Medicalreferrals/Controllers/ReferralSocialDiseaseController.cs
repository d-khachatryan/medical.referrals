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
    public class ReferralSocialDiseaseController : Controller
    {

        private void OrganizeViewBugs(StoreContext db)
        {
            var lSocialDiseases = new List<SelectListItem>();
            lSocialDiseases = db.SocialDiseases.Select(x => new SelectListItem { Text = x.SocialDiseaseName, Value = x.SocialDiseaseId.ToString() }).ToList();
            ViewBag.vbSocialDiseases = lSocialDiseases;
        }

        public ActionResult ReadReferralSocialDiseases([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralSocialDiseaseItem> referralSocialDiseases = db.ReferralSocialDiseaseItems.Where(p => p.ReferralId == id);
                DataSourceResult result = referralSocialDiseases.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateReferralSocialDisease(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new ReferralSocialDisease();
                    item.ReferralId = id;
                    return View("ReferralSocialDiseaseTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateReferralSocialDisease(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    ReferralSocialDisease item = db.ReferralSocialDiseases.Find(id);
                    return View("ReferralSocialDiseaseTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteReferralSocialDisease([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new ReferralSocialDisease()
                        {
                            ReferralSocialDiseaseId = Convert.ToInt32(id),
                        };
                        db.ReferralSocialDiseases.Attach(item);
                        db.ReferralSocialDiseases.Remove(item);
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
        public ActionResult SaveReferralSocialDisease(ReferralSocialDisease referralSocialDisease)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.ReferralSocialDiseases.Where(p => p.ReferralSocialDiseaseId == referralSocialDisease.ReferralSocialDiseaseId).Count();

                    if (cnt == 0)
                    {
                        db.ReferralSocialDiseases.Add(referralSocialDisease);
                    }
                    else
                    {
                        db.ReferralSocialDiseases.Attach(referralSocialDisease);
                        db.Entry(referralSocialDisease).State = EntityState.Modified;
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