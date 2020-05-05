using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ReferralDistributionController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadReferralDistributionItems([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralDistributionItem> referralDistribution = db.ReferralDistributionItems;
                DataSourceResult result = referralDistribution.ToDataSourceResult(request);
                return Json(result);
            }
        }

        private void ViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lOrganizationCodes = new List<SelectListItem>();
            lOrganizationCodes = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationCode, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizationCodes = lOrganizationCodes;

            var lBudgetLines = new List<SelectListItem>();
            lBudgetLines = db.BudgetLines.Select(x => new SelectListItem { Text = x.BudgetLineName, Value = x.BudgetLineId.ToString() }).ToList();
            ViewBag.vbBudgetLines = lBudgetLines;

            var lBudgetLineCodes = new List<SelectListItem>();
            lBudgetLineCodes = db.BudgetLines.Select(x => new SelectListItem { Text = x.BudgetLineCode, Value = x.BudgetLineId.ToString() }).ToList();
            ViewBag.vbBudgetLineCodes = lBudgetLineCodes;

            var lChangeBases = new List<SelectListItem>();
            lChangeBases = db.ChangeBases.Select(x => new SelectListItem { Text = x.ChangeBaseName, Value = x.ChangeBaseId.ToString() }).ToList();
            ViewBag.vbChangeBases = lChangeBases;
        }

        public ActionResult Create()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    var item = new ReferralDistribution();
                    return View("ReferralDistributionTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ReferralDistribution", "Create"));
            }
        }

        public ActionResult Update(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    ReferralDistribution item = db.ReferralDistributions.Find(id);
                    return View("ReferralDistributionOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new ReferralDistribution()
                        {
                            ReferralDistributionId = Convert.ToInt32(id),
                        };
                        db.ReferralDistributions.Attach(item);
                        db.ReferralDistributions.Remove(item);

                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Save(ReferralDistribution referralDistribution)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.ReferralDistributions.Where(p => p.ReferralDistributionId == referralDistribution.ReferralDistributionId).Count();
                    if (cnt == 0)
                    {
                        db.ReferralDistributions.Add(referralDistribution);
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "", ReferralDistributionId = referralDistribution.ReferralDistributionId }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        db.ReferralDistributions.Attach(referralDistribution);
                        db.Entry(referralDistribution).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "", BudgetId = referralDistribution.ReferralDistributionId }, JsonRequestBehavior.AllowGet);
                    }


                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ReferralDistributionOrganizationTemplate()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    var item = new ReferralDistributionOrganization();
                    return View("ReferralDistributionOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ReferralDistribution", "ReferralDistributionOrganizationTemplate"));
            }
        }

        public ActionResult ReadReferralDistributionOrganizations([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralDistributionOrganization> referralDistributionOrganizations = db.ReferralDistributionOrganizations.Where(p => p.ReferralDistributionId == id);
                DataSourceResult result = referralDistributionOrganizations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult ReadReferralDistributionOrganizationItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralDistributionOrganizationItem> referralDistributionOrganizations = db.ReferralDistributionOrganizationItems.Where(p => p.ReferralDistributionId == id);
                DataSourceResult result = referralDistributionOrganizations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult UpdateReferralDistributionOrganization([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralDistributionOrganization> item)
        {
            var entities = new List<ReferralDistributionOrganization>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        Organization organization = db.Organizations.Find(itm.OrganizationId);
                        OrganizationType organizationType = db.OrganizationTypes.Find(organization.OrganizationTypeId);
                        var entity = new ReferralDistributionOrganization
                        {
                            ReferralDistributionOrganizationId = itm.ReferralDistributionOrganizationId,
                            ReferralDistributionId = itm.ReferralDistributionId,
                            OrganizationId = itm.OrganizationId,
                            ReferralDistributionCount = itm.ReferralDistributionCount,
                            Id = userId,
                            BudgetLineId = itm.BudgetLineId,
                            ChangeDate = itm.ChangeDate,
                            ChangeBaseId = itm.ChangeBaseId 
                        };
                        entities.Add(entity);
                        db.ReferralDistributionOrganizations.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                List<ModelErrorCollection> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralDistributionOrganization
            {
                ReferralDistributionOrganizationId = itm.ReferralDistributionOrganizationId,
                ReferralDistributionId = itm.ReferralDistributionId,
                OrganizationId = itm.OrganizationId,
                ReferralDistributionCount = itm.ReferralDistributionCount,
                BudgetLineId = itm.BudgetLineId,
                ChangeDate = itm.ChangeDate,
                ChangeBaseId = itm.ChangeBaseId
            }));
        }

        public ActionResult ReadReferralDistributionOrganizationLogItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralDistributionOrganizationLogItem> referralDistributionOrganizationLogs = db.ReferralDistributionOrganizationLogItems.Where(p => p.ReferralDistributionOrganizationId == id);
                DataSourceResult result = referralDistributionOrganizationLogs.ToDataSourceResult(request);
                return Json(result);
            }
        }
    }
}