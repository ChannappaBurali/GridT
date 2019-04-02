using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridTask.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace GridTask.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Company Emp)
        {
            return View();
        }


        public ActionResult BindGrid([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
               // decimal companyId = 0;
                List<Models.Company> lst = new List<Models.Company>();
                // lst = GetGridData(Convert.ToInt32(companyId)).ToList();
                DataSourceResult result = lst.ToDataSourceResult(request, p => new Models.Company
                {
                    Id = p.Id,
                    Name = p.Name,
                    CompanyId = p.CompanyId,
                });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                return Json(errorMsg, JsonRequestBehavior.AllowGet);
            }
        }
        public IEnumerable<Models.Company> GetGridData(Company Emp)
        {
            Company Emp1 = new Company();
            Emp1.Id = Emp.Id;
            Emp1.Name = Emp.Name;
            Emp1.CompanyId = Emp.CompanyId;
            List<Models.Company> objCmp = new List<Models.Company>();
            //List<Models.Company> listCompany = new List<Models.Company>();
            //objCmp.Add(new Models.Company() { Id = 1, Name = "Rupesh Kahane", CompanyId = 20 });
            //objCmp.Add(new Models.Company() { Id = 2, Name = "Vithal Wadje", CompanyId = 40 });
            //objCmp.Add(new Models.Company() { Id = 3, Name = "Jeetendra Gund", CompanyId = 30 });
            //objCmp.Add(new Models.Company() { Id = 4, Name = "Ashish Mane", CompanyId = 15 });
            //objCmp.Add(new Models.Company() { Id = 5, Name = "Rinku Kulkarni", CompanyId = 18 });
            //objCmp.Add(new Models.Company() { Id = 6, Name = "Priyanka Jain", CompanyId = 22 });
            //if (companyId > 0)
            //{
            //    listCompany = objCmp.ToList().Where(a => a.CompanyId <= companyId).ToList();
            //    return listCompany.AsEnumerable();
            //}
            objCmp.Add(Emp1);
            return objCmp.ToList().AsEnumerable();
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

    }
}