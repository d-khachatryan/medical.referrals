using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;

namespace Medicalorganizations.Controllers
{
    [Authorize(Roles = "administrator")]
    public class OrganizationController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadOrganizations([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<OrganizationItem> organizations = db.OrganizationItems;
                DataSourceResult result = organizations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        private void ViewBugs(StoreContext db)
        {
            var lRegions = new List<SelectListItem>();
            lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
            ViewBag.vbRegions = lRegions;

            var lOrganizationTypes = new List<SelectListItem>();
            lOrganizationTypes = db.OrganizationTypes .Select(x => new SelectListItem { Text = x.OrganizationTypeName, Value = x.OrganizationTypeId.ToString() }).ToList();
            ViewBag.vbOrganizationTypes = lOrganizationTypes;

            var lBudgetLines = new List<SelectListItem>();
            lBudgetLines = db.BudgetLines.Select(x => new SelectListItem { Text = x.BudgetLineName , Value = x.BudgetLineId .ToString() }).ToList();
            ViewBag.vbBudgetLines = lBudgetLines;
        }


        public ActionResult CreateOrganization()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    var item = new Organization();
                    return View("OrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }


        public ActionResult UpdateOrganization(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    Organization item = db.Organizations.Find(id);
                    return View("OrganizationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteOrganization([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Organization()
                        {
                            OrganizationId = Convert.ToInt32(id),
                        };
                        db.Organizations.Attach(item);
                        db.Organizations.Remove(item);

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
        public ActionResult SaveOrganization(Organization organization)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.Organizations.Where(p => p.OrganizationId == organization.OrganizationId).Count();
                    if (cnt == 0)
                    {
                        if (organization.OrganizationBudgetLines != null)
                        {
                            foreach (var item in organization.OrganizationBudgetLines)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Organization = organization;
                                    db.OrganizationBudgetLines.Add(item);
                                }
                            }
                        }
                        db.Organizations.Add(organization);
                    }
                    else
                    {
                        if (organization.OrganizationBudgetLines != null)
                        {
                            foreach (var item in organization.OrganizationBudgetLines)
                            {
                                if (item.RecordStatus == 1)
                                {
                                    item.Organization = organization;
                                    db.OrganizationBudgetLines.Add(item);
                                }
                                else if (item.RecordStatus == 2)
                                {
                                    db.OrganizationBudgetLines.Attach(item);
                                    db.Entry(item).State = EntityState.Modified;
                                }
                                else if (item.RecordStatus == 3)
                                {
                                    OrganizationBudgetLine rOrganizationBudgetLine = db.OrganizationBudgetLines.Find(item.OrganizationBudgetLineId);
                                    db.OrganizationBudgetLines.Remove(rOrganizationBudgetLine);
                                }
                            }
                        }
                        db.Organizations.Attach(organization);
                        db.Entry(organization).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    return Json(new { success = true, responseText = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }        

        public ActionResult ReadOrganizationBudgetLineItems([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<OrganizationBudgetLineItem> organizationBudgetLineItems = db.OrganizationBudgetLineItems.Where(p => p.OrganizationId == id);
                DataSourceResult result = organizationBudgetLineItems.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult ReadOrganizationBudgetLines([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<OrganizationBudgetLine> organizationBudgetLines = db.OrganizationBudgetLines.Where(p => p.OrganizationId == id);
                DataSourceResult result = organizationBudgetLines.ToDataSourceResult(request);
                return Json(result);
            }
        }
        
    }
}