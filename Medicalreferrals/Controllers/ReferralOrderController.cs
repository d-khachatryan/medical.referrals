using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Medicalreferrals.Controllers
{
    public class ReferralOrderController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        //[Authorize(Roles = "...")]
        public ActionResult Index1()
        {
            return View();
        }

        //[Authorize(Roles = "...")]
        public ActionResult Index2()
        {
            return View();
        }

        private void ViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

        }

        //[Authorize(Roles = "...")]
        public ActionResult ReadReferralOrders1([DataSourceRequest]DataSourceRequest request, string referralNumber, string referralOrderId)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralOrderItem> referralOrders = from p in db.ReferralOrderItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p ;
                
                if (!string.IsNullOrEmpty(referralNumber))
                {
                    referralOrders = referralOrders.Where(p => p.ReferralNumber == referralNumber);
                }
                if (!string.IsNullOrEmpty(referralOrderId))
                {
                    int id = Convert.ToInt32(referralOrderId);
                    referralOrders = referralOrders.Where(p => p.ReferralOrderId == id);
                }

                DataSourceResult result = referralOrders.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //[Authorize(Roles = "...")]
        public ActionResult ReadReferralOrders2([DataSourceRequest]DataSourceRequest request, string referralNumber, string referralOrderId)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralOrderItem> referralOrders = from p in db.ReferralOrderItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId && p.ReferralOrderStatusId > 1 select p;

                if (!string.IsNullOrEmpty(referralNumber))
                {
                    referralOrders = referralOrders.Where(p => p.ReferralNumber == referralNumber);
                }
                if (!string.IsNullOrEmpty(referralOrderId))
                {
                    int id = Convert.ToInt32(referralOrderId);
                    referralOrders = referralOrders.Where(p => p.ReferralOrderId == id);
                }

                DataSourceResult result = referralOrders.ToDataSourceResult(request);
                return Json(result);
            }
        }


        //[Authorize(Roles = "...")]
        public ActionResult ReadReferrals([DataSourceRequest]DataSourceRequest request, string referralNumber, string confirmationDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralItem> referrals = null;
                DateTime currentDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();

                DateTime? cDate = null;
                if (!string.IsNullOrEmpty(confirmationDate))
                {
                    cDate = DateTime.ParseExact(confirmationDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                IQueryable<ReferralOrderItem> q = from p in db.ReferralOrderItems where p.ReferralNumber == referralNumber && p.ConfirmationDate == cDate select p;
                if (q.Count() == 0) //Referral without order can be ordered
                {
                    //Filter by ConfirmationDate, ValidityDate, ReferralServiceDate
                    referrals = db.ReferralItems.Where(p => p.ConfirmationDate <= currentDate && p.ValidityDate >= currentDate && p.TerminationDate == null);

                    if (!string.IsNullOrEmpty(referralNumber))
                    {
                        referrals = referrals.Where(p => p.ReferralNumber == referralNumber);
                    }
                    else
                    {
                        referrals = referrals.Where(p => p.ReferralId == 0);
                    }

                    if (!string.IsNullOrEmpty(confirmationDate))
                    {

                        referrals = referrals.Where(p => p.ConfirmationDate == cDate);
                    }
                    else
                    {
                        referrals = referrals.Where(p => p.ReferralId == 0);
                    }

                }
                else //Referral with existing order can not be ordered
                {
                    referrals = db.ReferralItems.Where(p => p.ReferralId == 0);
                }

                DataSourceResult result = referrals.ToDataSourceResult(request);
                return Json(result);
            }
        }

        //[Authorize(Roles = "...")]
        public ActionResult ReferralOrderDetail(int? id)
        {
            using (var db = new StoreContext())
            {
                ReferralOrderItem referralOrderItem = db.ReferralOrderItems.Find(id);
                if (referralOrderItem == null)
                {
                    return HttpNotFound(); //need attention
                }
                else
                {
                    return View("ReferralOrderDetail", referralOrderItem);
                }
            }
        }

        //[Authorize(Roles = "...")]
        public ActionResult CreateReferralOrder()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    return View("OrderTemplate");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index1", "Error", new { msg = ex.Message });
            }
        }

        //[Authorize(Roles = "...")]
        public ActionResult UpdateReferral(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    ReferralOrder item = db.ReferralOrders.Find(id);
                    return View("ReferralOrderTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index1", "Error", new { msg = ex.Message });
            }
        }

        //[Authorize(Roles = "...")]
        public ActionResult DeleteReferralOrder([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new ReferralOrder()
                        {
                            ReferralOrderId = Convert.ToInt32(id),
                        };
                        item.Id = userId;
                        item.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Attach(item);
                        db.ReferralOrders.Remove(item);
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

        //[Authorize(Roles = "...")]
        public ActionResult ReferralOrderTemplate(int? id, int? referralId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.ViewBugs(db);
                    if (id == 0)
                    {
                        Referral referral = db.Referrals.Find(referralId);
                        var item = new ReferralOrderTemplate();
                        item.ReferralId = referralId;
                        item.ConfirmationDate = referral.ConfirmationDate;
                        item.ValidityDate = referral.ValidityDate;
                        item.ReferralOrderStatusId = 1;
                        return View("ReferralOrderTemplate", item);
                    }
                    else
                    {
                        ReferralOrderItem referralOrderItem = db.ReferralOrderItems.Find(id);

                        var referralOrderTemplate = new ReferralOrderTemplate();
                        referralOrderTemplate.ReferralOrderId = referralOrderItem.ReferralOrderId;
                        referralOrderTemplate.ReferralId = referralOrderItem.ReferralId;
                        referralOrderTemplate.ReferralOrderDate  = referralOrderItem.ReferralOrderDate;
                        referralOrderTemplate.ConfirmationDate = referralOrderItem.ConfirmationDate;
                        referralOrderTemplate.ConfirmOrderDate = referralOrderItem.ConfirmOrderDate;
                        referralOrderTemplate.OrganizationId = referralOrderItem.OrganizationId;
                        referralOrderTemplate.ValidityDate = referralOrderItem.ValidityDate;
                        referralOrderTemplate.ReferralOrderStatusId = referralOrderItem.ReferralOrderStatusId;
                        return View("ReferralOrderTemplate", referralOrderTemplate);
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "...")]
        public ActionResult SaveReferralOrder(ReferralOrderTemplate referralOrderTemplate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    
                    int? cnt = db.ReferralOrderItems.Where(p => p.ReferralOrderId == referralOrderTemplate.ReferralOrderId).Count();
                    if (cnt == 0)
                    {
                        var referralOrder = new ReferralOrder();
                        referralOrder.ReferralOrderId = referralOrderTemplate.ReferralOrderId;
                        referralOrder.ReferralId = referralOrderTemplate.ReferralId;
                        referralOrder.ConfirmOrderDate = referralOrderTemplate.ConfirmOrderDate;
                        referralOrder.ReferralOrderDate = referralOrderTemplate.ReferralOrderDate;
                        referralOrder.OrganizationId = referralOrderTemplate.OrganizationId;
                        referralOrder.ReferralOrderStatusId  = 1;
                        referralOrder.Id = userId;
                        referralOrder.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Add(referralOrder);
                    }
                    else
                    {
                        ReferralOrder item = db.ReferralOrders.Find(referralOrderTemplate.ReferralOrderId);
                        item.ReferralId = referralOrderTemplate.ReferralId;
                        item.ConfirmOrderDate = referralOrderTemplate.ConfirmOrderDate;
                        item.ReferralOrderDate = referralOrderTemplate.ReferralOrderDate;
                        item.OrganizationId = referralOrderTemplate.OrganizationId;
                        item.ReferralOrderStatusId = referralOrderTemplate.ReferralOrderStatusId;
                        item.Id = userId;
                        item.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.Entry(item).State = EntityState.Modified;
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

        //[Authorize(Roles = "level1permission")]
        public ActionResult RequestConfirmReferralOrder(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReferralOrder referralOrder = db.ReferralOrders.Find(id);
                    if (referralOrder != null)
                    {
                        referralOrder.ReferralOrderStatusId = 2;                        
                        referralOrder.Id = userId;
                        referralOrder.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Attach(referralOrder);
                        db.Entry(referralOrder).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Գործողությունը կատարված է: Ուղեգիրը ուղարկվել է հաստատման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //[Authorize(Roles = "level3permission")]
        public ActionResult ConfirmReferralOrder(int? id)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    ReferralOrder referralOrder = db.ReferralOrders.Find(id);
                    if (referralOrder != null)
                    {
                        referralOrder.ReferralOrderStatusId = 3;                        
                        referralOrder.ConfirmationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referralOrder.ConfirmationUserId = userId;
                        referralOrder.Id = userId;
                        referralOrder.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Attach(referralOrder);
                        db.Entry(referralOrder).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Գործողությունը կատարված է: Ուղեգիրը հաստատված է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //[Authorize(Roles = "level2permission,level3permission")]
        public ActionResult ReturnUpdateReferralOrder(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReferralOrder referralOrder = db.ReferralOrders.Find(id);
                    if (referralOrder != null)
                    {
                        referralOrder.ReferralOrderStatusId = 4;
                        referralOrder.ConfirmationDate = null;
                        referralOrder.Id = userId;
                        referralOrder.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Attach(referralOrder);
                        db.Entry(referralOrder).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Գործողությունը կատարված է: Ուղեգիրը վերադարձվել է խմբագրման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //[Authorize(Roles = "level3permission")]
        public ActionResult CancelReferralOrder(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReferralOrder referralOrder = db.ReferralOrders.Find(id);
                    if (referralOrder != null)
                    {
                        referralOrder.ReferralOrderStatusId = 5;
                        referralOrder.ConfirmationDate = null;
                        referralOrder.ConfirmationUserId = userId;
                        referralOrder.Id = userId;
                        referralOrder.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.ReferralOrders.Attach(referralOrder);
                        db.Entry(referralOrder).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Գործողությունը կատարված է: Ուղեգիրը չեղարկվել է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}