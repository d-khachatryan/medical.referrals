using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ReferralLogItemController : Controller
    {
        // GET: ReferralLogItem
        public ActionResult Index()
        {

            var context = new ApplicationDbContext();
            var lUsers = new List<SelectListItem>();
            lUsers = context.Users.Select(x => new SelectListItem { Text = x.UserName, Value = x.Id.ToString() }).ToList();
            ViewBag.vbUsers = lUsers;

            return View();
        }

        public ActionResult ReadReferralLogItems([DataSourceRequest]DataSourceRequest request, string userId, string startDate, string endDate)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralLogItem> items = from p in db.ReferralLogItems select p;

                if (!string.IsNullOrEmpty(userId))
                {
                    items = items.Where(p => p.Id == userId);
                }

                if (!string.IsNullOrEmpty(startDate))
                {
                    DateTime dt = Convert.ToDateTime(startDate);
                    items = items.Where(p => p.LogDate >= dt);
                }

                if (!string.IsNullOrEmpty(endDate))
                {
                    DateTime dt = Convert.ToDateTime(endDate);
                    items = items.Where(p => p.LogDate <= dt);
                }

                DataSourceResult result = items.ToDataSourceResult(request);
                return Json(result);
            }
        }
    }
}