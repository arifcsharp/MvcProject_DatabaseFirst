using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;



using System.Threading.Tasks;
using AutoMapper;
using MVCProject_Arif.ViewModels;
using MVCProject_Arif.Models;
using System.Net;
using System.Data.Entity;
using PagedList;

namespace MVCProject_Arif.Controllers
{
    [RoutePrefix("EmployeeInfo")]
    public class EmployeeController : Controller
    {
        private BankSystemDB_ArifEntities db = new BankSystemDB_ArifEntities();
        // GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}


        [Route("Home")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var employees = from t in db.Employees
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(t => t.EmployeeName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(t => t.EmployeeName);
                    break;
                default:
                    employees = employees.OrderBy(t => t.EmployeeName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }
        // (End - 01)

        //Get Employee  Create
        public ActionResult Create()
        {
            return View();
        }
        //Post : Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<Employee>(employeeVM);
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeVM);
        }
        


        
        public ActionResult Edit(int? id)
        {
            var query = db.Employees.Single(t => t.EmployeeID == id);
            var employee = Mapper.Map<Employee, EmployeeVM>(query);
            return View(employee);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var employee = Mapper.Map<Employee>(employeeVM);
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }
        // (End - 03)

        
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            var query = db.Employees.Single(t => t.EmployeeID == id);
            var employee = Mapper.Map<Employee, EmployeeVM>(query);
            return View(employee);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, EmployeeVM employeeVM)
        {
            var query = db.Employees.Single(t => t.EmployeeID == id);
            var employee = Mapper.Map<Employee, EmployeeVM>(query);
            db.Employees.Remove(query);  // 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // (End - 04)

        


        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = db.Employees.Single(t => t.EmployeeID == id);
            var employee = Mapper.Map<Employee, EmployeeVM>(query);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        // (End - 05)

        public ActionResult Partial_Employee()
        {
            return View(db.Employees.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}