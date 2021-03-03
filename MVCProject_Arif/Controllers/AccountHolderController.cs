using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.IO;
using MVCProject_Arif.Models;
using System.Data.Entity;

namespace MVCProject_Arif.Controllers
{
    public class AccountHolderController : Controller
    {
        // GET: HEmployee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<BAccountHolder> GetAllEmployee()
        {
            using (BankSystemDB_ArifEntities db = new BankSystemDB_ArifEntities())
            {
                return db.BAccountHolders.ToList<BAccountHolder>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            BAccountHolder emp = new BAccountHolder();
            if (id != 0)
            {
                using (BankSystemDB_ArifEntities db = new BankSystemDB_ArifEntities())
                {
                    emp = db.BAccountHolders.Where(x => x.BAccountHolderID == id).FirstOrDefault<BAccountHolder>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(BAccountHolder emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (BankSystemDB_ArifEntities db = new BankSystemDB_ArifEntities())
                {
                    if (emp.BAccountHolderID == 0)
                    {
                        db.BAccountHolders.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (BankSystemDB_ArifEntities db = new BankSystemDB_ArifEntities())
                {
                    BAccountHolder emp = db.BAccountHolders.Where(x => x.BAccountHolderID == id).FirstOrDefault<BAccountHolder>();
                    db.BAccountHolders.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}