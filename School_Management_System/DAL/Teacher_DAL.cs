using School_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace School_Management_System.DAL
{
    public class Teacher_DAL
    {
        string str = "Data Source=DESKTOP-I0QCKM4\\SQLEXPRESS;Initial Catalog=New_SMS;Integrated Security=True;";

        public List<TeacherDetails> ListOfTeachersData()
        {
            try
            {
                List<TeacherDetails> list = new List<TeacherDetails>();
                using (SqlConnection con = new SqlConnection(str))
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    string q = "Select * from TeacherDetails";
                    SqlCommand cmd = new SqlCommand(q, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new TeacherDetails
                        {
                            TeacherID = Convert.ToInt32(dr["TeacherID"]),
                            TeacherName = dr["TeacherName"].ToString(),
                            TeacherAge = Convert.ToInt32(dr["TeacherAge"]),
                            TeacherGender = dr["TeacherGender"].ToString(),
                            TeacherAddress = dr["TeacherAddress"].ToString(),
                            TeacherContactNo = dr["TeacherContactNo"].ToString(),
                            Password = dr["Password"].ToString(),
                            TeacherEmail = dr["TeacherEmail"].ToString(),
                            State = dr["State"].ToString(),
                            Country = dr["Country"].ToString(),
                            Pin = dr["Pin"].ToString(),
                            TeacherQualification = dr["TeacherQualification"].ToString(),
                            EnteredDate = (DateTime)dr["EnteredDate"],
                            UpdatedDate = dr["UpdatedDate"].ToString(),
                            JoiningDate = DBNull.Value.Equals(dr["JoiningDate"]) ? null : (DateTime?)(Convert.ToDateTime(dr["JoiningDate"])),
                            LeavingDate = DBNull.Value.Equals(dr["LeavingDate"]) ? null : (DateTime?)(Convert.ToDateTime(dr["LeavingDate"])),
                            IsActive = !DBNull.Value.Equals(dr["IsActive"]) && Convert.ToBoolean(dr["IsActive"]),
                            TeacherImage = dr["TeacherImage"].ToString(),
                            ImagePriview = dr["TeacherImage"].ToString()
                        });
                    }
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public void AddEditTeacherDetails(TeacherDetails obj)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("[AddEditTeacherDetails]", connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TeacherName", obj.TeacherName);
                    command.Parameters.AddWithValue("@TeacherAge", obj.TeacherAge);
                    command.Parameters.AddWithValue("@TeacherGender", obj.TeacherGender);
                    command.Parameters.AddWithValue("@TeacherAddress", obj.TeacherAddress);

                    command.Parameters.AddWithValue("@TeacherContactNo", obj.TeacherContactNo);
                    command.Parameters.AddWithValue("@Password", obj.Password);
                    command.Parameters.AddWithValue("@TeacherEmail", obj.TeacherEmail);
                    command.Parameters.AddWithValue("@State", obj.State);
                    command.Parameters.AddWithValue("@Country", obj.Country);
                    command.Parameters.AddWithValue("@Pin", obj.Pin);
                    command.Parameters.AddWithValue("@TeacherQualification", obj.TeacherQualification);
                    command.Parameters.AddWithValue("@JoiningDate", obj.JoiningDate);

                    if (obj.TeacherID != 0)
                    {
                        command.Parameters.AddWithValue("@TeacherID", obj.TeacherID);
                        command.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@LeavingDate", obj.LeavingDate);
                        command.Parameters.AddWithValue("@IsActive", obj.IsActive);

                        if (obj.TeacherImage != null)
                        {
                            command.Parameters.AddWithValue("@TeacherImage", obj.TeacherImage);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TeacherImage", obj.ImagePriview);
                        }

                    }
                    else
                    {
                        command.Parameters.AddWithValue("@EnteredDate", DateTime.Now);
                        if (obj.TeacherImage != null)
                        {
                            command.Parameters.AddWithValue("@TeacherImage", obj.TeacherImage);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TeacherImage", "");
                        }
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteTeacherDetails(int id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("DeleteTeacherDetails", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TeacherID", id);
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
}