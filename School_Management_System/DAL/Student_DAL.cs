using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using School_Management_System.Models;
using System.Web.Mvc;

namespace School_Management_System.DAL
{
    public class Student_DAL
    {
        string str = "Data Source=DESKTOP-I0QCKM4\\SQLEXPRESS;Initial Catalog=New_SMS;Integrated Security=True;";
        public bool StudentReg(student obj)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SpInsertStudentDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentName", obj.Full_Name);
                    command.Parameters.AddWithValue("@FatherName", obj.Father_Name);
                    command.Parameters.AddWithValue("@MotherName", obj.Mother_Name);

                    command.Parameters.AddWithValue("@GuardianName", obj.Guardian_Name);
                    
                    command.Parameters.AddWithValue("@RealtionWithGuardian", obj.RealationWithGuardian);
                    command.Parameters.AddWithValue("@Gender", obj.Gender);

                    command.Parameters.AddWithValue("@DOB", obj.DOB);
                    command.Parameters.AddWithValue("@Address", obj.Adrress);
                    command.Parameters.AddWithValue("@PO", obj.PO);
                    command.Parameters.AddWithValue("@Pin", obj.Pin);
                    command.Parameters.AddWithValue("@State", obj.State);
                    command.Parameters.AddWithValue("@Country", obj.Country);

                    command.Parameters.AddWithValue("@AadharNO", obj.Aadhar_NO);
                    command.Parameters.AddWithValue("@PermanentMobile", obj.Phone);
                    command.Parameters.AddWithValue("@Gmail", obj.Email);
                    command.Parameters.AddWithValue("@Password", obj.Password);

                    command.Parameters.AddWithValue("@Class", obj.Class);
                    command.Parameters.AddWithValue("@Section", obj.Section);
                    command.Parameters.AddWithValue("@RollNo", obj.RollNo);
                    command.Parameters.AddWithValue("@Image", obj.Image);
                    command.Parameters.AddWithValue("@MarkSheetImage", obj.MarkSheetImage);
                    command.Parameters.AddWithValue("@GurdianPhoneNo", obj.GurdianPhoneNo);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }



