using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using System.Data.Entity;
using Kendo.Mvc.Extensions;
using System.Web.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace Medicalreferrals.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var item = new HomeIndexModel();
            return View(item);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeIndexModel request)
        {
            bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (!isCapthcaValid)
            {
                TempData["requestMessage"] = "Captcha ստուգումը խափանվեց";
                return View("Index", request);
            }

            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    switch (request.RequestTypeId)
                    {
                        case 1:
                            InvocationItem item = db.InvocationItems.Find(request.RequestId);
                            ViewBag.InvocationFile = 0;
                            if (!String.IsNullOrEmpty(item.InvocationURL))
                            {
                                ViewBag.InvocationFile = 1;
                            }
                            ViewBag.File1 = 0;
                            ViewBag.File2 = 0;
                            ViewBag.File3 = 0;
                            ViewBag.File4 = 0;
                            IQueryable<InvocationDocument> invocationDocuments = db.InvocationDocuments.Where(p => p.InvocationId == item.InvocationId);
                            foreach (var invocationDocument in invocationDocuments)
                            {
                                switch (invocationDocument.DocumentTypeId)
                                {
                                    case 1:
                                        ViewBag.File1 = 1;
                                        break;
                                    case 2:
                                        ViewBag.File2 = 1;
                                        break;
                                    case 3:
                                        ViewBag.File3 = 1;
                                        break;
                                    case 4:
                                        ViewBag.File4 = 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            return View("InvocationDetail", item);
                        case 2:
                            ReferralItem referralItem = db.ReferralItems.Find(request.RequestId);
                            return View("ReferralDetail", referralItem);
                        case 3:
                            ReferralOrderItem referralOrderItem = db.ReferralOrderItems.Find(request.RequestId);
                            return View("ReferralOrderDetail", referralOrderItem);
                        default:
                            return View("Index", request);
                    }
                }
            }
            else
            {
                TempData["requestMessage"] = "Մոդելի սխալ";
                return View("Index", request);
            }
        }

        #region ReferralOrderRegion
        public ActionResult ReferralOrderInput()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    var item = new ReferralOrderInput();
                    return View("ReferralOrderInput", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult ReferralOrderInput(ReferralOrderInput referralOrderInput)
        {
            try
            {
                bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
                if (!isCapthcaValid)
                {
                    referralOrderInput.ReferralOrderStatusName = "Captcha ստուգումը խափանվեց";
                    return View("ReferralOrderInput", referralOrderInput);
                }

                using (var db = new StoreContext())
                {
                    DateTime? confirmDate = referralOrderInput.ConfirmationDate;
                    string referralNumber = referralOrderInput.ReferralNumber;
                    IQueryable<ReferralItem> query = from c in db.ReferralItems where c.ReferralNumber == referralNumber && c.ConfirmationDate == confirmDate select c;
                    if (query.Count() == 1)
                    {
                        ReferralItem q = query.First();
                        if (q.TerminationDate != null)
                        {
                            referralOrderInput.ReferralOrderStatusName = "Ուղեգիրը արդեն իրացված է և չի կարող հերթագրվել";
                            return View("ReferralOrderInput", referralOrderInput);
                        }
                        //Էստեղ կավելացվեն հետագա ստուգման արդյունքները
                        return RedirectToAction("ReferralOrderFinalize", "Home", new { referralId = q.ReferralId });
                    }
                    else
                    {
                        referralOrderInput.ReferralOrderStatusName = "Նման ուղեգիր չկա";
                        return View("ReferralOrderInput", referralOrderInput);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "ReferralOrderInput"));
            }
        }

        public ActionResult ReferralOrderFinalize(int? referralId)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReferralItem referralItem = db.ReferralItems.Find(referralId);
                    var item = new ReferralOrderFinalize();
                    item.ReferralId = referralItem.ReferralId;
                    item.ReferralNumber = referralItem.ReferralNumber;
                    item.ConfirmationDate = String.Format("{0:yyyy-MM-dd}", referralItem.ConfirmationDate);
                    item.ValidityDate = String.Format("{0:yyyy-MM-dd}", referralItem.ValidityDate);
                    item.FirstName = referralItem.FirstName;
                    item.LastName = referralItem.LastName;
                    item.PatronymicName = referralItem.PatronymicName;
                    item.BirthDate = String.Format("{0:yyyy-MM-dd}", referralItem.BirthDate);
                    item.Identificator = referralItem.Identificator;
                    item.ResidentRegionName = referralItem.ResidentRegionName;
                    item.ResidentCommunityName = referralItem.ResidentCommunityName;
                    item.ResidentStreet = referralItem.ResidentStreet;
                    item.ResidentHome = referralItem.ResidentHome;
                    item.ResidentRoom = referralItem.ResidentRoom;
                    item.ResidentMail = referralItem.ResidentMail;
                    item.Phone = referralItem.Phone;
                    item.ReferralPurpose1 = referralItem.ReferralPurpose1;
                    item.ReferralPurpose2 = referralItem.ReferralPurpose2;
                    item.ReferralPurpose3 = referralItem.ReferralPurpose3;
                    item.ReferralPurpose4 = referralItem.ReferralPurpose4;
                    item.ReferralPurpose5 = referralItem.ReferralPurpose5;
                    item.ReferralPurpose6 = referralItem.ReferralPurpose6;
                    item.ReferralPurpose7 = referralItem.ReferralPurpose7;
                    this.ReferralOrderViewBugs(db);
                    return View("ReferralOrderFinalize", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "ReferralOrderFinalize"));
            }
        }

        [HttpPost]
        public ActionResult ReferralOrderFinalize(ReferralOrderFinalize referralOrderFinalize)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
                    if (!isCapthcaValid)
                    {
                        referralOrderFinalize.ReferralOrderStatusName = "Captcha ստուգումը խափանվեց";
                        this.ReferralOrderViewBugs(db);
                        return View("ReferralOrderFinalize", referralOrderFinalize);
                    }

                    if (ModelState.IsValid)
                    {
                        var item = new Models.ReferralOrder();
                        item.ReferralId = referralOrderFinalize.ReferralId;
                        item.OrganizationId = referralOrderFinalize.OrganizationId;
                        item.ReferralOrderDate = referralOrderFinalize.ReferralOrderDate;
                        item.ReferralOrderStatusId = 1;
                        db.ReferralOrders.Add(item);
                        db.SaveChanges();
                        return RedirectToAction("ReferralOrderDetail", new { id = item.ReferralOrderId });
                    }
                    else
                    {
                        referralOrderFinalize.ReferralOrderStatusName = "Մոդելը վավեր չէ";
                        this.ReferralOrderViewBugs(db);
                        return View("ReferralOrderFinalize", referralOrderFinalize);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "SaveReferralOrder"));
            }
        }

        public ActionResult ReferralOrderDetail(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ReferralOrderItem referralOrderItem = db.ReferralOrderItems.Find(id);
                    return View("ReferralOrderDetail", referralOrderItem);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "ReferralOrderDetail"));
            }
        }

        private void ReferralOrderViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;
        }

        #endregion

        #region InvocationRegion        
        public ActionResult PaperInvocation()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ViewBag.InvocationFile = Guid.NewGuid().ToString();
                    ViewBag.Folder = Guid.NewGuid().ToString();
                    ViewBag.File1 = Guid.NewGuid().ToString();
                    ViewBag.File2 = Guid.NewGuid().ToString();
                    ViewBag.File3 = Guid.NewGuid().ToString();
                    ViewBag.File4 = Guid.NewGuid().ToString();
                    this.PaperInvocationViewBugs(db);
                    var item = new HomePaperInvocationModel();
                    return View("PaperInvocation", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "PaperInvocation"));
            }
        }

        private void PaperInvocationViewBugs(StoreContext db)
        {
            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lInvocationPurposes = new List<SelectListItem>();
            lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
            ViewBag.vbInvocationPurposes = lInvocationPurposes;
        }

        [HttpPost]
        public ActionResult PaperInvocation(HomePaperInvocationModel homePaperInvocationModel, string folder, string invocationFile, string file1, string file2, string file3, string file4)
        {
            try
            {
                string pxPath = "~/FileStorage/Invocation/";
                string directoryPath = Server.MapPath(pxPath + folder);

                using (var db = new StoreContext())
                {
                    //If Captchia is not valid return model
                    bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
                    if (!isCapthcaValid)
                    {
                        TempData["requestMessage"] = "Captcha ստուգումը խափանվեց";
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }
                        ViewBag.InvocationFile = Guid.NewGuid().ToString();
                        ViewBag.File1 = Guid.NewGuid().ToString();
                        ViewBag.File2 = Guid.NewGuid().ToString();
                        ViewBag.File3 = Guid.NewGuid().ToString();
                        ViewBag.File4 = Guid.NewGuid().ToString();
                        ViewBag.Folder = Guid.NewGuid().ToString();
                        this.PaperInvocationViewBugs(db);
                        return View("PaperInvocation", homePaperInvocationModel);
                    }

                    if (ModelState.IsValid)
                    {
                        var invocation = new Models.Invocation();

                        invocation.OrganizationId = homePaperInvocationModel.OrganizationId;
                        invocation.InvocationPurposeId = homePaperInvocationModel.InvocationPurposeId;
                        invocation.ResidentMail = homePaperInvocationModel.ResidentMail;

                        // Nonvisible fields
                        invocation.InitiationTypeId = 1; //Paper Invocation
                        invocation.InitiationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InvocationStatusId = 1; //Preparation Stage
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();

                        db.Invocations.Add(invocation);

                        db.SaveChanges();
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }
                        string path1 = Server.MapPath(pxPath + folder);
                        string path2 = Server.MapPath(pxPath + invocation.InvocationId.ToString());
                        if (Directory.Exists(path1))
                        {
                            Directory.Move(path1, path2);
                        }
                        if (!string.IsNullOrEmpty(invocationFile))
                        {
                            string[] files = Directory.GetFiles(Server.MapPath(pxPath + invocation.InvocationId.ToString()), invocationFile + ".*");
                            if (files != null)
                            {
                                foreach (var file in files)
                                {
                                    invocation.InvocationGuid = new Guid(invocationFile);
                                    invocation.InvocationURL = pxPath + invocation.InvocationId.ToString() + "/" + Path.GetFileName(file);
                                }
                            }
                        }
                        var fileArray = new string[] { file1, file2, file3, file4 };
                        foreach (string item in fileArray)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                string[] files = Directory.GetFiles(Server.MapPath(pxPath + invocation.InvocationId.ToString()), item + ".*");
                                if (files != null)
                                {
                                    foreach (var file in files)
                                    {
                                        var item1 = new InvocationDocument();
                                        item1.InvocationId = invocation.InvocationId;
                                        item1.DocumentURL = pxPath + invocation.InvocationId.ToString() + "/" + Path.GetFileName(file);
                                        item1.DocumentTypeId = Array.IndexOf(fileArray, item) + 1;
                                        item1.DocumentGuid = new Guid(item);
                                        db.InvocationDocuments.Add(item1);
                                    }
                                }
                            }
                        }
                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("InvocationDetail", new { id = invocation.InvocationId });
                    }
                    else
                    {
                        TempData["requestMessage"] = "մոդելը վավեր չէ";
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }
                        ViewBag.InvocationFile = Guid.NewGuid().ToString();
                        ViewBag.File1 = Guid.NewGuid().ToString();
                        ViewBag.File2 = Guid.NewGuid().ToString();
                        ViewBag.File3 = Guid.NewGuid().ToString();
                        ViewBag.File4 = Guid.NewGuid().ToString();
                        ViewBag.Folder = Guid.NewGuid().ToString();
                        this.DigitalInvocationViewBugs(db);
                        return View("PaperInvocation", homePaperInvocationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "PaperInvocation"));
            }
        }


        public ActionResult DigitalInvocation()
        {
            try
            {
                using (var db = new StoreContext())
                {
                    ViewBag.File1 = Guid.NewGuid().ToString();
                    ViewBag.File2 = Guid.NewGuid().ToString();
                    ViewBag.File3 = Guid.NewGuid().ToString();
                    ViewBag.File4 = Guid.NewGuid().ToString();
                    ViewBag.Folder = Guid.NewGuid().ToString();
                    this.DigitalInvocationViewBugs(db);
                    var item = new HomeDigitalInvocationModel();
                    return View("DigitalInvocation", item);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "DigitalInvocation"));
            }
        }
        private void DigitalInvocationViewBugs(StoreContext db)
        {
            var lRegions = new List<SelectListItem>();
            lRegions = db.Regions.Select(x => new SelectListItem { Text = x.RegionName, Value = x.RegionId.ToString() }).ToList();
            ViewBag.vbRegions = lRegions;

            var lCommunities = new List<SelectListItem>();
            lCommunities = db.Communities.Select(x => new SelectListItem { Text = x.CommunityName, Value = x.CommunityId.ToString() }).ToList();
            ViewBag.vbCommunities = lCommunities;

            var lOrganizations = new List<SelectListItem>();
            lOrganizations = db.Organizations.Select(x => new SelectListItem { Text = x.OrganizationName, Value = x.OrganizationId.ToString() }).ToList();
            ViewBag.vbOrganizations = lOrganizations;

            var lInvocationPurposes = new List<SelectListItem>();
            lInvocationPurposes = db.InvocationPurposes.Select(x => new SelectListItem { Text = x.InvocationPurposeName, Value = x.InvocationPurposeId.ToString() }).ToList();
            ViewBag.vbInvocationPurposes = lInvocationPurposes;
        }
        [HttpPost]
        public ActionResult DigitalInvocation(HomeDigitalInvocationModel homeDigitalInvocationModel, string folder, string file1, string file2, string file3, string file4)
        {
            try
            {
                string pxPath = "~/FileStorage/Invocation/";
                string directoryPath = Server.MapPath(pxPath + folder);

                using (var db = new StoreContext())
                {
                    bool isCapthcaValid = ValidateCaptcha(Request["g-recaptcha-response"]);
                    if (!isCapthcaValid)
                    {
                        TempData["requestMessage"] = "Captcha ստուգումը խափանվեց";
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }
                        ViewBag.InvocationFile = Guid.NewGuid().ToString();
                        ViewBag.File1 = Guid.NewGuid().ToString();
                        ViewBag.File2 = Guid.NewGuid().ToString();
                        ViewBag.File3 = Guid.NewGuid().ToString();
                        ViewBag.File4 = Guid.NewGuid().ToString();
                        ViewBag.Folder = Guid.NewGuid().ToString();
                        this.DigitalInvocationViewBugs(db);
                        return View("DigitalInvocation", homeDigitalInvocationModel);
                    }

                    if (ModelState.IsValid)
                    {
                        var invocation = new Models.Invocation();
                        invocation.FirstName = homeDigitalInvocationModel.FirstName;
                        invocation.LastName = homeDigitalInvocationModel.LastName;
                        invocation.PatronymicName = homeDigitalInvocationModel.PatronymicName;
                        invocation.BirthDate = homeDigitalInvocationModel.BirthDate;
                        invocation.RegionId = homeDigitalInvocationModel.RegionId;
                        invocation.CommunityId = homeDigitalInvocationModel.CommunityId;
                        invocation.Street = homeDigitalInvocationModel.Street;
                        invocation.Home = homeDigitalInvocationModel.Home;
                        invocation.Room = homeDigitalInvocationModel.Room;
                        invocation.ResidentMail = homeDigitalInvocationModel.ResidentMail;
                        invocation.OrganizationId = homeDigitalInvocationModel.OrganizationId;
                        invocation.InvocationPurposeId = homeDigitalInvocationModel.InvocationPurposeId;

                        // Nonvisible fields
                        invocation.InvocationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InitiationDate = db.Database.SqlQuery<DateTime>("SELECT GETDATE()").Single();
                        invocation.InitiationTypeId = 2;
                        invocation.InvocationStatusId = 1;

                        db.Invocations.Add(invocation);
                        db.SaveChanges();

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        string path1 = Server.MapPath(pxPath + folder);
                        string path2 = Server.MapPath(pxPath + invocation.InvocationId.ToString());

                        if (Directory.Exists(path1))
                        {
                            Directory.Move(path1, path2);
                        }

                        var fileArray = new string[] { file1, file2, file3, file4 };

                        foreach (string item in fileArray)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                string[] files = Directory.GetFiles(Server.MapPath(pxPath + invocation.InvocationId.ToString()), item + ".*");
                                if (files != null)
                                {
                                    foreach (var file in files)
                                    {
                                        var item1 = new InvocationDocument();
                                        item1.InvocationId = invocation.InvocationId;
                                        item1.DocumentURL = pxPath + invocation.InvocationId.ToString() + "/" + Path.GetFileName(file);
                                        item1.DocumentTypeId = Array.IndexOf(fileArray, item) + 1;
                                        item1.DocumentGuid = new Guid(item);
                                        db.InvocationDocuments.Add(item1);
                                    }
                                }
                            }
                        }

                        db.Invocations.Attach(invocation);
                        db.Entry(invocation).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("InvocationDetail", new { id = invocation.InvocationId });
                    }
                    else
                    {
                        TempData["requestMessage"] = "մոդելը վավեր չէ";
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }
                        ViewBag.InvocationFile = Guid.NewGuid().ToString();
                        ViewBag.File1 = Guid.NewGuid().ToString();
                        ViewBag.File2 = Guid.NewGuid().ToString();
                        ViewBag.File3 = Guid.NewGuid().ToString();
                        ViewBag.File4 = Guid.NewGuid().ToString();
                        ViewBag.Folder = Guid.NewGuid().ToString();
                        this.DigitalInvocationViewBugs(db);
                        return View("DigitalInvocation", homeDigitalInvocationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "DigitalInvocation"));
            }
        }

        public ActionResult InvocationDetail(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    InvocationItem invocationItem = db.InvocationItems.Find(id);
                    return View("InvocationDetail", invocationItem);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "SaveInvocation1"));
            }
        }

        #endregion

        public ActionResult DownloadPreinvocationFile()
        {

            string filePathName = Server.MapPath("~/FileStorage/Downloads/preinvocation.pdf");
            if (System.IO.File.Exists(filePathName))
            {
                byte[] filedata = System.IO.File.ReadAllBytes(filePathName);
                string contentType = MimeMapping.GetMimeMapping(filePathName);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = Path.GetFileName("~/FileStorage/Downloads/preinvocation.pdf"),
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
            }
            return HttpNotFound();

        }
        public ActionResult UploadInvocationFile(IEnumerable<HttpPostedFileBase> invocation, string name, string path)
        {
            if (invocation != null)
            {
                this.SaveTempFile(invocation, name, path);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadFile1(IEnumerable<HttpPostedFileBase> indication, string name, string path)
        {
            if (indication != null)
            {
                this.SaveTempFile(indication, name, path);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadFile2(IEnumerable<HttpPostedFileBase> eligibility, string name, string path)
        {
            if (eligibility != null)
            {
                this.SaveTempFile(eligibility, name, path);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadFile3(IEnumerable<HttpPostedFileBase> petition, string name, string path)
        {
            if (petition != null)
            {
                this.SaveTempFile(petition, name, path);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadFile4(IEnumerable<HttpPostedFileBase> other, string name, string path)
        {
            if (other != null)
            {
                this.SaveTempFile(other, name, path);
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        private void SaveTempFile(IEnumerable<HttpPostedFileBase> files, string name, string path)
        {
            string directoryPath = Server.MapPath("~/FileStorage/Invocation/" + path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            foreach (var file in files)
            {
                string fileName = name + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(Server.MapPath("~/FileStorage/Invocation/" + path), fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                file.SaveAs(filePath);
            }
        }
        public ActionResult DeleteFile(string name, string path)
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

        public static bool ValidateCaptcha(string response)
        {
            //secret that was generated in key value pair  
            string secret = WebConfigurationManager.AppSettings["recaptchaPrivateKey"];

            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            return Convert.ToBoolean(captchaResponse.Success);

        }
    }
}