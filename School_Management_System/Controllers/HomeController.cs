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
    public class HomeController : Controller
    {
        Student_DAL Std_DALOBJ = new Student_DAL();
        SMS_DAL DALOBJ = new SMS_DAL();
        string str = "Data Source=(localdb)\\ProjectModels;Initial Catalog=SMS;Integrated Security=True";

        public ActionResult Index()
        {
            return View();
        }

        //Student
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(student obj)
        {
            DataTable dt = new DataTable();
           
           dt= DALOBJ.Student_Login(obj);
            if (dt.Rows.Count == 1)
            {
                HttpCookie cookie = new HttpCookie("UserName");
                cookie.Value = dt.Rows[0][16].ToString();
                HttpContext.Response.Cookies.Add(cookie);
                ViewBag.value = Request.Cookies["UserName"].Value;
                Session["UserName"] = dt.Rows[0][16].ToString();

                return RedirectToAction("StudentPanel","Student");
                
            }
           
            return View();
        }

      
        //Teachers
        public ActionResult teachersLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult teachersLogin(TeacherDetails obj)
        {
            DataTable dt = new DataTable();

            dt = DALOBJ.Teachers_Login(obj);
            if (dt.Rows.Count == 1)
            {
               HttpCookie cookie = new HttpCookie("TeacherEmail");
               cookie.Value = dt.Rows[0][1].ToString();

               HttpContext.Response.Cookies.Add(cookie);

               ViewBag.value = Request.Cookies["TeacherEmail"].Value;

               Session["TeacherEmail"] = dt.Rows[0][1].ToString();
               
                return RedirectToAction("TeachingPanel","Teacher");
            }
            
            return View();
        }



        //Logout
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }


        public ActionResult StudentSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentSignup(student obj)
        {
            if (Std_DALOBJ.GetDataList().Any(x => x.Email == obj.Email))
            {
                TempData["SingupMsg"] = "Email Already Exist";
                return View();
            }
            if (Std_DALOBJ.StudentReg(obj))
            {
                Session["UserName"] = obj.Email;
                return RedirectToAction("StudentPanel", "Student");
            }


            return View();
        }
    }
}