using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Medicalreferrals.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        [Authorize(Roles = "level1permission")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "level1permission, level2permission, level3permission")]
        public ActionResult ReadPhysicians([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<PhysicianItem> physicianItem = db.PhysicianItems;
                DataSourceResult result = physicianItem.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "level1permission")]
        public ActionResult CreatePhysician()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new Physician();
                    return View("PhysicianTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "level1permission")]
        public ActionResult SavePhysician(Physician physician)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.Physicians.Where(p => p.PhysicianId == physician.PhysicianId).Count();
                    if (cnt == 0)
                    {
                        db.Physicians.Add(physician);
                    }
                    else
                    {
                        db.Physicians.Attach(physician);
                        db.Entry(physician).State = EntityState.Modified;
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

        [Authorize(Roles = "level1permission")]
        public ActionResult UpdatePhysician(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    Physician item = db.Physicians.Find(id);
                    return View("PhysicianTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [Authorize(Roles = "level1permission")]
        public ActionResult DeletePhysician([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Physician()
                        {
                            PhysicianId = Convert.ToInt32(id),
                        };
                        db.Physicians.Attach(item);
                        db.Physicians.Remove(item);

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

        [Authorize(Roles = "level1permission")]
        public ActionResult PhysicianDetail(int id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PhysicianItem physicianItem = db.PhysicianItems.Find(id);
                if (physicianItem == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("PhysicianDetailTemplate", physicianItem);
                }
            }
        }


        private void OrganizeViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;
        }
    }
}