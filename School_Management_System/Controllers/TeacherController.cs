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
    public class TeacherController : Controller
    {
        Teacher_DAL DALOBJ = new Teacher_DAL();
        Student_DAL Student_DAL = new Student_DAL();
        #region TeacherDetails

        //Teching Dasbord
        public ActionResult TeachingPanel()
        {
            if (Session["TeacherEmail"] != null)
            {
                ViewBag.TotalTeacher =DALOBJ.ListOfTeachersData().Count();
                ViewBag.TotalStudent = Student_DAL.GetDataList().Count();
                return View();
            }
            return RedirectToAction("teachersLogin","Home");
        }


        public ActionResult TeachersViewPage()
        {
            if (Session["TeacherEmail"] != null)
            {
                var data = DALOBJ.ListOfTeachersData();
                return View(data);
            }
            return RedirectToAction("teachersLogin", "Home");
        }


        public ActionResult AddEditTeacherDetails(int? id)
        {
            if (Session["TeacherEmail"] != null)
            {
                if (id != null)
                {
                    var data = DALOBJ.ListOfTeachersData().Find(m => m.TeacherID == id);
                    return View(data);
                }
                else
                {
                    ViewBag.joiningDate = "JoinDateOnly";
                    return View();
                }
            }
            return RedirectToAction("teachersLogin", "Home");

        }


        [HttpPost]
        public ActionResult AddEditTeacherDetails(TeacherDetails obj, HttpPostedFileBase TeacherImage)
        {
            if (obj.TeacherID != 0)
            {
                if (obj.TeacherImage != null)
                {

                    if (System.IO.File.Exists(obj.ImagePriview))
                    {
                        string currentImagePath = Path.Combine(Server.MapPath("~/Content/Images"), obj.ImagePriview);
                        System.IO.File.Delete(currentImagePath);
                    }
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), TeacherImage.FileName);
                    TeacherImage.SaveAs(path);
                    obj.TeacherImage = TeacherImage.FileName;
                }
                DALOBJ.AddEditTeacherDetails(obj);
            }
            else
            {
                if (obj.TeacherImage != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), TeacherImage.FileName);
                    TeacherImage.SaveAs(path);
                    obj.TeacherImage = TeacherImage.FileName;
                }
                DALOBJ.AddEditTeacherDetails(obj);

            }

            return RedirectToAction("TeachersViewPage");
        }



        public ActionResult DeleteTeacherDetails(int id)
        {

            DALOBJ.DeleteTeacherDetails(id);
            TempData["alert"] = "Data Successfully Deleted ...!";

            return RedirectToAction("TeachersViewPage");

        }


        public ActionResult TeacherDetailsView(int Id)
        {
            if (Session["TeacherEmail"] != null)
            {
                var data = DALOBJ.ListOfTeachersData().Find(m => m.TeacherID == Id);
                return View(data);
            }
            return RedirectToAction("teachersLogin", "Home");
        }


        public ActionResult TeacherProfile()
        {
            var teacherEmail = Session["TeacherEmail"] as string;
            var data = DALOBJ.ListOfTeachersData().Find(m => m.TeacherName == teacherEmail);
            return View(data);
           
        }


        public ActionResult TeacherDetailsCardView()
        {
            var data = DALOBJ.ListOfTeachersData();
            return View(data);
        }

        #endregion
    }
}