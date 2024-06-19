using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    public class student
    {
       public int S_ID { get; set; }
      
        public long Phone { get; set; }
        public string Password { get; set; }

        public string Full_Name { get; set; }

        public string Father_Name { get; set; }

        public string Mother_Name { get; set; }

       public string Guardian_Name { get; set; }

        public string RealationWithGuardian { get; set; }

        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string Adrress{ get; set; }

        public string PS { get; set; }

        public string PO { get; set; }

        public string Pin { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Aadhar_NO { get; set; }

        public string Email { get; set; }

        public string Class { get; set; }

        public string Section { get; set; }

        public int RollNo { get; set; }

        public string Image { get; set; }

        public string MarkSheetImage { get; set; }

        public long GurdianPhoneNo { get; set; }
        public DateTime? DateEntered { get; set; }
    }

    public class TeacherDetails
    {

        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int TeacherAge { get; set; }

        public string TeacherGender { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherContactNo { get; set; }
        public string Password { get; set; }
        public string TeacherEmail { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pin { get; set; }
        public string TeacherQualification { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }

        public DateTime EnteredDate { get; set; }
        public string UpdatedDate { get; set; }
        public Boolean IsActive { get; set; }
        public string TeacherImage { get; set; }
        public string ImagePriview { get; set; }

    }
}