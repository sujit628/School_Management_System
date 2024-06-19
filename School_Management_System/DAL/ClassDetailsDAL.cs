using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace School_Management_System.DAL
{
    public class ClassDetailsDAL
    {
        string str = "Data Source=DESKTOP-I0QCKM4\\SQLEXPRESS;Initial Catalog=New_SMS;Integrated Security=True;";

        public bool UpdateData(ClassDetails ur)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                int i;
                SqlCommand cmd = new SqlCommand("UpdateClassDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ur.Id);
                cmd.Parameters.AddWithValue("@ClassName", ur.ClassName);
                cmd.Parameters.AddWithValue("@Sub1", ur.Sub1);
                cmd.Parameters.AddWithValue("@Sub2", ur.Sub2);
                cmd.Parameters.AddWithValue("@Sub3", ur.Sub3);
                cmd.Parameters.AddWithValue("@Sub4", ur.Sub4);
                cmd.Parameters.AddWithValue("@Sub5", ur.Sub5);
                cmd.Parameters.AddWithValue("@Sub6", ur.Sub6);
                cmd.Parameters.AddWithValue("@Sub7", ur.Sub7);
                cmd.Parameters.AddWithValue("@Sub8", ur.Sub8);
                cmd.Parameters.AddWithValue("@Sub9", ur.Sub9);
                cmd.Parameters.AddWithValue("@Sub10", ur.Sub10);
                cmd.Parameters.AddWithValue("@Sub11", ur.Sub11);
                cmd.Parameters.AddWithValue("@Sub12", ur.Sub12);
                cmd.Parameters.AddWithValue("@AdmissionFee", ur.AdmissionFee);
                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool Add(ClassDetails ur)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertClassDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClassName", ur.ClassName);
                    cmd.Parameters.AddWithValue("@Sub1", ur.Sub1);
                    cmd.Parameters.AddWithValue("@Sub2", ur.Sub2);
                    cmd.Parameters.AddWithValue("@Sub3", ur.Sub3);
                    cmd.Parameters.AddWithValue("@Sub4", ur.Sub4);
                    cmd.Parameters.AddWithValue("@Sub5", ur.Sub5);
                    cmd.Parameters.AddWithValue("@Sub6", ur.Sub6);
                    cmd.Parameters.AddWithValue("@Sub7", ur.Sub7);
                    cmd.Parameters.AddWithValue("@Sub8", ur.Sub8);
                    cmd.Parameters.AddWithValue("@Sub9", ur.Sub9);
                    cmd.Parameters.AddWithValue("@Sub10", ur.Sub10);
                    cmd.Parameters.AddWithValue("@Sub11", ur.Sub11);
                    cmd.Parameters.AddWithValue("@Sub12", ur.Sub12);
                    cmd.Parameters.AddWithValue("@AdmissionFee", ur.AdmissionFee);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }


        public List<ClassDetails> GetDataList()
        {
            List<ClassDetails> lst = new List<ClassDetails>();
            using (SqlConnection con = new SqlConnection(str))
            {
                string q = "Select * from ClassDetails";
                SqlCommand cmd = new SqlCommand(q, con);

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(new ClassDetails
                    {
                        Id = Convert.ToInt32(dr[0]),
                        ClassName = Convert.ToString(dr[1]),
                        Sub1 = Convert.ToString(dr[2]),
                        Sub2 = Convert.ToString(dr[3]),
                        Sub3 = Convert.ToString(dr[4]),
                        Sub4 = Convert.ToString(dr[5]),
                        Sub5 = Convert.ToString(dr[6]),
                        Sub6 = Convert.ToString(dr[7]),
                        Sub7 = Convert.ToString(dr[8]),
                        Sub8 = Convert.ToString(dr[9]),
                        Sub9 = Convert.ToString(dr[10]),
                        Sub10 = Convert.ToString(dr[11]),
                        Sub11 = Convert.ToString(dr[12]),
                        Sub12 = Convert.ToString(dr[13]),
                        AdmissionFee = Convert.ToDecimal(dr[14])
                    });
                }
            }
            return lst;
        }


        public void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                string q = "Delete from ClassDetails where Id =" + id;
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}