        public List<student> GetDataList()
        {
            List<student> lst = new List<student>();
            using (SqlConnection con = new SqlConnection(str))
            {
                string q = "Select * from Student";
                SqlCommand cmd = new SqlCommand(q, con);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(new student
                    {
                        S_ID = Convert.IsDBNull(dr["SID"]) ? 0 : Convert.ToInt32(dr["SID"]),
                        Phone = Convert.IsDBNull(dr["PermanentMobile"]) ? 0 : Convert.ToInt64(dr["PermanentMobile"]),
                        GurdianPhoneNo = Convert.IsDBNull(dr["GurdianPhoneNo"]) ? 0 : Convert.ToInt64(dr["GurdianPhoneNo"]),
                        Password = Convert.IsDBNull(dr["Password"]) ? string.Empty : Convert.ToString(dr["Password"]),
                        Full_Name = Convert.IsDBNull(dr["StudentName"]) ? string.Empty : Convert.ToString(dr["StudentName"]),
                        Father_Name = Convert.IsDBNull(dr["FatherName"]) ? string.Empty : Convert.ToString(dr["FatherName"]),
                        Mother_Name = Convert.IsDBNull(dr["MotherName"]) ? string.Empty : Convert.ToString(dr["MotherName"]),
                        Guardian_Name = Convert.IsDBNull(dr["GuardianName"]) ? string.Empty : Convert.ToString(dr["GuardianName"]),
                        RealationWithGuardian = Convert.IsDBNull(dr["RealtionWithGuardian"]) ? string.Empty : Convert.ToString(dr["RealtionWithGuardian"]),
                        Gender = Convert.IsDBNull(dr["Gender"]) ? string.Empty : Convert.ToString(dr["Gender"]),
                        DOB = Convert.IsDBNull(dr["DOB"]) ? DateTime.MinValue : Convert.ToDateTime(dr["DOB"]),
                        Adrress = Convert.IsDBNull(dr["Address"]) ? string.Empty : Convert.ToString(dr["Address"]),
                        PO = Convert.IsDBNull(dr["PO"]) ? string.Empty : Convert.ToString(dr["PO"]),
                        Pin = Convert.IsDBNull(dr["Pin"]) ? string.Empty : Convert.ToString(dr["Pin"]),
                        State = Convert.IsDBNull(dr["State"]) ? string.Empty : Convert.ToString(dr["State"]),
                        Country = Convert.IsDBNull(dr["Country"]) ? string.Empty : Convert.ToString(dr["Country"]),
                        Aadhar_NO = Convert.IsDBNull(dr["AadharNO"]) ? string.Empty : Convert.ToString(dr["AadharNO"]),
                        Email = Convert.ToString(dr["Gmail"]),
                        Class = Convert.IsDBNull(dr["Class"]) ? string.Empty : Convert.ToString(dr["Class"]),
                        Section = Convert.IsDBNull(dr["Section"]) ? string.Empty : Convert.ToString(dr["Section"]),
                        RollNo = Convert.IsDBNull(dr["RollNo"]) ? 0 : Convert.ToInt32(dr["RollNo"]),
                        Image = Convert.IsDBNull(dr["Image"]) ? string.Empty : Convert.ToString(dr["Image"]),
                        MarkSheetImage = Convert.IsDBNull(dr["MarkSheetImage"]) ? string.Empty : Convert.ToString(dr["MarkSheetImage"]),

                    });
                }
            }
            return lst;
        }




        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                string q = "Delete from Student where SID =" + id;
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public bool StudentAdmission(student obj)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SpInsertStudentAdmission", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentName", obj.Full_Name);
                    command.Parameters.AddWithValue("@FatherName", obj.Father_Name);
                    command.Parameters.AddWithValue("@MotherName", obj.Mother_Name);

                    command.Parameters.AddWithValue("@GuardianName", obj.Guardian_Name);

                    command.Parameters.AddWithValue("@RealtionWithGuardian", obj.RealationWithGuardian);
                    command.Parameters.AddWithValue("@Gender", obj.Gender);

                    command.Parameters.AddWithValue("@DOB", obj.DOB);
                    command.Parameters.AddWithValue("@Address", obj.Adrress);
                    command.Parameters.AddWithValue("@PO", obj.PO);
                    command.Parameters.AddWithValue("@Pin", obj.Pin);
                    command.Parameters.AddWithValue("@State", obj.State);
                    command.Parameters.AddWithValue("@Country", obj.Country);

                    command.Parameters.AddWithValue("@AadharNO", obj.Aadhar_NO);
                    command.Parameters.AddWithValue("@PermanentMobile", obj.Phone);
                    command.Parameters.AddWithValue("@Gmail", obj.Email);

                    command.Parameters.AddWithValue("@Class", obj.Class);
                    command.Parameters.AddWithValue("@Section", obj.Section);
                    command.Parameters.AddWithValue("@RollNo", obj.RollNo);
                    command.Parameters.AddWithValue("@Image", obj.Image);
                    command.Parameters.AddWithValue("@MarkSheetImage", obj.MarkSheetImage);
                    command.Parameters.AddWithValue("@GurdianPhoneNo", obj.GurdianPhoneNo);
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public List<student> GetAdmissionDataList()
        {
            List<student> lst = new List<student>();
            using (SqlConnection con = new SqlConnection(str))
            {
                string q = "Select * from StudentAdmission";
                SqlCommand cmd = new SqlCommand(q, con);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(new student
                    {
                        S_ID = Convert.IsDBNull(dr["SID"]) ? 0 : Convert.ToInt32(dr["SID"]),
                        Phone = Convert.IsDBNull(dr["PermanentMobile"]) ? 0 : Convert.ToInt64(dr["PermanentMobile"]),
                        GurdianPhoneNo = Convert.IsDBNull(dr["GurdianPhoneNo"]) ? 0 : Convert.ToInt64(dr["GurdianPhoneNo"]),
                       
                        Full_Name = Convert.IsDBNull(dr["StudentName"]) ? string.Empty : Convert.ToString(dr["StudentName"]),
                        Father_Name = Convert.IsDBNull(dr["FatherName"]) ? string.Empty : Convert.ToString(dr["FatherName"]),
                        Mother_Name = Convert.IsDBNull(dr["MotherName"]) ? string.Empty : Convert.ToString(dr["MotherName"]),
                        Guardian_Name = Convert.IsDBNull(dr["GuardianName"]) ? string.Empty : Convert.ToString(dr["GuardianName"]),
                        RealationWithGuardian = Convert.IsDBNull(dr["RealtionWithGuardian"]) ? string.Empty : Convert.ToString(dr["RealtionWithGuardian"]),
                        Gender = Convert.IsDBNull(dr["Gender"]) ? string.Empty : Convert.ToString(dr["Gender"]),
                        DOB = Convert.IsDBNull(dr["DOB"]) ? DateTime.MinValue : Convert.ToDateTime(dr["DOB"]),
                        Adrress = Convert.IsDBNull(dr["Address"]) ? string.Empty : Convert.ToString(dr["Address"]),
                        PO = Convert.IsDBNull(dr["PO"]) ? string.Empty : Convert.ToString(dr["PO"]),
                        Pin = Convert.IsDBNull(dr["Pin"]) ? string.Empty : Convert.ToString(dr["Pin"]),
                        State = Convert.IsDBNull(dr["State"]) ? string.Empty : Convert.ToString(dr["State"]),
                        Country = Convert.IsDBNull(dr["Country"]) ? string.Empty : Convert.ToString(dr["Country"]),
                        Aadhar_NO = Convert.IsDBNull(dr["AadharNO"]) ? string.Empty : Convert.ToString(dr["AadharNO"]),
                        Email = Convert.ToString(dr["Gmail"]),
                        Class = Convert.IsDBNull(dr["Class"]) ? string.Empty : Convert.ToString(dr["Class"]),
                        Section = Convert.IsDBNull(dr["Section"]) ? string.Empty : Convert.ToString(dr["Section"]),
                        RollNo = Convert.IsDBNull(dr["RollNo"]) ? 0 : Convert.ToInt32(dr["RollNo"]),
                        Image = Convert.IsDBNull(dr["Photo"]) ? string.Empty : Convert.ToString(dr["Photo"]),
                        MarkSheetImage = Convert.IsDBNull(dr["Photo"]) ? string.Empty : Convert.ToString(dr["MarkSheetImage"]),
                        DateEntered = Convert.IsDBNull(dr["DateEntered"]) ? DateTime.MinValue : Convert.ToDateTime(dr["DateEntered"])
                    });
                }
            }
            return lst;
        }

    }
}