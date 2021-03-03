using MVCProject_Arif.Models;
using System.Linq;
using System.Web.Mvc;
namespace MVCProject_Arif.Controllers
{
    public class CustomerAjaxController : Controller
    {
        private BankSystemDB_ArifEntities _context;
        public CustomerAjaxController()
        {
            _context = new BankSystemDB_ArifEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.Customers.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Customer user)
        {
            _context.Customers.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Customers.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Customer user)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Id == ID);
            _context.Customers.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}