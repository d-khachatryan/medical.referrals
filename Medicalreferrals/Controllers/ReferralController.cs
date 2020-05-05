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
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using Microsoft.AspNet.Identity;

namespace Medicalreferrals.Controllers
{
    public class ReferralController : Controller
    {
        readonly string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult Index1()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = (from p in db.Organizations select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lReferralOrganizations = new List<SelectListItem>();
                lReferralOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbReferralOrganizations = lReferralOrganizations;

                var lReferralPurposes = new List<SelectListItem>();
                lReferralPurposes = (from p in db.ReferralPurposes select p).Select(x => new SelectListItem { Text = x.ReferralPurposeName, Value = x.ReferralPurposeId.ToString() }).ToList();
                ViewBag.vbReferralPurposes = lReferralPurposes;
            }

            return View();
        }

        [Authorize(Roles = "Referral2, administrator")]
        public ActionResult Index2()
        {
            using (var db = new StoreContext())
            {
                var lOrganizations = new List<SelectListItem>();
                lOrganizations = (from p in db.Organizations select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbOrganizations = lOrganizations;

                var lReferralOrganizations = new List<SelectListItem>();

                lReferralOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
                ViewBag.vbReferralOrganizations = lReferralOrganizations;

                var lReferralPurposes = new List<SelectListItem>();
                lReferralPurposes = (from p in db.ReferralPurposes select p).Select(x => new SelectListItem { Text = x.ReferralPurposeName, Value = x.ReferralPurposeId.ToString() }).ToList();
                ViewBag.vbReferralPurposes = lReferralPurposes;
            }

            return View();
        }

        [Authorize(Roles = "Referral3, administrator")]
        public ActionResult Index3()
        {
            using (var db = new StoreContext())
            {
                var lReferralStatuses = new List<SelectListItem>();
                lReferralStatuses = (from p in db.ReferralStatuses select p).Select(x => new SelectListItem { Text = x.ReferralStatusName, Value = x.ReferralStatusId.ToString() }).ToList();
                ViewBag.vbReferralStatuses = lReferralStatuses;

                var lReferralPurposes = new List<SelectListItem>();
                lReferralPurposes = (from p in db.ReferralPurposes select p).Select(x => new SelectListItem { Text = x.ReferralPurposeName, Value = x.ReferralPurposeId.ToString() }).ToList();
                ViewBag.vbReferralPurposes = lReferralPurposes;
            }

            return View();
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult Index4()
        {
            return View();
        }

        
        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult ReadReferrals1([DataSourceRequest]DataSourceRequest request, string referralId,
            string firstName, string lastName, string birthdate,
            string invocationId, string referralPurposeId, string referralOrganizationId,
            string initiationStartDate, string initiationFinishDate,
            string conformationStartDate, string conformationFinishDate,
            string confirmationStartDate, string confirmationFinishDate,
            string serviceStartDate, string serviceFinishDate,
            string organizationId)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ReferralItem> referrals = db.ReferralItems;
                //IQueryable<ReferralItem> referrals = from p in db.ReferralItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(referralId))
                {
                    int id = Convert.ToInt32(referralId);
                    referrals = referrals.Where(p => p.ReferralId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    referrals = referrals.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    referrals = referrals.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(birthdate))
                {
                    DateTime dt = Convert.ToDateTime(birthdate);
                    referrals = referrals.Where(p => p.BirthDate >= dt);
                }
                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    referrals = referrals.Where(p => p.InvocationId == id);
                }
                //if (!string.IsNullOrEmpty(referralPurposeId))
                //{
                //    int id = Convert.ToInt32(referralPurposeId);
                //    referrals = referrals.Where(p => p.ReferralPurposeId == id);
                //}

                if (!string.IsNullOrEmpty(referralOrganizationId))
                {
                    int id = Convert.ToInt32(referralOrganizationId);
                    referrals = referrals.Where(p => p.ReferralOrganizationId == id);
                }
                if (!string.IsNullOrEmpty(initiationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationStartDate);
                    referrals = referrals.Where(p => p.InitiationDate >= dt);
                }
                if (!string.IsNullOrEmpty(initiationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationFinishDate);
                    referrals = referrals.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationStartDate);
                    referrals = referrals.Where(p => p.ConformationDate >= dt);
                }
                if (!string.IsNullOrEmpty(conformationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationFinishDate);
                    referrals = referrals.Where(p => p.ConformationDate <= dt);
                }

                if (!string.IsNullOrEmpty(confirmationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationStartDate);
                    referrals = referrals.Where(p => p.ConfirmationDate >= dt);
                }
                if (!string.IsNullOrEmpty(confirmationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationFinishDate);
                    referrals = referrals.Where(p => p.ConfirmationDate <= dt);
                }

                if (!string.IsNullOrEmpty(serviceStartDate))
                {
                    DateTime dt = Convert.ToDateTime(serviceStartDate);
                    referrals = referrals.Where(p => p.TerminationDate >= dt);
                }
                if (!string.IsNullOrEmpty(serviceFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(serviceFinishDate);
                    referrals = referrals.Where(p => p.TerminationDate <= dt);
                }
                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    referrals = referrals.Where(p => p.OrganizationId == id);
                }
                DataSourceResult result = referrals.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral2, administrator")]
        public ActionResult ReadReferrals2([DataSourceRequest]DataSourceRequest request,
            string referralId,
            string firstName, string lastName, string birthdate,
            string invocationId, string referralPurposeId, string referralOrganizationId,
            string initiationStartDate, string initiationFinishDate,
            string conformationStartDate, string conformationFinishDate,
            string confirmationStartDate, string confirmationFinishDate,
            string serviceStartDate, string serviceFinishDate,
            string organizationId)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ReferralItem> referrals = db.ReferralItems;
                //IQueryable<ReferralItem> referrals = from p in db.ReferralItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(referralId))
                {
                    int id = Convert.ToInt32(referralId);
                    referrals = referrals.Where(p => p.ReferralId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    referrals = referrals.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    referrals = referrals.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(birthdate))
                {
                    DateTime dt = Convert.ToDateTime(birthdate);
                    referrals = referrals.Where(p => p.BirthDate >= dt);
                }
                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    referrals = referrals.Where(p => p.InvocationId == id);
                }
                //if (!string.IsNullOrEmpty(referralPurposeId))
                //{
                //    int id = Convert.ToInt32(referralPurposeId);
                //    referrals = referrals.Where(p => p.ReferralPurposeId == id);
                //}

                if (!string.IsNullOrEmpty(referralOrganizationId))
                {
                    int id = Convert.ToInt32(referralOrganizationId);
                    referrals = referrals.Where(p => p.ReferralOrganizationId == id);
                }
                if (!string.IsNullOrEmpty(initiationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationStartDate);
                    referrals = referrals.Where(p => p.InitiationDate >= dt);
                }
                if (!string.IsNullOrEmpty(initiationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(initiationFinishDate);
                    referrals = referrals.Where(p => p.InitiationDate <= dt);
                }
                if (!string.IsNullOrEmpty(conformationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationStartDate);
                    referrals = referrals.Where(p => p.ConformationDate >= dt);
                }
                if (!string.IsNullOrEmpty(conformationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(conformationFinishDate);
                    referrals = referrals.Where(p => p.ConformationDate <= dt);
                }

                if (!string.IsNullOrEmpty(confirmationStartDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationStartDate);
                    referrals = referrals.Where(p => p.ConfirmationDate >= dt);
                }
                if (!string.IsNullOrEmpty(confirmationFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(confirmationFinishDate);
                    referrals = referrals.Where(p => p.ConfirmationDate <= dt);
                }

                if (!string.IsNullOrEmpty(serviceStartDate))
                {
                    DateTime dt = Convert.ToDateTime(serviceStartDate);
                    referrals = referrals.Where(p => p.TerminationDate >= dt);
                }
                if (!string.IsNullOrEmpty(serviceFinishDate))
                {
                    DateTime dt = Convert.ToDateTime(serviceFinishDate);
                    referrals = referrals.Where(p => p.TerminationDate <= dt);
                }
                if (!string.IsNullOrEmpty(organizationId))
                {
                    int id = Convert.ToInt32(organizationId);
                    referrals = referrals.Where(p => p.OrganizationId == id);
                }
                DataSourceResult result = referrals.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral3, administrator")]
        public ActionResult ReadReferrals3([DataSourceRequest]DataSourceRequest request, string referralId,
            string firstName, string lastName, string birthdate,
            string invocationId, string referralPurposeId, string referralStatusId,
            string userName1, string userName2)
        {
            using (var db = new StoreContext())
            {

                IQueryable<ReferralItem> referrals = db.ReferralItems;
                //IQueryable<ReferralItem> referrals = from p in db.ReferralItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(referralId))
                {
                    int id = Convert.ToInt32(referralId);
                    referrals = referrals.Where(p => p.ReferralId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    referrals = referrals.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    referrals = referrals.Where(p => p.LastName.StartsWith(lastName));
                }

                if (!string.IsNullOrEmpty(invocationId))
                {
                    int id = Convert.ToInt32(invocationId);
                    referrals = referrals.Where(p => p.InvocationId == id);
                }
                if (!string.IsNullOrEmpty(referralStatusId))
                {
                    int id = Convert.ToInt32(referralStatusId);
                    referrals = referrals.Where(p => p.ReferralStatusId == id);
                }
                if (!string.IsNullOrEmpty(userName1))
                {
                    referrals = referrals.Where(p => p.UserName.StartsWith(userName1));
                }
                if (!string.IsNullOrEmpty(userName2))
                {
                    referrals = referrals.Where(p => p.ConformationUserName.StartsWith(userName2));
                }
                DataSourceResult result = referrals.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferrals4([DataSourceRequest]DataSourceRequest request, string referralId,
            string firstName, string lastName, string startDate, string finishDate
            )
        {
            using (var db = new StoreContext())
            {

                IQueryable<ReferralItem> referrals = db.ReferralItems;
                //IQueryable<ReferralItem> referrals = from p in db.ReferralItems join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p;
                if (!string.IsNullOrEmpty(referralId))
                {
                    int id = Convert.ToInt32(referralId);
                    referrals = referrals.Where(p => p.ReferralId == id);
                }
                if (!string.IsNullOrEmpty(firstName))
                {
                    referrals = referrals.Where(p => p.FirstName.StartsWith(firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    referrals = referrals.Where(p => p.LastName.StartsWith(lastName));
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    DateTime dt = Convert.ToDateTime(startDate);
                    referrals = referrals.Where(p => p.ReferralDate >= dt);
                }
                if (!string.IsNullOrEmpty(finishDate))
                {
                    DateTime dt = Convert.ToDateTime(finishDate);
                    referrals = referrals.Where(p => p.ReferralDate <= dt);
                }
                DataSourceResult result = referrals.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult OrganizationInfo([DataSourceRequest]DataSourceRequest request, string id)
        {
            using (var db = new StoreContext())
            {
                int? organizationId = Convert.ToInt32(id);
                IQueryable<OrganizationItem> query = from c in db.OrganizationItems
                                                     where c.OrganizationId == organizationId
                                                     select c;
                DataSourceResult result = query.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral1, Referral2, Referral3, Referral4, administrator")]
        public ActionResult ReadReferralOrders([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralOrderItem> referralOrders = db.ReferralOrderItems.Where(p => p.ReferralId == id);
                DataSourceResult result = referralOrders.ToDataSourceResult(request);
                return Json(result);
            }
        }


        [Authorize(Roles = "Referral1, Referral2, Referral3, Referral4, administrator")]
        public ActionResult ReferralDetail(int? id)
        {
            using (var db = new StoreContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ReferralItem referralItem = db.ReferralItems.Find(id);
                if (referralItem == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(referralItem);
                }
            }
        }

        private void OrganizeViewBugs(StoreContext db, int? referralId)
        {
            var lIdentificatorTypes = new List<SelectListItem>();
            lIdentificatorTypes = db.IdentificatorTypes.Select(x => new SelectListItem { Text = x.IdentificatorTypeName, Value = x.IdentificatorTypeId.ToString() }).ToList();
            ViewBag.vbIdentificatorTypes = lIdentificatorTypes;

            var lRegions = new List<SelectListItem>();
            lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
            ViewBag.vbRegions = lRegions;

            var lCommunities = new List<SelectListItem>();
            lCommunities = db.Communities.Select(x => new SelectListItem { Text = x.CommunityName, Value = x.CommunityId.ToString() }).ToList();
            ViewBag.vbCommunities = lCommunities;

            var lOrganizations = new List<SelectListItem>();

            lOrganizations = (from p in db.Organizations join o in db.UserOrganizationItems on p.OrganizationId equals o.OrganizationId where o.Id == userId select p).Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lPhysicians = new List<SelectListItem>();
            lPhysicians = db.Physicians.Select(x => new SelectListItem { Text = x.FirstName, Value = x.PhysicianId.ToString() }).ToList();
            ViewBag.vbPhysicians = lPhysicians;

            var lOrganizationHeads = new List<SelectListItem>();
            lOrganizationHeads = db.OrganizationHeads.Select(x => new SelectListItem { Text = x.FirstName, Value = x.OrganizationHeadId.ToString() }).ToList();
            ViewBag.vbOrganizationHeads = lOrganizationHeads;

            var lDiagnoses = new List<SelectListItem>();
            lDiagnoses = db.Diagnoses.Select(x => new SelectListItem { Text = x.DiagnoseName, Value = x.DiagnoseId.ToString() }).ToList();
            ViewBag.vbDiagnoses = lDiagnoses;

            var lOutcomes = new List<SelectListItem>();
            lOutcomes = db.Outcomes.Select(x => new SelectListItem { Text = x.OutcomeName, Value = x.OutcomeId.ToString() }).ToList();
            ViewBag.vbOutcomes = lOutcomes;

            var lInvocations = new List<SelectListItem>();
            var prmUserId = new SqlParameter("@UserId", SqlDbType.NVarChar);
            var prmReferralId = new SqlParameter("@ReferralId", SqlDbType.Int);
            prmUserId.Value = userId;
            prmReferralId.Value = referralId;
            lInvocations = db.Database.SqlQuery<InvocationItem>("spUnboundInvocation @UserId, @ReferralId", prmUserId, prmReferralId).ToList().Select(x => new SelectListItem { Text = x.InvocationNumber, Value = x.InvocationId.ToString() }).ToList();
            ViewBag.vbInvocations = lInvocations;
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult CreateReferral()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db, 0);
                    var item = new ReferralTemplate();
                    return View("ReferralTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult UpdateReferral(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db, id);
                    Referral referral = db.Referrals.Find(id);
                    var referralTemplate = new ReferralTemplate();

                    referralTemplate.ReferralId = referral.ReferralId;
                    referralTemplate.FirstName = referral.FirstName;
                    referralTemplate.LastName = referral.LastName;
                    referralTemplate.PatronymicName = referral.PatronymicName;
                    referralTemplate.BirthDate = referral.BirthDate;
                    referralTemplate.IdentificatorTypeId = referral.IdentificatorTypeId;
                    referralTemplate.Identificator = referral.Identificator;
                    referralTemplate.Phone = referral.Phone;
                    referralTemplate.ResidentMail = referral.ResidentMail;
                    referralTemplate.ResidentRegionId = referral.ResidentRegionId;
                    referralTemplate.ResidentCommunityId = referral.ResidentRegionId;
                    referralTemplate.ResidentStreet = referral.ResidentStreet;
                    referralTemplate.ResidentHome = referral.ResidentHome;
                    referralTemplate.ResidentRoom = referral.ResidentRoom;
                    referralTemplate.HabitantRegionId = referral.HabitantRegionId;
                    referralTemplate.HabitantCommunityId = referral.HabitantCommunityId;
                    referralTemplate.HabitantStreet = referral.HabitantStreet;
                    referralTemplate.HabitantHome = referral.HabitantHome;
                    referralTemplate.HabitantRoom = referral.HabitantRoom;
                    referralTemplate.ReferralOrganizationId = referral.ReferralOrganizationId;
                    referralTemplate.ReferralOrganizationCode = referral.ReferralOrganizationCode;
                    referralTemplate.ReferralOrganizationLocation = referral.ReferralOrganizationLocation;
                    referralTemplate.ReferralOrganizationPhone = referral.ReferralOrganizationPhone;
                    referralTemplate.PreliminaryDiagnose = referral.PreliminaryDiagnose;
                    referralTemplate.ReferralPurpose1 = referral.ReferralPurpose1;
                    referralTemplate.ReferralPurpose2 = referral.ReferralPurpose2;
                    referralTemplate.ReferralPurpose3 = referral.ReferralPurpose3;
                    referralTemplate.ReferralPurpose3Description = referral.ReferralPurpose3Description;
                    referralTemplate.ReferralPurpose4 = referral.ReferralPurpose4;
                    referralTemplate.ReferralPurpose5 = referral.ReferralPurpose5;
                    referralTemplate.ReferralPurpose6 = referral.ReferralPurpose6;
                    referralTemplate.ReferralPurpose7 = referral.ReferralPurpose7;
                    referralTemplate.ReferralPurpose7Description = referral.ReferralPurpose7Description;
                    referralTemplate.SocialBenefit = referral.SocialBenefit;
                    referralTemplate.SocialBenefitDescription = referral.SocialBenefitDescription;
                    referralTemplate.PhysicianId = referral.PhysicianId;
                    referralTemplate.PhysicianCode = referral.PhysicianCode;
                    referralTemplate.HeadName = referral.HeadName;
                    referralTemplate.Comment = referral.Comment;
                    referralTemplate.InvocationId = referral.InvocationId;


                    return View("ReferralTemplate", referralTemplate);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult DeleteReferral([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        var item = new Referral()
                        {
                            ReferralId = Convert.ToInt32(id),
                        };
                        db.Referrals.Attach(item);
                        db.Referrals.Remove(item);

                        db.SaveChanges();

                        string directory = Server.MapPath("~/App_Data/" + id.ToString());
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
        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult SaveReferral(ReferralTemplate referralTemplate)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral;
                    if (referralTemplate.ReferralId == 0)
                    {
                        referral = new Referral();

                        referral.ReferralId = referralTemplate.ReferralId;
                        referral.FirstName = referralTemplate.FirstName;
                        referral.LastName = referralTemplate.LastName;
                        referral.PatronymicName = referralTemplate.PatronymicName;
                        referral.BirthDate = referralTemplate.BirthDate;
                        referral.IdentificatorTypeId = referralTemplate.IdentificatorTypeId;
                        referral.Identificator = referralTemplate.Identificator;
                        referral.Phone = referralTemplate.Phone;
                        referral.ResidentMail = referralTemplate.ResidentMail;
                        referral.ResidentRegionId = referralTemplate.ResidentRegionId;
                        referral.ResidentCommunityId = referralTemplate.ResidentRegionId;
                        referral.ResidentStreet = referralTemplate.ResidentStreet;
                        referral.ResidentHome = referralTemplate.ResidentHome;
                        referral.ResidentRoom = referralTemplate.ResidentRoom;
                        referral.HabitantRegionId = referralTemplate.HabitantRegionId;
                        referral.HabitantCommunityId = referralTemplate.HabitantCommunityId;
                        referral.HabitantStreet = referralTemplate.HabitantStreet;
                        referral.HabitantHome = referralTemplate.HabitantHome;
                        referral.HabitantRoom = referralTemplate.HabitantRoom;
                        referral.ReferralOrganizationId = referralTemplate.ReferralOrganizationId;
                        referral.ReferralOrganizationCode = referralTemplate.ReferralOrganizationCode;
                        referral.ReferralOrganizationLocation = referralTemplate.ReferralOrganizationLocation;
                        referral.ReferralOrganizationPhone = referralTemplate.ReferralOrganizationPhone;
                        referral.PreliminaryDiagnose = referralTemplate.PreliminaryDiagnose;
                        referral.ReferralPurpose1 = referralTemplate.ReferralPurpose1;
                        referral.ReferralPurpose2 = referralTemplate.ReferralPurpose2;
                        referral.ReferralPurpose3 = referralTemplate.ReferralPurpose3;
                        referral.ReferralPurpose3Description = referralTemplate.ReferralPurpose3Description;
                        referral.ReferralPurpose4 = referralTemplate.ReferralPurpose4;
                        referral.ReferralPurpose5 = referralTemplate.ReferralPurpose5;
                        referral.ReferralPurpose6 = referralTemplate.ReferralPurpose6;
                        referral.ReferralPurpose7 = referralTemplate.ReferralPurpose7;
                        referral.ReferralPurpose7Description = referralTemplate.ReferralPurpose7Description;
                        referral.SocialBenefit = referralTemplate.SocialBenefit;
                        referral.SocialBenefitDescription = referralTemplate.SocialBenefitDescription;
                        referral.PhysicianId = referralTemplate.PhysicianId;
                        referral.PhysicianCode = referralTemplate.PhysicianCode;
                        referral.HeadName = referralTemplate.HeadName;
                        referral.Comment = referralTemplate.Comment;
                        referral.InvocationId = referralTemplate.InvocationId;

                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.Id = userId;
                        referral.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        db.Referrals.Add(referral);
                    }
                    else
                    {
                        referral = db.Referrals.Find(referralTemplate.ReferralId);

                        referral.ReferralId = referralTemplate.ReferralId;
                        referral.FirstName = referralTemplate.FirstName;
                        referral.LastName = referralTemplate.LastName;
                        referral.PatronymicName = referralTemplate.PatronymicName;
                        referral.BirthDate = referralTemplate.BirthDate;
                        referral.IdentificatorTypeId = referralTemplate.IdentificatorTypeId;
                        referral.Identificator = referralTemplate.Identificator;
                        referral.Phone = referralTemplate.Phone;
                        referral.ResidentMail = referralTemplate.ResidentMail;
                        referral.ResidentRegionId = referralTemplate.ResidentRegionId;
                        referral.ResidentCommunityId = referralTemplate.ResidentRegionId;
                        referral.ResidentStreet = referralTemplate.ResidentStreet;
                        referral.ResidentHome = referralTemplate.ResidentHome;
                        referral.ResidentRoom = referralTemplate.ResidentRoom;
                        referral.HabitantRegionId = referralTemplate.HabitantRegionId;
                        referral.HabitantCommunityId = referralTemplate.HabitantCommunityId;
                        referral.HabitantStreet = referralTemplate.HabitantStreet;
                        referral.HabitantHome = referralTemplate.HabitantHome;
                        referral.HabitantRoom = referralTemplate.HabitantRoom;
                        referral.ReferralOrganizationId = referralTemplate.ReferralOrganizationId;
                        referral.ReferralOrganizationCode = referralTemplate.ReferralOrganizationCode;
                        referral.ReferralOrganizationLocation = referralTemplate.ReferralOrganizationLocation;
                        referral.ReferralOrganizationPhone = referralTemplate.ReferralOrganizationPhone;
                        referral.PreliminaryDiagnose = referralTemplate.PreliminaryDiagnose;
                        referral.ReferralPurpose1 = referralTemplate.ReferralPurpose1;
                        referral.ReferralPurpose2 = referralTemplate.ReferralPurpose2;
                        referral.ReferralPurpose3 = referralTemplate.ReferralPurpose3;
                        referral.ReferralPurpose3Description = referralTemplate.ReferralPurpose3Description;
                        referral.ReferralPurpose4 = referralTemplate.ReferralPurpose4;
                        referral.ReferralPurpose5 = referralTemplate.ReferralPurpose5;
                        referral.ReferralPurpose6 = referralTemplate.ReferralPurpose6;
                        referral.ReferralPurpose7 = referralTemplate.ReferralPurpose7;
                        referral.ReferralPurpose7Description = referralTemplate.ReferralPurpose7Description;
                        referral.SocialBenefit = referralTemplate.SocialBenefit;
                        referral.SocialBenefitDescription = referralTemplate.SocialBenefitDescription;
                        referral.PhysicianId = referralTemplate.PhysicianId;
                        referral.PhysicianCode = referralTemplate.PhysicianCode;
                        referral.HeadName = referralTemplate.HeadName;
                        referral.Comment = referralTemplate.Comment;
                        referral.InvocationId = referralTemplate.InvocationId;

                        referral.Id = userId;
                        referral.LogDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                    }

                    db.SaveChanges();

                    string path = Server.MapPath("~/FileStorage/Referral/" + referralTemplate.ReferralId.ToString());
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

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult RequestConformReferral(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 2;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.Id = userId;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը ներկայացվել է համաձայնեցման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult RequestConfirmReferral(int? id)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 4;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.Id = userId;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը ներկայացվել է հաստատման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral2, administrator")]
        public ActionResult ConformReferral(int? id)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 3;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConformationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConformationUserId = userId;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը համաձայնեցված է: " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral3, administrator")]
        public ActionResult ConfirmReferral(int? id)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 5;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConfirmationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConfirmationUserId = userId;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը հաստատված է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral2, Referral3, administrator")]
        public ActionResult ReturnUpdateReferral(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 6;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConformationDate = null;
                        referral.ConfirmationDate = null;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը վերադարձվել է խմբագրման:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral3, administrator")]
        public ActionResult CancelReferral(int? id)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(id);
                    if (referral != null)
                    {
                        referral.ReferralStatusId = 7;
                        referral.ReferralDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        referral.ConformationDate = null;
                        referral.ConfirmationDate = null;
                        referral.ConfirmationUserId = userId;
                        db.Referrals.Attach(referral);
                        db.Entry(referral).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return this.Json(new { statuscode = 1, message = "Ուղեգիրը չեղարկվել է:" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { statuscode = -1, message = "Տեխնիկական սխալ: - " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult InvocationUploadTemplate(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    //this.OrganizeViewBugs(db, id);
                    ViewBag.fileName = Guid.NewGuid().ToString();
                    Referral item = db.Referrals.Find(id);
                    return View("InvocationUploadTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> files, string name, string path)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    string directoryPath = Server.MapPath("~/FileStorage/Referral/" + path);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string fileName = name + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/FileStorage/Referral/" + path), fileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    file.SaveAs(filePath);
                }
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult DeleteFile(string name, string path)
        {
            if (!String.IsNullOrEmpty(name))
            {
                string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/Referral/" + path), name + ".*");
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (System.IO.File.Exists(file))
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                    using (var db = new StoreContext())
                    {
                        int referralId = Convert.ToInt32(path);
                        Referral referral = db.Referrals.Find(referralId);
                        //Հեռացնում ենք արդեն ֆիքսված ֆայլը
                        if (referral.DocumentGuid == new Guid(name))
                        {
                            referral.DocumentGuid = null;
                            referral.DocumentURL = null;
                            db.Entry(referral).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [Authorize(Roles = "Referral1, administrator")]
        public ActionResult SaveFile(Referral invocationFile)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/Referral/" + invocationFile.ReferralId.ToString()), invocationFile.DocumentGuid + ".*");
                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            invocationFile.DocumentURL = "~/FileStorage/Referral/" + invocationFile.ReferralId.ToString() + "/" + Path.GetFileName(file);
                        }
                    }
                    Referral referral = db.Referrals.Find(invocationFile.ReferralId);
                    referral.DocumentGuid = invocationFile.DocumentGuid;
                    referral.DocumentURL = invocationFile.DocumentURL;
                    db.Entry(referral).State = EntityState.Modified;
                    db.SaveChanges();

                    //Clear folder from unbound files
                    string[] allFiles = Directory.GetFiles(Server.MapPath("~/FileStorage/Referral/" + referral.ReferralId.ToString()));
                    foreach (string fileName in allFiles)
                    {
                        string a = Path.GetFileNameWithoutExtension(fileName);

                        int fileCnt = db.Referrals.Where(p => p.DocumentGuid.ToString() == a).Count();
                        if (fileCnt == 0)
                        {
                            if (System.IO.File.Exists(fileName))
                            {
                                System.IO.File.Delete(fileName);
                            }
                        }
                    }

                    return Json("1", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Referral1, administrator")]
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
        

        [Authorize(Roles = "Referral1, Referral2, Referral3, Referral4, administrator")]
        public ActionResult ReferralChart()
        {
            //ViewBag.vbPermissions = new UserPermission().PermissionPattern;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Referral1, Referral2, Referral3, Referral4, administrator")]
        public ActionResult ReadReferralChart(string startDate, string finishDate)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var prmStartDate = new SqlParameter("@StartDate", SqlDbType.Date);
                    var prmFinishDate = new SqlParameter("@FinishDate", SqlDbType.Date);
                    prmStartDate.Value = Convert.ToDateTime(startDate);
                    prmFinishDate.Value = Convert.ToDateTime(finishDate);
                    List<ReferralChart> referrals = db.Database.SqlQuery<ReferralChart>
                        ("spReferralChart @StartDate, @FinishDate", prmStartDate, prmFinishDate).ToList();
                    return Json(referrals);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReferralTemplate2(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db, 0);
                    IQueryable<Referral> query = db.Referrals
                        .Include(m => m.ReferralServices)
                        .Include(m => m.ReferralExaminations)
                        .Include(m => m.ReferralProcedures)
                        .Include(m => m.ReferralSurgeries)
                        .Include(m => m.ReferralConsultations)
                        .Where(p => p.ReferralId == id);
                    return View("ReferralTemplate2", query.First());
                    //Referral referral = db.Referrals.Find(id);
                    //return View("ReferralTemplate2", referral);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferralServices([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralService> item = db.ReferralServices.Where(p => p.ReferralId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferralExaminations([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralExamination> item = db.ReferralExaminations.Where(p => p.ReferralId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferralSurgeries([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralSurgery> item = db.ReferralSurgeries.Where(p => p.ReferralId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferralProcedures([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralProcedure> item = db.ReferralProcedures.Where(p => p.ReferralId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult ReadReferralConsultations([DataSourceRequest]DataSourceRequest request, int? id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralConsultation> item = db.ReferralConsultations.Where(p => p.ReferralId == id);
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Referral4, administrator")]
        public ActionResult SaveReferral2(Referral rItem)
        {
            try
            {

                using (var db = new StoreContext())
                {
                    Referral referral = db.Referrals.Find(rItem.ReferralId);
                    referral.OutcomeId = rItem.OutcomeId;
                    referral.DiagnoseId = rItem.DiagnoseId;
                    referral.TerminationDate = rItem.TerminationDate;

                    if (rItem.ReferralServices != null)
                    {
                        foreach (var item in rItem.ReferralServices)
                        {
                            item.ReferralId = referral.ReferralId;
                            item.Id = userId;

                            if (item.RecordStatus == 1)
                            {
                                db.ReferralServices.Add(item);
                            }
                            else if (item.RecordStatus == 2)
                            {
                                db.ReferralServices.Attach(item);
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else if (item.RecordStatus == 3)
                            {
                                db.ReferralServices.Attach(item);
                                db.ReferralServices.Remove(item);
                            }
                        }
                    }
                    if (rItem.ReferralExaminations != null)
                    {
                        foreach (var item in rItem.ReferralExaminations)
                        {
                            item.ReferralId = referral.ReferralId;
                            item.Id = userId;

                            if (item.RecordStatus == 1)
                            {
                                db.ReferralExaminations.Add(item);
                            }
                            else if (item.RecordStatus == 2)
                            {
                                db.ReferralExaminations.Attach(item);
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else if (item.RecordStatus == 3)
                            {
                                db.ReferralExaminations.Attach(item);
                                db.ReferralExaminations.Remove(item);
                            }
                        }
                    }
                    if (rItem.ReferralProcedures != null)
                    {
                        foreach (var item in rItem.ReferralProcedures)
                        {
                            item.ReferralId = referral.ReferralId;
                            item.Id = userId;

                            if (item.RecordStatus == 1)
                            {
                                db.ReferralProcedures.Add(item);
                            }
                            else if (item.RecordStatus == 2)
                            {
                                db.ReferralProcedures.Attach(item);
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else if (item.RecordStatus == 3)
                            {
                                db.ReferralProcedures.Attach(item);
                                db.ReferralProcedures.Remove(item);
                            }
                        }
                    }
                    if (rItem.ReferralSurgeries != null)
                    {
                        foreach (var item in rItem.ReferralSurgeries)
                        {
                            item.ReferralId = referral.ReferralId;
                            item.Id = userId;

                            if (item.RecordStatus == 1)
                            {
                                db.ReferralSurgeries.Add(item);
                            }
                            else if (item.RecordStatus == 2)
                            {
                                db.ReferralSurgeries.Attach(item);
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else if (item.RecordStatus == 3)
                            {
                                db.ReferralSurgeries.Attach(item);
                                db.ReferralSurgeries.Remove(item);
                            }
                        }
                    }
                    if (rItem.ReferralConsultations != null)
                    {
                        foreach (var item in rItem.ReferralConsultations)
                        {
                            item.ReferralId = referral.ReferralId;
                            item.Id = userId;

                            if (item.RecordStatus == 1)
                            {
                                db.ReferralConsultations.Add(item);
                            }
                            else if (item.RecordStatus == 2)
                            {
                                db.ReferralConsultations.Attach(item);
                                db.Entry(item).State = EntityState.Modified;
                            }
                            else if (item.RecordStatus == 3)
                            {
                                db.ReferralConsultations.Attach(item);
                                db.ReferralConsultations.Remove(item);
                            }
                        }
                    }
                    referral.ServiceUserId = userId;
                    db.Referrals.Attach(referral);
                    db.Entry(referral).State = EntityState.Modified;

                    db.SaveChanges();

                    this.OrganizeViewBugs(db, 0);
                    return View("Index4");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }
    }
}