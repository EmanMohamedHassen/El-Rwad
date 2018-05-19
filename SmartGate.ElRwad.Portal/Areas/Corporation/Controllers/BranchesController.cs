using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGate.ElRwad.BLL;
using System.Threading.Tasks;
using SmartGate.ElRwad.BLL.HR;

namespace SmartGate.ElRwad.Portal.Areas.Corporation.Controllers
{
    public class BranchesController : Controller
    {
        // GET: Coding/Branches
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Save(BranchesVM branchesVM)
        {
            var msgModel = BranchesManager.Instance.PostBranch(branchesVM);

            return Json(msgModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var branches= BranchesManager.Instance.GetBranches();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllEmployees()
        {
            var employee = EmployeeManager.Instance.GetActiveEmployees();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCompanies()
        {
            var companies = CompaniesManager.Instance.GetAllCompanies();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
    }
}