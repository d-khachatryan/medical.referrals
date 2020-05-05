using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;

namespace Medicalreferrals.Controllers
{
    public class ReferralDocumentController : Controller
    {
        private void OrganizeViewBugs(StoreContext db)
        {
            var lDocumentTypes = new List<SelectListItem>();
            lDocumentTypes = db.DocumentTypes.Select(x => new SelectListItem { Text = x.DocumentTypeName, Value = x.DocumentTypeId.ToString() }).ToList();
            ViewBag.vbDocuments = lDocumentTypes;
        }

        public ActionResult ReadReferralDocuments([DataSourceRequest]DataSourceRequest request, int id)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralDocumentItem> referralDocuments = db.ReferralDocumentItems.Where(p => p.ReferralId == id);
                DataSourceResult result = referralDocuments.ToDataSourceResult(request);
                return Json(result);
            }
        }

        public ActionResult CreateReferralDocument(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    var item = new ReferralDocument();
                    item.ReferralId = id;
                    ViewBag.fileName = Guid.NewGuid().ToString();
                    return View("ReferralDocumentTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult UpdateReferralDocument(int? id)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    this.OrganizeViewBugs(db);
                    ReferralDocument item = db.ReferralDocuments.Find(id);
                    ViewBag.fileName = Guid.NewGuid().ToString();
                    return View("ReferralDocumentTemplate", item);
                }
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        public ActionResult DeleteReferralDocument([DataSourceRequest]DataSourceRequest request, int? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new StoreContext())
                    {
                        ReferralDocument item = db.ReferralDocuments.Find(Convert.ToInt32(id));
                        db.ReferralDocuments.Attach(item);

                        string fileName = Server.MapPath(item.DocumentURL);
                        if (System.IO.File.Exists(fileName))
                        {
                            System.IO.File.Delete(fileName);
                        }

                        db.ReferralDocuments.Remove(item);
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

        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> files, string name, string path)
        {
            if (files != null)
            {
                string directoryPath = Server.MapPath("~/FileStorage/ReferralDocument/" + path);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                foreach (var file in files)
                {
                    string fileName = name + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/FileStorage/ReferralDocument/" + path), fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    file.SaveAs(filePath);
                }
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFile(string name, string path)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/ReferralDocument/" + path), name + ".*");

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
        public ActionResult SaveReferralDocument(ReferralDocument referralDocument)
        {
            try
            {
                using (var db = new StoreContext())
                {
                    int? cnt = db.ReferralDocuments.Where(p => p.ReferralDocumentId == referralDocument.ReferralDocumentId).Count();

                    string[] files = Directory.GetFiles(Server.MapPath("~/FileStorage/ReferralDocument/" + referralDocument.ReferralId.ToString()), referralDocument.DocumentGuid + ".*");
                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            referralDocument.DocumentURL = "~/FileStorage/ReferralDocument/" + referralDocument.ReferralId.ToString() + "/" + Path.GetFileName(file);
                        }
                    }

                    if (cnt == 0)
                    {

                        db.ReferralDocuments.Add(referralDocument);
                    }
                    else
                    {
                        db.ReferralDocuments.Attach(referralDocument);
                        db.Entry(referralDocument).State = EntityState.Modified;
                    }

                    db.SaveChanges();

                    //Clear folder from unbound files
                    string[] allFiles = Directory.GetFiles(Server.MapPath("~/FileStorage/ReferralDocument/" + referralDocument.ReferralId.ToString()));
                    foreach (string fileName in allFiles)
                    {
                        string a = Path.GetFileNameWithoutExtension(fileName);

                        int fileCnt = db.ReferralDocuments.Where(p => p.DocumentGuid.ToString() == a).Count();
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

    }
}