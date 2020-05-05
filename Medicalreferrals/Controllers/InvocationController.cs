using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;
using Medicalreferrals.DAL;

namespace Medicalreferrals.Controllers
{
    public class InvocationController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult Index1()
        {
            using (var db = new StoreContext())
            {
                //Որոնման ցանկեր
                var lInvocationStatuses = new List<SelectListItem>();
                lInvocationStatuses = db.InvocationStatuses.Select(x => new SelectListItem { Text = x.InvocationStatusName, Value = x.InvocationStatusId.ToString() }).ToList();
                ViewBag.vbInvocationStatuses = lInvocationStatuses;

                var lRegions = new List<SelectListItem>();
                lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
                ViewBag.vbRegions = lRegions;

                var lOrganizations = new List<SelectListItem>();
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lInvocationPurposes = new List<SelectListItem>();
                lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
                ViewBag.vbInvocationPurposes = lInvocationPurposes;
                //Որոնման ցանկեր

                return View();
            }
        }

        [Authorize(Roles = "Invocation2, administrator")]
        public ActionResult Index2()
        {
            using (var db = new StoreContext())
            {
                //Որոնման ցանկեր
                var lInvocationStatuses = new List<SelectListItem>();
                lInvocationStatuses = db.InvocationStatuses.Select(x => new SelectListItem { Text = x.InvocationStatusName, Value = x.InvocationStatusId.ToString() }).ToList();
                ViewBag.vbInvocationStatuses = lInvocationStatuses;

                var lRegions = new List<SelectListItem>();
                lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
                ViewBag.vbRegions = lRegions;

                var lOrganizations = new List<SelectListItem>();
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lInvocationPurposes = new List<SelectListItem>();
                lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
                ViewBag.vbInvocationPurposes = lInvocationPurposes;
                //Որոնման ցանկեր
                return View();
            }
        }

