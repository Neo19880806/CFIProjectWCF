using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFIProjectUWP.Model
{
    public class SubjectDetail
    {
        public String CRN { get; set; }
        public String SubjectCode { get; set; }
        public String CompetencyName { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String DayOfWeek { get; set; }
        public String Time { get; set; }
        public String Room { get; set; }
        public String Lecturer { get; set; }
        public String Campus { get; set; }

        public String Prepare2Email()
        {
            string content = String.Format("CRN\t\t\t:\t{0}\n SubjectCode\t\t:\t{1}\n" +
                "CompetencyName\t:\t{2}\nStartDate\t\t:\t{3}\nEndDate\t\t:\t{4}\nDayOfWeek\t\t:\t{5}" +
                "\nTime\t\t\t:\t{6}\nRoom\t\t\t:\t{7}\nLecturer\t\t:\t{8}\nCampus\t\t\t:\t{9}",CRN,SubjectCode,
                CompetencyName, StartDate,EndDate,DayOfWeek,Time,Room,Lecturer,Campus);
           return content;
        }
    }
}
