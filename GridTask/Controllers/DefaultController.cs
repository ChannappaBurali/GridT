using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridTask.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using GridTask.Models;
using System.Data.Entity;

namespace GridTask.Controllers
{
    public class DefaultController : Controller
    {
        TESTEntities db = new TESTEntities();
        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Emp emp)
        {
 
            return View(emp);
        }
        public ActionResult DataDisplay(Emp emp)
        {                      
            return View(emp);           
        }
        [HttpGet]
        public ActionResult GetData(Emp emp)
        {
           // Emp ems = new Emp();
           //TempData["id"] = emp.Id;
           // TempData["Name"] = emp.Name;
           // TempData["Address"] = emp.Address;

          return  RedirectToAction("Index");

        }
        public ActionResult BindGrid([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetGridData().ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<Emp> GetGridData()
        {
          //  Emp Emp1 = new Emp();
            return db.Employees.Select(em => new Emp
            {
                Id = em.Id,
               Name = em.Name,                
                Address = em.Address,
                
            });
        }

        public ActionResult FormDt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormDt(Company Emp)
        {
            return View();
        }

        [HttpPost]
        public void Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Emp> emp)
        {
          
            foreach(var item in  emp)
            {
                Employee em = new Employee();
                em.Name = item.Name;
                em.Address = item.Address;
                db.Employees.Add(em);
                db.SaveChanges();              
            }                 
        }
        [HttpPost]
        public void Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Emp> emp)
        {
            
            foreach (var item in emp)
            {
                Employee em = new Employee();              
                em.Id = item.Id;
                em.Name = item.Name;
                em.Address = item.Address;              
                db.Entry(em).State = EntityState.Modified;
                db.SaveChanges();                
            }
        }

        [HttpPost]
        public void Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Emp> emp)
        {
           
            foreach (var item in emp)
            {               
                var entity = new Employee();
                Employee em = db.Employees.Find(item.Id);
                db.Employees.Remove(em);
                db.SaveChanges();                

            }

        }

    }
}