        [Authorize(Roles = "Invocation3, administrator")]
        public ActionResult Index3()
        {
            using (var db = new StoreContext())
            {
                //Որոնման ցանկեր
                var lInvocationStatuses = new List<SelectListItem>();
                lInvocationStatuses = db.InvocationStatuses.Select(x => new SelectListItem { Text = x.InvocationStatusName, Value = x.InvocationStatusId.ToString() }).ToList();
                ViewBag.vbInvocationStatuses = lInvocationStatuses;

                var lRegions = new List<SelectListItem>();
                lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
                ViewBag.vbRegions = lRegions;

                var lOrganizations = new List<SelectListItem>();
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lInvocationPurposes = new List<SelectListItem>();
                lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
                ViewBag.vbInvocationPurposes = lInvocationPurposes;
                //Որոնման ցանկեր
                return View();
            }
        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult ReadInvocations1([DataSourceRequest]DataSourceRequest request, string invocationId,
            string firstName, string lastName,
            string birthDate, string initiationStartDate, string initiationFinishDate,
            string conformationStartDate, string conformationFinishDate,
            string confirmationStartDate, string confirmationFinishDate,
            string invocationStatusId, string invocationPurposeId,
            string organizationId, string regionId)
        {
            using (var db = new StoreContext())
            {
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                IQueryable<InvocationItem> invocations = from p in db.InvocationItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    invocations = invocations.Where(p => p.InvocationId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    invocations = invocations.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    invocations = invocations.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(birthDate))
                {
                    DateTime dt = Convert.ToDateTime(birthDate);
                    invocations = invocations.Where(p => p.BirthDate == dt);
                }
                if (!string.IsNullOrEmpty(initiationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationStartDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(initiationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationFinishDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationStartDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationFinishDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationStartDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationFinishDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(invocationStatusId))
                {
                    int id = Convert.ToInt32(invocationStatusId);
                    invocations = invocations.Where(p => p.InvocationStatusId == id);
                }
                if (!string.IsNullOrEmpty(invocationPurposeId))
                {
                    int id = Convert.ToInt32(invocationPurposeId);
                    invocations = invocations.Where(p => p.InvocationPurposeId == id);
                }
                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    invocations = invocations.Where(p => p.OrganizationId == id);
                }
                if (!string.IsNullOrEmpty(regionId))
                {
                    int id = Convert.ToInt32(regionId);
                    invocations = invocations.Where(p => p.RegionId == id);
                }
                DataSourceResult result = invocations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Invocation2, administrator")]
        public ActionResult ReadInvocations2([DataSourceRequest]DataSourceRequest request, string invocationId,
            string firstName, string lastName,
            string birthDate, string initiationStartDate, string initiationFinishDate,
            string conformationStartDate, string conformationFinishDate,
            string confirmationStartDate, string confirmationFinishDate,
            string invocationStatusId, string invocationPurposeId,
            string organizationId, string regionId)
        {
            using (var db = new StoreContext())
            {
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                IQueryable<InvocationItem> invocations = from p in db.InvocationItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    invocations = invocations.Where(p => p.InvocationId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    invocations = invocations.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    invocations = invocations.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(birthDate))
                {
                    DateTime dt = Convert.ToDateTime(birthDate);
                    invocations = invocations.Where(p => p.BirthDate == dt);
                }
                if (!string.IsNullOrEmpty(initiationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationStartDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(initiationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationFinishDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationStartDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationFinishDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationStartDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationFinishDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(invocationStatusId))
                {
                    int id = Convert.ToInt32(invocationStatusId);
                    invocations = invocations.Where(p => p.InvocationStatusId == id);
                }
                if (!string.IsNullOrEmpty(invocationPurposeId))
                {
                    int id = Convert.ToInt32(invocationPurposeId);
                    invocations = invocations.Where(p => p.InvocationPurposeId == id);
                }
                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    invocations = invocations.Where(p => p.OrganizationId == id);
                }
                if (!string.IsNullOrEmpty(regionId))
                {
                    int id = Convert.ToInt32(regionId);
                    invocations = invocations.Where(p => p.RegionId == id);
                }
                DataSourceResult result = invocations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Invocation3, administrator")]
        public ActionResult ReadInvocations3([DataSourceRequest]DataSourceRequest request, string invocationId,
            string firstName, string lastName,
            string birthDate, string initiationStartDate, string initiationFinishDate,
            string conformationStartDate, string conformationFinishDate,
            string confirmationStartDate, string confirmationFinishDate,
            string invocationStatusId, string invocationPurposeId,
            string organizationId, string regionId, string userName1, string userName2)
        {
            using (var db = new StoreContext())
            {
                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                IQueryable<InvocationItem> invocations = from p in db.InvocationItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    invocations = invocations.Where(p => p.InvocationId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    invocations = invocations.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    invocations = invocations.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(birthDate))
                {
                    DateTime dt = Convert.ToDateTime(birthDate);
                    invocations = invocations.Where(p => p.BirthDate == dt);
                }
                if (!string.IsNullOrEmpty(initiationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationStartDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(initiationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationFinishDate);
                    invocations = invocations.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationStartDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationFinishDate);
                    invocations = invocations.Where(p => p.ConformationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationStartDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(confirmationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationFinishDate);
                    invocations = invocations.Where(p => p.ConfirmationDate <= dt);
                }
                if (!string.IsNullOrEmpty(invocationStatusId))
                {
                    int id = Convert.ToInt32(invocationStatusId);
                    invocations = invocations.Where(p => p.InvocationStatusId == id);
                }
                if (!string.IsNullOrEmpty(invocationPurposeId))
                {
                    int id = Convert.ToInt32(invocationPurposeId);
                    invocations = invocations.Where(p => p.InvocationPurposeId == id);
                }
                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    invocations = invocations.Where(p => p.OrganizationId == id);
                }
                if (!string.IsNullOrEmpty(regionId))
                {
                    int id = Convert.ToInt32(regionId);
                    invocations = invocations.Where(p => p.RegionId == id);
                }
                if (!string.IsNullOrEmpty(userName1))
                {
                    invocations = invocations.Where(p => p.Id.StartsWith(userName1));
                }
                if (!string.IsNullOrEmpty(userName2))
                {
                    invocations = invocations.Where(p => p.ConfirmationUserId.StartsWith(userName2));
                }
                DataSourceResult result = invocations.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Invocation1, Invocation2, Invocation3, administrator")]
        public ActionResult InvocationDetail(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                InvocationItem invocationItem = db.InvocationItems.Find(id);
                if (invocationItem == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("InvocationDetail", invocationItem);
                }
            }
        }

        private void OrganizeViewBugs(StoreContext db)
        {
            var lRegions = new List<SelectListItem>();
            lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
            ViewBag.vbRegions = lRegions;

            var lCommunities = new List<SelectListItem>();
            lCommunities = db.Communities.Select(x => new SelectListItem { Text = x.CommunityName, Value = x.CommunityId.ToString() }).ToList();
            ViewBag.vbCommunities = lCommunities;

            var lOrganizations = new List<SelectListItem>();
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lInvocationPurposes = new List<SelectListItem>();
            lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
            ViewBag.vbInvocationPurposes = lInvocationPurposes;

        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult CreateInvocation()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new InvocationTemplate();
                    item.InvocationId = 0;
                    return View("InvocationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult UpdateInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    //Find invocation record and set nondatabase InvocationTemplate model
                    this.OrganizeViewBugs(db);
                    Invocation invocation = db.Invocations.Find(id);
                    var item = new InvocationTemplate();
                    item.InvocationId = invocation.InvocationId;
                    item.FirstName = invocation.FirstName;
                    item.LastName = invocation.LastName;
                    item.PatronymicName = invocation.PatronymicName;
                    item.BirthDate = invocation.BirthDate;
                    item.ResidentMail = invocation.ResidentMail;
                    item.RegionId = invocation.RegionId;
                    item.CommunityId = invocation.CommunityId;
                    item.Street = invocation.Street;
                    item.Home = invocation.Home;
                    item.Room = invocation.Room;
                    item.InvocationPurposeId = invocation.InvocationPurposeId;
                    item.OrganizationId = invocation.OrganizationId;
                    return View("InvocationTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult DeleteInvocation([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Invocation()
                        {
                            InvocationId = Convert.ToInt32(id),
                        };
                        db.Invocations.Attach(item);
                        db.Invocations.Remove(item);

                        db.SaveChanges();

                        string directory = Server.MapPath("~/FileStorage/Invocation/" + id.ToString());
                        if (Directory.Exists(directory))
                        {
                            Directory.Delete(directory, true);
                        }
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
        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult SaveInvocation(InvocationTemplate invocationTemplate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation;
                    if (invocationTemplate.InvocationId == 0)
                    {

                        invocation = new Invocation();
                        invocation.InvocationId = invocationTemplate.InvocationId;
                        invocation.FirstName = invocationTemplate.FirstName;
                        invocation.LastName = invocationTemplate.LastName;
                        invocation.PatronymicName = invocationTemplate.PatronymicName;
                        invocation.BirthDate = invocationTemplate.BirthDate;
                        invocation.ResidentMail = invocationTemplate.ResidentMail;
                        invocation.RegionId = invocationTemplate.RegionId;
                        invocation.CommunityId = invocationTemplate.CommunityId;
                        invocation.Street = invocationTemplate.Street;
                        invocation.Home = invocationTemplate.Home;
                        invocation.Room = invocationTemplate.Room;
                        invocation.InvocationPurposeId = invocationTemplate.InvocationPurposeId;
                        invocation.OrganizationId = invocationTemplate.OrganizationId;

                        // Nonvisible fields
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InitiationTypeId = 3;
                        invocation.Id = userId;
                        invocation.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();

                        db.Invocations.Add(invocation);
                    }
                    else
                    {

                        invocation = db.Invocations.Find(invocationTemplate.InvocationId);
                        invocation.InvocationId = invocationTemplate.InvocationId;
                        invocation.FirstName = invocationTemplate.FirstName;
                        invocation.LastName = invocationTemplate.LastName;
                        invocation.PatronymicName = invocationTemplate.PatronymicName;
                        invocation.BirthDate = invocationTemplate.BirthDate;
                        invocation.ResidentMail = invocationTemplate.ResidentMail;
                        invocation.RegionId = invocationTemplate.RegionId;
                        invocation.CommunityId = invocationTemplate.CommunityId;
                        invocation.Street = invocationTemplate.Street;
                        invocation.Home = invocationTemplate.Home;
                        invocation.Room = invocationTemplate.Room;
                        invocation.InvocationPurposeId = invocationTemplate.InvocationPurposeId;
                        invocation.OrganizationId = invocationTemplate.OrganizationId;

                        // Nonvisible fields
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InitiationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InitiationTypeId = 3;
                        invocation.Id = userId;
                        invocation.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();

                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                    }
                    db.SaveChanges();

                    //Create folder to store Invocation related files
                    string path = Server.MapPath("~/FileStorage/Invocation/" + invocation.InvocationId.ToString());
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return this.Json(new { statuscode = 1, message = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Invocation", "SaveInvocation"));
            }
        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult RequestConformInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 2;
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.Id = userId;
                        invocation.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը ներկայացվել է համաձայնեցման" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation1, administrator")]
        public ActionResult RequestConfirmInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 4;
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.Id = userId;
                        invocation.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը ներկայացվել է բավարարման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation2, administrator")]
        public ActionResult ConformInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 3;
                        invocation.ConformationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.ConfirmationUserId  = userId;
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը համաձայնեցված է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation3, administrator")]
        public ActionResult ConfirmInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 5;
                        invocation.ConfirmationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.ConfirmationUserId = userId;
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը բավարարված է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation2, Invocation3, administrator")]
        public ActionResult ReturnUpdateInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 6;
                        invocation.ConformationDate = null;
                        invocation.ConfirmationDate = null;
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը վերադարձվել է խմբագրման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation3, administrator")]
        public ActionResult CancelInvocation(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Invocation invocation = db.Invocations.Find(id);
                    if (invocation != null)
                    {
                        invocation.InvocationStatusId = 7;
                        invocation.ConformationDate = null;
                        invocation.ConfirmationDate = null;
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.ConfirmationUserId  = userId;
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Դիմումը չեղարկվել է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation1, Invocation2, Invocation3, administrator")]
        public ActionResult InvocationChart()
        {
            //ViewBag.vbPermissions = new UserPermission().PermissionPattern;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Invocation1, Invocation2, Invocation3, administrator")]
        public ActionResult ReadInvocationChart(string startDate, string finishDate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                    var prmFinishDate = new SqlParameter("@FinishDate", SqlDbType.Date);
                    prmStartDate.Value = Convert.ToDateTime(startDate);
                    prmFinishDate.Value = Convert.ToDateTime(finishDate);
                    List<InvocationChart> invocations = db.Database.SqlQuery<InvocationChart>
                        ("spInvocationChart @StartDate, @FinishDate", prmStartDate, prmFinishDate).ToList();
                    return Json(invocations);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Invocation1, Invocation2, Invocation3, administrator")]
        public ActionResult DownloadFile(string relativeFilePath)
        {

            string filePathName = Server.MapPath(relativeFilePath);
            if (System.IO.File.Exists(filePathName))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(filePathName);
                string contentType = MimeMapping.GetMimeMapping(filePathName);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = Path.GetFileName(relativeFilePath),
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            return HttpNotFound();

        }














        private void InvocationDocumentViewBugs(StoreContext db)
        {
            var lDocumentTypes = new List<SelectListItem>();
            lDocumentTypes = db.DocumentTypes.Select(x => new SelectListItem { Text = x.DocumentTypeName, Value = x.DocumentTypeId.ToString() }).ToList();
            ViewBag.vbDocuments = lDocumentTypes;
        }

        public ActionResult ReadInvocationDocuments([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<InvocationDocumentItem> invocationDocuments = db.InvocationDocumentItems.Where(p => p.InvocationId == id);
                DataSourceResult result = invocationDocuments.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateInvocationDocument(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.InvocationDocumentViewBugs(db);
                    var item = new InvocationDocumentTemplate();
                    item.InvocationId = id;
                    ViewBag.fileName = Guid.NewGuid().ToString();
                    return View("InvocationDocumentTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateInvocationDocument(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.InvocationDocumentViewBugs(db);
                    InvocationDocument invocationDocument = db.InvocationDocuments.Find(id);
                    var item = new InvocationDocumentTemplate();
                    item.InvocationDocumentId = invocationDocument.InvocationDocumentId;
                    item.InvocationId = invocationDocument.InvocationId;
                    item.DocumentTypeId = invocationDocument.DocumentTypeId;
                    item.DocumentGuid = invocationDocument.DocumentGuid;
                    ViewBag.fileName = Guid.NewGuid().ToString();
                    return View("InvocationDocumentTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteInvocationDocument([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        InvocationDocument item = db.InvocationDocuments.Find(Convert.ToInt32(id));
                        db.InvocationDocuments.Attach(item);

                        string fileName = Server.MapPath(item.DocumentURL);
                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Delete(fileName);
                        }

                        db.InvocationDocuments.Remove(item);
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

        public ActionResult UploadInvocationDocumentFile(IEnumerable<HttpPostedFileBase> files, string name, string path)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    string fileName = name + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/FileStorage/Invocation/" + path), fileName);


                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    //Create folder to store Invocation related files
                    string dirPath = Server.MapPath("~/FileStorage/Invocation/" + path);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    file.SaveAs(filePath);
                }
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteInvocationDocumentFile(string name, string path)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/Invocation/" + path), name + ".*");

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }
                }
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveInvocationDocument(InvocationDocumentTemplate invocationDocumentTemplate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/Invocation/" + invocationDocumentTemplate.InvocationId.ToString()), invocationDocumentTemplate.DocumentGuid + ".*");

                    if (invocationDocumentTemplate.InvocationDocumentId == 0)
                    {
                        var invocationDocument = new InvocationDocument();
                        invocationDocument.InvocationId = invocationDocumentTemplate.InvocationId;
                        invocationDocument.DocumentTypeId = invocationDocumentTemplate.DocumentTypeId;
                        invocationDocument.DocumentGuid = invocationDocumentTemplate.DocumentGuid;
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                invocationDocument.DocumentURL = "~/FileStorage/Invocation/" + invocationDocumentTemplate.InvocationId.ToString() + "/" + Path.GetFileName(file);
                            }
                        }
                        invocationDocument.Id = userId;
                        invocationDocument.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.InvocationDocuments.Add(invocationDocument);
                    }
                    else
                    {
                        InvocationDocument invocationDocument = db.InvocationDocuments.Find(invocationDocumentTemplate.InvocationDocumentId);
                        invocationDocument.InvocationId = invocationDocumentTemplate.InvocationId;
                        invocationDocument.DocumentTypeId = invocationDocumentTemplate.DocumentTypeId;
                        invocationDocument.DocumentGuid = invocationDocumentTemplate.DocumentGuid;
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                invocationDocument.DocumentURL = "~/FileStorage/Invocation/" + invocationDocumentTemplate.InvocationId.ToString() + "/" + Path.GetFileName(file);
                            }
                        }
                        invocationDocument.Id = userId;
                        invocationDocument.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.InvocationDocuments.Attach(invocationDocument);
                        db.Entry(invocationDocument).State = EntityState.Modified;
                    }
                    db.SaveChanges();

                    //Clear folder from unbound files
                    string[] allFiles = Directory.GetFiles(Server.MapPath("~/FileStorage/Invocation/" + invocationDocumentTemplate.InvocationId.ToString()));
                    foreach (string fileName in allFiles)
                    {
                        string fn = Path.GetFileNameWithoutExtension(fileName);

                        int fileCnt = db.InvocationDocuments.Where(p => p.DocumentGuid.ToString() == fn).Count();
                        if (fileCnt == 0)
                        {
                            if (System.IO.File.Exists(fileName))
                            {
                                System.IO.File.Delete(fileName);
                            }
                        }
                    }

                    return this.Json(new { statuscode = 1, message = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Invocation", "SaveInvocationDocument"));
            }
        }

        public ActionResult DownloadInvocationDocument(string relativeFilePath)
        {

            string filePathName = Server.MapPath(relativeFilePath);
            if (System.IO.File.Exists(filePathName))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(filePathName);
                string contentType = MimeMapping.GetMimeMapping(filePathName);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = Path.GetFileName(relativeFilePath),
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            return HttpNotFound();

        }
    }
}