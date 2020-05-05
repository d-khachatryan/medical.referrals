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
    public class BudgetController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadBudgetItems([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<BudgetItem> budgets = db.BudgetItems;
                DataSourceResult result = budgets.ToDataSourceResult(request);
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
                    var item = new Budget();
                    return View("BudgetTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Budget", "Create"));
            }
        }

        public ActionResult Update(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    Budget item = db.Budgets.Find(id);
                    return View("BudgetOrganizationTemplate", item);
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
                        var item = new Budget()
                        {
                            BudgetId = Convert.ToInt32(id),
                        };
                        db.Budgets.Attach(item);
                        db.Budgets.Remove(item);

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
        public ActionResult Save(Budget budget)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.Budgets.Where(p => p.BudgetId == budget.BudgetId).Count();
                    if (cnt == 0)
                    {
                        db.Budgets.Add(budget);
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "", BudgetId = budget.BudgetId }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        db.Budgets.Attach(budget);
                        db.Entry(budget).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, responseText = "", BudgetId = budget.BudgetId }, JsonRequestBehavior.AllowGet);
                    }


                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult BudgetOrganizationTemplate()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    var item = new BudgetOrganization();
                    return View("BudgetOrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Budget", "BudgetOrganizationTemplate"));
            }
        }

        public ActionResult ReadBudgetOrganizations([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<BudgetOrganization> budgetOrganizations = db.BudgetOrganizations.Where(p => p.BudgetId == id);
                DataSourceResult result = budgetOrganizations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult ReadBudgetOrganizationItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<BudgetOrganizationItem> budgetOrganizations = db.BudgetOrganizationItems.Where(p => p.BudgetId == id);
                DataSourceResult result = budgetOrganizations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult UpdateBudgetOrganization([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetOrganization> item)
        {
            var entities = new List<BudgetOrganization>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        Organization organization = db.Organizations.Find(itm.OrganizationId);
                        OrganizationType organizationType = db.OrganizationTypes.Find(organization.OrganizationTypeId);
                        var entity = new BudgetOrganization
                        {
                            BudgetOrganizationId = itm.BudgetOrganizationId,
                            BudgetId = itm.BudgetId,
                            OrganizationId = itm.OrganizationId,
                            BudgetCost = itm.BudgetCost,
                            Budget1 = itm.BudgetCost * organizationType.Budget1,
                            Budget2 = itm.BudgetCost * organizationType.Budget2,
                            Budget3 = itm.BudgetCost * organizationType.Budget3,
                            Id = userId,
                            BudgetLineId = itm.BudgetLineId,
                            ChangeDate = itm.ChangeDate,
                            ChangeBaseId = itm.ChangeBaseId 
                        };
                        entities.Add(entity);
                        db.BudgetOrganizations.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;


                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new BudgetOrganization
            {
                BudgetOrganizationId = itm.BudgetOrganizationId,
                BudgetId = itm.BudgetId,
                OrganizationId = itm.OrganizationId,
                BudgetCost = itm.BudgetCost,
                Budget1 = itm.Budget1,
                Budget2 = itm.Budget2,
                Budget3 = itm.Budget3,
                BudgetLineId = itm.BudgetLineId,
                ChangeDate = itm.ChangeDate,
                ChangeBaseId = itm.ChangeBaseId
            }));
        }

        public ActionResult ReadBudgetOrganizationLogItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<BudgetOrganizationLogItem> budgetOrganizationLogs = db.BudgetOrganizationLogItems.Where(p => p.BudgetOrganizationId == id);
                DataSourceResult result = budgetOrganizationLogs.ToDataSourceResult(request);
                return Json(result);
            }
        }
    }
}