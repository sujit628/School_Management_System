using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Management_System.Models;
using System.Security.Cryptography.X509Certificates;

namespace School_Management_System.DAL
{
    public class SMS_DAL

    {   
        string str = "Data Source=DESKTOP-I0QCKM4\\SQLEXPRESS;Initial Catalog=New_SMS;Integrated Security=True;";

        public DataTable Student_Login(student obj)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                string q = "select * from Student where Gmail= '" + obj.Email + "' and Password= '" + obj.Password + "' ";
                SqlDataAdapter d = new SqlDataAdapter(q, con);
                d.Fill(dt);
            }
            return dt;
        }
        
        
        public DataTable Teachers_Login(TeacherDetails obj)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                string q = "select * from TeacherDetails where TeacherEmail= '" + obj.TeacherEmail + "' and Password= '" + obj.Password + "' ";
                SqlDataAdapter d = new SqlDataAdapter(q, con);
                d.Fill(dt);
            }
            return dt;
        }

       
    }
}


