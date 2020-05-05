using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Medicalreferrals.DAL;
using Medicalreferrals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medicalreferrals.Controllers
{
    [Authorize(Roles = "administrator")]
    public class CatalogController : Controller
    {
        #region OrganizationType
        public ActionResult OrganizationType()
        {
            return View();
        }
        public ActionResult OrganizationTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<OrganizationType> item = db.OrganizationTypes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult OrganizationTypeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<OrganizationType> item)
        {
            var entities = new List<OrganizationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new OrganizationType
                        {
                            OrganizationTypeName = itm.OrganizationTypeName,
                            Budget1 = itm.Budget1,
                            Budget2 = itm.Budget2,
                            Budget3 = itm.Budget3,
                        };
                        db.OrganizationTypes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new OrganizationType
            {
                OrganizationTypeId = itm.OrganizationTypeId,
                OrganizationTypeName = itm.OrganizationTypeName,
                Budget1 = itm.Budget1,
                Budget2 = itm.Budget2,
                Budget3 = itm.Budget3,
            }));
        }
        public ActionResult OrganizationTypeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<OrganizationType> item)
        {
            var entities = new List<OrganizationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new OrganizationType
                        {
                            OrganizationTypeId = itm.OrganizationTypeId,
                            OrganizationTypeName = itm.OrganizationTypeName,
                            Budget1 = itm.Budget1 ,
                            Budget2 = itm.Budget2,
                            Budget3 = itm.Budget3,
                        };
                        entities.Add(entity);
                        db.OrganizationTypes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new OrganizationType
            {
                OrganizationTypeId = itm.OrganizationTypeId,
                OrganizationTypeName = itm.OrganizationTypeName,
                Budget1 = itm.Budget1,
                Budget2 = itm.Budget2,
                Budget3 = itm.Budget3,
            }));
        }
        public ActionResult OrganizationTypeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<OrganizationType> item)
        {
            var entities = new List<OrganizationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new OrganizationType
                        {
                            OrganizationTypeId = itm.OrganizationTypeId,
                            OrganizationTypeName = itm.OrganizationTypeName,
                            Budget1 = itm.Budget1,
                            Budget2 = itm.Budget2,
                            Budget3 = itm.Budget3,
                        };
                        entities.Add(entity);
                        db.OrganizationTypes.Attach(entity);
                        db.OrganizationTypes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new OrganizationType
            {
                OrganizationTypeId = itm.OrganizationTypeId,
                OrganizationTypeName = itm.OrganizationTypeName,
                Budget1 = itm.Budget1,
                Budget2 = itm.Budget2,
                Budget3 = itm.Budget3,
            }));
        }
        #endregion

        #region BudgetLine
        public ActionResult BudgetLine()
        {
            return View();
        }
        public ActionResult BudgetLineRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<BudgetLine> item = db.BudgetLines;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult BudgetLineCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetLine> item)
        {
            var entities = new List<BudgetLine>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new BudgetLine
                        {
                            BudgetLineName = itm.BudgetLineName,
                            BudgetLineCode = itm.BudgetLineCode,
                            StartDate = itm.StartDate,
                            TerminationDate = itm.TerminationDate,
                        };
                        db.BudgetLines.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new BudgetLine
            {
                BudgetLineId = itm.BudgetLineId,
                BudgetLineName = itm.BudgetLineName,
                BudgetLineCode = itm.BudgetLineCode,
                StartDate = itm.StartDate,
                TerminationDate = itm.TerminationDate,
            }));
        }
        public ActionResult BudgetLineUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetLine> item)
        {
            var entities = new List<BudgetLine>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new BudgetLine
                        {
                            BudgetLineId = itm.BudgetLineId,
                            BudgetLineName = itm.BudgetLineName,
                            BudgetLineCode = itm.BudgetLineCode,
                            StartDate = itm.StartDate,
                            TerminationDate = itm.TerminationDate,
                        };
                        entities.Add(entity);
                        db.BudgetLines.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new BudgetLine
            {
                BudgetLineId = itm.BudgetLineId,
                BudgetLineName = itm.BudgetLineName,
                BudgetLineCode = itm.BudgetLineCode,
                StartDate = itm.StartDate,
                TerminationDate = itm.TerminationDate,
            }));
        }
        public ActionResult BudgetLineDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<BudgetLine> item)
        {
            var entities = new List<BudgetLine>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new BudgetLine
                        {
                            BudgetLineId = itm.BudgetLineId,
                            BudgetLineName = itm.BudgetLineName,
                            BudgetLineCode = itm.BudgetLineCode,
                            StartDate = itm.StartDate,
                            TerminationDate = itm.TerminationDate,
                        };
                        entities.Add(entity);
                        db.BudgetLines.Attach(entity);
                        db.BudgetLines.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new BudgetLine
            {
                BudgetLineId = itm.BudgetLineId,
                BudgetLineName = itm.BudgetLineName,
                BudgetLineCode = itm.BudgetLineCode,
                StartDate = itm.StartDate,
                TerminationDate = itm.TerminationDate,
            }));
        }
        #endregion

        #region ChangeBase
        public ActionResult ChangeBase()
        {
            return View();
        }
        public ActionResult ChangeBaseRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ChangeBase> item = db.ChangeBases;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult ChangeBaseCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ChangeBase> item)
        {
            var entities = new List<ChangeBase>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ChangeBase
                        {
                            ChangeBaseName = itm.ChangeBaseName,
                            ChangeBaseCode = itm.ChangeBaseCode,
                        };
                        db.ChangeBases.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ChangeBase
            {
                ChangeBaseId = itm.ChangeBaseId,
                ChangeBaseName = itm.ChangeBaseName,
                ChangeBaseCode = itm.ChangeBaseCode,
            }));
        }
        public ActionResult ChangeBaseUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ChangeBase> item)
        {
            var entities = new List<ChangeBase>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ChangeBase
                        {
                            ChangeBaseId = itm.ChangeBaseId,
                            ChangeBaseName = itm.ChangeBaseName,
                            ChangeBaseCode = itm.ChangeBaseCode,
                        };
                        entities.Add(entity);
                        db.ChangeBases.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ChangeBase
            {
                ChangeBaseId = itm.ChangeBaseId,
                ChangeBaseName = itm.ChangeBaseName,
                ChangeBaseCode = itm.ChangeBaseCode,
            }));
        }
        public ActionResult ChangeBaseDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ChangeBase> item)
        {
            var entities = new List<ChangeBase>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ChangeBase
                        {
                            ChangeBaseId = itm.ChangeBaseId,
                            ChangeBaseName = itm.ChangeBaseName,
                            ChangeBaseCode = itm.ChangeBaseCode,
                        };
                        entities.Add(entity);
                        db.ChangeBases.Attach(entity);
                        db.ChangeBases.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ChangeBase
            {
                ChangeBaseId = itm.ChangeBaseId,
                ChangeBaseName = itm.ChangeBaseName,
                ChangeBaseCode = itm.ChangeBaseCode,
            }));
        }
        #endregion

        #region Diagnose
        public ActionResult Diagnose()
        {
            return View();
        }
        public ActionResult DiagnoseRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<Diagnose> item = db.Diagnoses;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult DiagnoseCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Diagnose> item)
        {
            var entities = new List<Diagnose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Diagnose
                        {
                            DiagnoseName = itm.DiagnoseName,
                            DiagnoseCode = itm.DiagnoseCode,
                        };
                        db.Diagnoses.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Diagnose
            {
                DiagnoseId = itm.DiagnoseId,
                DiagnoseName = itm.DiagnoseName,
                DiagnoseCode = itm.DiagnoseCode,
            }));
        }
        public ActionResult DiagnoseUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Diagnose> item)
        {
            var entities = new List<Diagnose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Diagnose
                        {
                            DiagnoseId = itm.DiagnoseId,
                            DiagnoseName = itm.DiagnoseName,
                            DiagnoseCode = itm.DiagnoseCode,
                        };
                        entities.Add(entity);
                        db.Diagnoses.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Diagnose
            {
                DiagnoseId = itm.DiagnoseId,
                DiagnoseName = itm.DiagnoseName,
                DiagnoseCode = itm.DiagnoseCode,
            }));
        }
        public ActionResult DiagnoseDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Diagnose> item)
        {
            var entities = new List<Diagnose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Diagnose
                        {
                            DiagnoseId = itm.DiagnoseId,
                            DiagnoseName = itm.DiagnoseName,
                            DiagnoseCode = itm.DiagnoseCode,
                        };
                        entities.Add(entity);
                        db.Diagnoses.Attach(entity);
                        db.Diagnoses.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Diagnose
            {
                DiagnoseId = itm.DiagnoseId,
                DiagnoseName = itm.DiagnoseName,
                DiagnoseCode = itm.DiagnoseCode,
            }));
        }
        #endregion

        #region DocumentType
        public ActionResult DocumentType()
        {
            return View();
        }
        public ActionResult DocumentTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<DocumentType> item = db.DocumentTypes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult DocumentTypeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DocumentType> item)
        {
            var entities = new List<DocumentType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new DocumentType
                        {
                            DocumentTypeName = itm.DocumentTypeName,
                            DocumentTypeCode = itm.DocumentTypeCode,
                        };
                        db.DocumentTypes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new DocumentType
            {
                DocumentTypeId = itm.DocumentTypeId,
                DocumentTypeName = itm.DocumentTypeName,
                DocumentTypeCode = itm.DocumentTypeCode,
            }));
        }
        public ActionResult DocumentTypeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DocumentType> item)
        {
            var entities = new List<DocumentType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new DocumentType
                        {
                            DocumentTypeId = itm.DocumentTypeId,
                            DocumentTypeName = itm.DocumentTypeName,
                            DocumentTypeCode = itm.DocumentTypeCode,
                        };
                        entities.Add(entity);
                        db.DocumentTypes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new DocumentType
            {
                DocumentTypeId = itm.DocumentTypeId,
                DocumentTypeName = itm.DocumentTypeName,
                DocumentTypeCode = itm.DocumentTypeCode,
            }));
        }
        public ActionResult DocumentTypeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DocumentType> item)
        {
            var entities = new List<DocumentType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new DocumentType
                        {
                            DocumentTypeId = itm.DocumentTypeId,
                            DocumentTypeName = itm.DocumentTypeName,
                            DocumentTypeCode = itm.DocumentTypeCode,
                        };
                        entities.Add(entity);
                        db.DocumentTypes.Attach(entity);
                        db.DocumentTypes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new DocumentType
            {
                DocumentTypeId = itm.DocumentTypeId,
                DocumentTypeName = itm.DocumentTypeName,
                DocumentTypeCode = itm.DocumentTypeCode,
            }));
        }
        #endregion

        #region IdentificatorType
        public ActionResult IdentificatorType()
        {
            return View();
        }
        public ActionResult IdentificatorTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<IdentificatorType> item = db.IdentificatorTypes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult IdentificatorTypeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<IdentificatorType> item)
        {
            var entities = new List<IdentificatorType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new IdentificatorType
                        {
                            IdentificatorTypeName = itm.IdentificatorTypeName,
                            IdentificatorTypeCode = itm.IdentificatorTypeCode,
                        };
                        db.IdentificatorTypes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new IdentificatorType
            {
                IdentificatorTypeId = itm.IdentificatorTypeId,
                IdentificatorTypeName = itm.IdentificatorTypeName,
                IdentificatorTypeCode = itm.IdentificatorTypeCode,
            }));
        }
        public ActionResult IdentificatorTypeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<IdentificatorType> item)
        {
            var entities = new List<IdentificatorType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new IdentificatorType
                        {
                            IdentificatorTypeId = itm.IdentificatorTypeId,
                            IdentificatorTypeName = itm.IdentificatorTypeName,
                            IdentificatorTypeCode = itm.IdentificatorTypeCode,
                        };
                        entities.Add(entity);
                        db.IdentificatorTypes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new IdentificatorType
            {
                IdentificatorTypeId = itm.IdentificatorTypeId,
                IdentificatorTypeName = itm.IdentificatorTypeName,
                IdentificatorTypeCode = itm.IdentificatorTypeCode,
            }));
        }
        public ActionResult IdentificatorTypeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<IdentificatorType> item)
        {
            var entities = new List<IdentificatorType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new IdentificatorType
                        {
                            IdentificatorTypeId = itm.IdentificatorTypeId,
                            IdentificatorTypeName = itm.IdentificatorTypeName,
                            IdentificatorTypeCode = itm.IdentificatorTypeCode,
                        };
                        entities.Add(entity);
                        db.IdentificatorTypes.Attach(entity);
                        db.IdentificatorTypes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new IdentificatorType
            {
                IdentificatorTypeId = itm.IdentificatorTypeId,
                IdentificatorTypeName = itm.IdentificatorTypeName,
                IdentificatorTypeCode = itm.IdentificatorTypeCode,
            }));
        }
        #endregion

        #region InitiationType
        public ActionResult InitiationType()
        {
            return View();
        }
        public ActionResult InitiationTypeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<InitiationType> item = db.InitiationTypes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult InitiationTypeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InitiationType> item)
        {
            var entities = new List<InitiationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InitiationType
                        {
                            InitiationTypeName = itm.InitiationTypeName,
                            InitiationTypeCode = itm.InitiationTypeCode,
                        };
                        db.InitiationTypes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InitiationType
            {
                InitiationTypeId = itm.InitiationTypeId,
                InitiationTypeName = itm.InitiationTypeName,
                InitiationTypeCode = itm.InitiationTypeCode,
            }));
        }
        public ActionResult InitiationTypeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InitiationType> item)
        {
            var entities = new List<InitiationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InitiationType
                        {
                            InitiationTypeId = itm.InitiationTypeId,
                            InitiationTypeName = itm.InitiationTypeName,
                            InitiationTypeCode = itm.InitiationTypeCode,
                        };
                        entities.Add(entity);
                        db.InitiationTypes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InitiationType
            {
                InitiationTypeId = itm.InitiationTypeId,
                InitiationTypeName = itm.InitiationTypeName,
                InitiationTypeCode = itm.InitiationTypeCode,
            }));
        }
        public ActionResult InitiationTypeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InitiationType> item)
        {
            var entities = new List<InitiationType>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InitiationType
                        {
                            InitiationTypeId = itm.InitiationTypeId,
                            InitiationTypeName = itm.InitiationTypeName,
                            InitiationTypeCode = itm.InitiationTypeCode,
                        };
                        entities.Add(entity);
                        db.InitiationTypes.Attach(entity);
                        db.InitiationTypes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InitiationType
            {
                InitiationTypeId = itm.InitiationTypeId,
                InitiationTypeName = itm.InitiationTypeName,
                InitiationTypeCode = itm.InitiationTypeCode,
            }));
        }
        #endregion

        #region InvocationStatus
        public ActionResult InvocationStatus()
        {
            return View();
        }
        public ActionResult InvocationStatusRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<InvocationStatus> item = db.InvocationStatuses;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult InvocationStatusCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InvocationStatus> item)
        {
            var entities = new List<InvocationStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InvocationStatus
                        {
                            InvocationStatusName = itm.InvocationStatusName,
                            InvocationStatusCode = itm.InvocationStatusCode,
                        };
                        db.InvocationStatuses.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InvocationStatus
            {
                InvocationStatusId = itm.InvocationStatusId,
                InvocationStatusName = itm.InvocationStatusName,
                InvocationStatusCode = itm.InvocationStatusCode,
            }));
        }
        public ActionResult InvocationStatusUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InvocationStatus> item)
        {
            var entities = new List<InvocationStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InvocationStatus
                        {
                            InvocationStatusId = itm.InvocationStatusId,
                            InvocationStatusName = itm.InvocationStatusName,
                            InvocationStatusCode = itm.InvocationStatusCode,
                        };
                        entities.Add(entity);
                        db.InvocationStatuses.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InvocationStatus
            {
                InvocationStatusId = itm.InvocationStatusId,
                InvocationStatusName = itm.InvocationStatusName,
                InvocationStatusCode = itm.InvocationStatusCode,
            }));
        }
        public ActionResult InvocationStatusDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<InvocationStatus> item)
        {
            var entities = new List<InvocationStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new InvocationStatus
                        {
                            InvocationStatusId = itm.InvocationStatusId,
                            InvocationStatusName = itm.InvocationStatusName,
                            InvocationStatusCode = itm.InvocationStatusCode,
                        };
                        entities.Add(entity);
                        db.InvocationStatuses.Attach(entity);
                        db.InvocationStatuses.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new InvocationStatus
            {
                InvocationStatusId = itm.InvocationStatusId,
                InvocationStatusName = itm.InvocationStatusName,
                InvocationStatusCode = itm.InvocationStatusCode,
            }));
        }
        #endregion

        #region Outcome
        public ActionResult Outcome()
        {
            return View();
        }
        public ActionResult OutcomeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<Outcome> item = db.Outcomes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult OutcomeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Outcome> item)
        {
            var entities = new List<Outcome>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Outcome
                        {
                            OutcomeName = itm.OutcomeName,
                            OutcomeCode = itm.OutcomeCode,
                        };
                        db.Outcomes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Outcome
            {
                OutcomeId = itm.OutcomeId,
                OutcomeName = itm.OutcomeName,
                OutcomeCode = itm.OutcomeCode,
            }));
        }
        public ActionResult OutcomeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Outcome> item)
        {
            var entities = new List<Outcome>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Outcome
                        {
                            OutcomeId = itm.OutcomeId,
                            OutcomeName = itm.OutcomeName,
                            OutcomeCode = itm.OutcomeCode,
                        };
                        entities.Add(entity);
                        db.Outcomes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Outcome
            {
                OutcomeId = itm.OutcomeId,
                OutcomeName = itm.OutcomeName,
                OutcomeCode = itm.OutcomeCode,
            }));
        }
        public ActionResult OutcomeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Outcome> item)
        {
            var entities = new List<Outcome>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Outcome
                        {
                            OutcomeId = itm.OutcomeId,
                            OutcomeName = itm.OutcomeName,
                            OutcomeCode = itm.OutcomeCode,
                        };
                        entities.Add(entity);
                        db.Outcomes.Attach(entity);
                        db.Outcomes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Outcome
            {
                OutcomeId = itm.OutcomeId,
                OutcomeName = itm.OutcomeName,
                OutcomeCode = itm.OutcomeCode,
            }));
        }
        #endregion

        #region ReferralPurpose
        public ActionResult ReferralPurpose()
        {
            return View();
        }
        public ActionResult ReferralPurposeRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralPurpose> item = db.ReferralPurposes;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult ReferralPurposeCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralPurpose> item)
        {
            var entities = new List<ReferralPurpose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralPurpose
                        {
                            ReferralPurposeName = itm.ReferralPurposeName,
                            ReferralPurposeCode = itm.ReferralPurposeCode,
                        };
                        db.ReferralPurposes.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralPurpose
            {
                ReferralPurposeId = itm.ReferralPurposeId,
                ReferralPurposeName = itm.ReferralPurposeName,
                ReferralPurposeCode = itm.ReferralPurposeCode,
            }));
        }
        public ActionResult ReferralPurposeUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralPurpose> item)
        {
            var entities = new List<ReferralPurpose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralPurpose
                        {
                            ReferralPurposeId = itm.ReferralPurposeId,
                            ReferralPurposeName = itm.ReferralPurposeName,
                            ReferralPurposeCode = itm.ReferralPurposeCode,
                        };
                        entities.Add(entity);
                        db.ReferralPurposes.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralPurpose
            {
                ReferralPurposeId = itm.ReferralPurposeId,
                ReferralPurposeName = itm.ReferralPurposeName,
                ReferralPurposeCode = itm.ReferralPurposeCode,
            }));
        }
        public ActionResult ReferralPurposeDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralPurpose> item)
        {
            var entities = new List<ReferralPurpose>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralPurpose
                        {
                            ReferralPurposeId = itm.ReferralPurposeId,
                            ReferralPurposeName = itm.ReferralPurposeName,
                            ReferralPurposeCode = itm.ReferralPurposeCode,
                        };
                        entities.Add(entity);
                        db.ReferralPurposes.Attach(entity);
                        db.ReferralPurposes.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralPurpose
            {
                ReferralPurposeId = itm.ReferralPurposeId,
                ReferralPurposeName = itm.ReferralPurposeName,
                ReferralPurposeCode = itm.ReferralPurposeCode,
            }));
        }
        #endregion

        #region ReferralStatus
        public ActionResult ReferralStatus()
        {
            return View();
        }
        public ActionResult ReferralStatusRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<ReferralStatus> item = db.ReferralStatuses;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult ReferralStatusCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralStatus> item)
        {
            var entities = new List<ReferralStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralStatus
                        {
                            ReferralStatusName = itm.ReferralStatusName,
                            ReferralStatusCode = itm.ReferralStatusCode,
                        };
                        db.ReferralStatuses.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralStatus
            {
                ReferralStatusId = itm.ReferralStatusId,
                ReferralStatusName = itm.ReferralStatusName,
                ReferralStatusCode = itm.ReferralStatusCode,
            }));
        }
        public ActionResult ReferralStatusUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralStatus> item)
        {
            var entities = new List<ReferralStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralStatus
                        {
                            ReferralStatusId = itm.ReferralStatusId,
                            ReferralStatusName = itm.ReferralStatusName,
                            ReferralStatusCode = itm.ReferralStatusCode,
                        };
                        entities.Add(entity);
                        db.ReferralStatuses.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralStatus
            {
                ReferralStatusId = itm.ReferralStatusId,
                ReferralStatusName = itm.ReferralStatusName,
                ReferralStatusCode = itm.ReferralStatusCode,
            }));
        }
        public ActionResult ReferralStatusDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReferralStatus> item)
        {
            var entities = new List<ReferralStatus>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new ReferralStatus
                        {
                            ReferralStatusId = itm.ReferralStatusId,
                            ReferralStatusName = itm.ReferralStatusName,
                            ReferralStatusCode = itm.ReferralStatusCode,
                        };
                        entities.Add(entity);
                        db.ReferralStatuses.Attach(entity);
                        db.ReferralStatuses.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new ReferralStatus
            {
                ReferralStatusId = itm.ReferralStatusId,
                ReferralStatusName = itm.ReferralStatusName,
                ReferralStatusCode = itm.ReferralStatusCode,
            }));
        }
        #endregion

        #region Region
        public ActionResult Region()
        {
            return View();
        }
        public ActionResult RegionRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<Region> item = db.Regions;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult RegionCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Region> item)
        {
            var entities = new List<Region>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Region
                        {
                            RegionName = itm.RegionName,
                            RegionCode = itm.RegionCode,
                        };
                        db.Regions.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Region
            {
                RegionId = itm.RegionId,
                RegionName = itm.RegionName,
                RegionCode = itm.RegionCode,
            }));
        }
        public ActionResult RegionUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Region> item)
        {
            var entities = new List<Region>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Region
                        {
                            RegionId = itm.RegionId,
                            RegionName = itm.RegionName,
                            RegionCode = itm.RegionCode,
                        };
                        entities.Add(entity);
                        db.Regions.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Region
            {
                RegionId = itm.RegionId,
                RegionName = itm.RegionName,
                RegionCode = itm.RegionCode,
            }));
        }
        public ActionResult RegionDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Region> item)
        {
            var entities = new List<Region>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new Region
                        {
                            RegionId = itm.RegionId,
                            RegionName = itm.RegionName,
                            RegionCode = itm.RegionCode,
                        };
                        entities.Add(entity);
                        db.Regions.Attach(entity);
                        db.Regions.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new Region
            {
                RegionId = itm.RegionId,
                RegionName = itm.RegionName,
                RegionCode = itm.RegionCode,
            }));
        }
        #endregion

        #region SocialDisease
        public ActionResult SocialDisease()
        {
            return View();
        }
        public ActionResult SocialDiseaseRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<SocialDisease> item = db.SocialDiseases;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult SocialDiseaseCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialDisease> item)
        {
            var entities = new List<SocialDisease>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialDisease
                        {
                            SocialDiseaseName = itm.SocialDiseaseName,
                            SocialDiseaseCode = itm.SocialDiseaseCode,
                        };
                        db.SocialDiseases.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialDisease
            {
                SocialDiseaseId = itm.SocialDiseaseId,
                SocialDiseaseName = itm.SocialDiseaseName,
                SocialDiseaseCode = itm.SocialDiseaseCode,
            }));
        }
        public ActionResult SocialDiseaseUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialDisease> item)
        {
            var entities = new List<SocialDisease>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialDisease
                        {
                            SocialDiseaseId = itm.SocialDiseaseId,
                            SocialDiseaseName = itm.SocialDiseaseName,
                            SocialDiseaseCode = itm.SocialDiseaseCode,
                        };
                        entities.Add(entity);
                        db.SocialDiseases.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialDisease
            {
                SocialDiseaseId = itm.SocialDiseaseId,
                SocialDiseaseName = itm.SocialDiseaseName,
                SocialDiseaseCode = itm.SocialDiseaseCode,
            }));
        }
        public ActionResult SocialDiseaseDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialDisease> item)
        {
            var entities = new List<SocialDisease>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialDisease
                        {
                            SocialDiseaseId = itm.SocialDiseaseId,
                            SocialDiseaseName = itm.SocialDiseaseName,
                            SocialDiseaseCode = itm.SocialDiseaseCode,
                        };
                        entities.Add(entity);
                        db.SocialDiseases.Attach(entity);
                        db.SocialDiseases.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialDisease
            {
                SocialDiseaseId = itm.SocialDiseaseId,
                SocialDiseaseName = itm.SocialDiseaseName,
                SocialDiseaseCode = itm.SocialDiseaseCode,
            }));
        }
        #endregion

        #region SocialGroup
        public ActionResult SocialGroup()
        {
            return View();
        }
        public ActionResult SocialGroupRead([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new StoreContext())
            {
                IQueryable<SocialGroup> item = db.SocialGroups;
                DataSourceResult result = item.ToDataSourceResult(request);
                return Json(result);
            }
        }
        public ActionResult SocialGroupCreate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialGroup> item)
        {
            var entities = new List<SocialGroup>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialGroup
                        {
                            SocialGroupName = itm.SocialGroupName,
                            SocialGroupCode = itm.SocialGroupCode,
                        };
                        db.SocialGroups.Add(entity);
                        entities.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialGroup
            {
                SocialGroupId = itm.SocialGroupId,
                SocialGroupName = itm.SocialGroupName,
                SocialGroupCode = itm.SocialGroupCode,
            }));
        }
        public ActionResult SocialGroupUpdate([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialGroup> item)
        {
            var entities = new List<SocialGroup>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialGroup
                        {
                            SocialGroupId = itm.SocialGroupId,
                            SocialGroupName = itm.SocialGroupName,
                            SocialGroupCode = itm.SocialGroupCode,
                        };
                        entities.Add(entity);
                        db.SocialGroups.Attach(entity);
                        db.Entry(entity).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialGroup
            {
                SocialGroupId = itm.SocialGroupId,
                SocialGroupName = itm.SocialGroupName,
                SocialGroupCode = itm.SocialGroupCode,
            }));
        }
        public ActionResult SocialGroupDestroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<SocialGroup> item)
        {
            var entities = new List<SocialGroup>();
            if (ModelState.IsValid)
            {
                using (var db = new StoreContext())
                {
                    foreach (var itm in item)
                    {
                        var entity = new SocialGroup
                        {
                            SocialGroupId = itm.SocialGroupId,
                            SocialGroupName = itm.SocialGroupName,
                            SocialGroupCode = itm.SocialGroupCode,
                        };
                        entities.Add(entity);
                        db.SocialGroups.Attach(entity);
                        db.SocialGroups.Remove(entity);
                    }
                    db.SaveChanges();
                }
            }
            return Json(entities.ToDataSourceResult(request, ModelState, itm => new SocialGroup
            {
                SocialGroupId = itm.SocialGroupId,
                SocialGroupName = itm.SocialGroupName,
                SocialGroupCode = itm.SocialGroupCode,
            }));
        }
        #endregion
    }
}