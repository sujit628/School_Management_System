using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Management_System.Models;
using School_Management_System.DAL;
using System.IO;

namespace School_Management_System.Controllers
{
    public class StudentController : Controller
    {
        Student_DAL DALOBJ = new Student_DAL();
        ClassDetailsDAL DALOBJCLASS = new ClassDetailsDAL();
        ClassDetailsDAL classDetail = new ClassDetailsDAL();
        // GET: Student
        public ActionResult studentAdmission(string email)
        {
            if (email != null)
            {
                var a = DALOBJ.GetDataList().Find(x => x.Email == email);
           
                string[] cls = a.Class.Split(' ');
                a.Class = cls[0] +" "+ (Convert.ToInt32(cls[1])+1);
                return View(a);

            }
            return View("Singup", "Home");
        }


        [HttpPost]
        public ActionResult studentAdmission(student obj, HttpPostedFileBase Image, HttpPostedFileBase MarkSheetImage)
        {
            if (obj.Image != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Images"), Image.FileName);
                Image.SaveAs(path);
                obj.Image = Image.FileName;
            }
            if (obj.MarkSheetImage != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Images"), MarkSheetImage.FileName);
                MarkSheetImage.SaveAs(path);
                obj.MarkSheetImage = MarkSheetImage.FileName;
            }
            if (DALOBJ.StudentAdmission(obj))
            {
                Session["Email"] = obj.Email;
                Session["Class"] = obj.Class;
                return RedirectToAction("AdmissionReceipt", "Student");
            }
            return View();
        }

        public ActionResult AdmissionReceipt()
        {
            var data = DALOBJ.GetAdmissionDataList().Find(ur => ur.Email == Session["Email"].ToString());

            ViewBag.classdata = DALOBJCLASS.GetDataList().Find(ur => ur.ClassName == Session["Class"].ToString());

            return View(data);

        }

        //HomePage
        public ActionResult StudentPanel()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            return RedirectToAction("StudentLogin","Home");
        }


        //Request From TeachersPanel
        public ActionResult StudentPageView()
        {
            if (Session["TeacherEmail"] != null)
            {
                ModelState.Clear();
                return View(DALOBJ.GetDataList());
            }
            return RedirectToAction("teachersLogin", "Home");
        }


        public ActionResult StudentAddEdit(int? id)
        {

            if (Session["TeacherEmail"] != null)
            {
                List<ClassDetails> classes = classDetail.GetDataList();
                ViewBag.classes = classes;
                    if (id != null)
                {
                    ViewBag.Date = true;
                    return View(DALOBJ.GetDataList().Find(ur => ur.S_ID == id));
                }
                ViewBag.Date = false;
                return View();
            }
            return RedirectToAction("teachersLogin", "Home");
        }


        [HttpPost]
        public ActionResult StudentAddEdit(student obj, HttpPostedFileBase Image, HttpPostedFileBase MarkSheetImage)
        {

            if (obj.S_ID == 0) {
                if (DALOBJ.GetDataList().Any(x => x.Email == obj.Email))
                {
                    TempData["SingupMsg"] = "Email Already Exist";
                    return View();
                }
                
            }
            if (obj.Image != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Images"), Image.FileName);
                Image.SaveAs(path);
                obj.Image = Image.FileName;
            }
            if (obj.MarkSheetImage != null)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Images"), MarkSheetImage.FileName);
                MarkSheetImage.SaveAs(path);
                obj.MarkSheetImage = MarkSheetImage.FileName;
            }
            if (DALOBJ.StudentReg(obj))
            {
                return RedirectToAction("StudentPageView");
            }
            return View();

        }



        public ActionResult DeleteStudentRecord(int id)
        {
            DALOBJ.DeleteStudent(id)
 ;
            return RedirectToAction("StudentPageView");
        }

        public ActionResult StudentView()
        {
            if (Session["TeacherEmail"] != null)
            {
                ModelState.Clear();
                var list = DALOBJ.GetDataList();
                return View(list);
            }
            return RedirectToAction("teachersLogin", "Home");
        }

        public ActionResult AddmissionTermCondition()
        {

            if (Session["UserName"] != null)
            {
                return View();
            }
            return RedirectToAction("StudentLogin", "Home");
        }


        public ActionResult StudentAdmissionPageView()
        {
            if (Session["TeacherEmail"] != null)
            {
                ModelState.Clear();
                return View(DALOBJ.GetAdmissionDataList());
            }
            return RedirectToAction("teachersLogin", "Home");
        }

        public ActionResult StudentAdmissionAddEdit(int? id)
        {
            if (Session["TeacherEmail"] != null)
            {
                if (id != null)
                {
                    return View(DALOBJ.GetAdmissionDataList().Find(ur => ur.S_ID == id));
                }
                return View();
            }
            return RedirectToAction("teachersLogin", "Home");
        }


        public ActionResult Holiday()
        {
            return View();

        }

        public ActionResult Events()
        {
            return View();
        }

    }
}