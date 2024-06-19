using School_Management_System.DAL;
using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace School_Management_System.Controllers
{
    public class ClassDetailsController : Controller
    {

        ClassDetailsDAL DALOBJ = new ClassDetailsDAL();

        public ActionResult Index()
        {
            return View(DALOBJ.GetDataList());
        }


        [HttpGet]
        public ActionResult AddOrEdit(int? id)
        {
            if (id != null)
            {
                return View(DALOBJ.GetDataList().Find(ur => ur.Id == id));
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(ClassDetails classDetails)
        {
            if (classDetails.Id == null) DALOBJ.Add(classDetails);
            else DALOBJ.UpdateData(classDetails);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DALOBJ.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}