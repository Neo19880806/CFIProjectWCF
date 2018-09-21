using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFIWCFServiceLiabrary.Model
{
    public class DBHelper
    {
        //private static String connectionString = "database=work;Password=123456;User ID=root;server=127.0.0.1";
        private static String connectionString = "database=sql12257866;Password=LuRRmndhC2;User ID=sql12257866;server=sql12.freemysqlhosting.net;old guids=true;SslMode=None";


        public static DBHelper DefaultInstance = new DBHelper();
        
        public DBHelper()
        {

        }

        public List<Subject> GetValidSubject()
        {
            var subjectList = new List<Subject>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            { 
                string sqlValidSubject = "select DISTINCT `Course Title` from tblSISCRNs_SR004_2018_S2";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlValidSubject, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject subject = new Subject();
                    subject.Name = reader.GetString("Course Title");
                    subjectList.Add(subject);
                }
            }
            return subjectList;
        }

        public List<SubjectDetail> GetSubjectDetails(Subject subject)
        {
            var detailsList = new List<SubjectDetail>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string TB_SR2018 = "tblSISCRNs_SR004_2018_S2";
                string TB_CP = "tblSubjectCompetencies";
                string TB_CS = "tblCRNSessions";
                string TB_SD = "tblStaffDetails";
                //Basic Query
                String BQuery = String.Format("SELECT {0}.CRN,{1}.ITSubject as ITSubject,{2}.Time as Time,{2}.`Day_of_Week` as Day_Of_Week," +
                "{3}.`unique_name` as Lecturer,`Course Title`,`Meeting Start Date`," +
                "`Meeting Finish Date`, Room,`Lecturer ID`, Campus from {0}", TB_SR2018, TB_CP, TB_CS, TB_SD);
                //Left join Compentency
                String LJCP = String.Format("left join {1} on {0}.`Course Code`= {1}.CourseNumber", TB_SR2018, TB_CP);
                //Left join CRNSession
                String LJCS = String.Format("left join {1} on {1}.CRN = {0}.CRN", TB_SR2018, TB_CS);
                //Left join StaffDetails
                String LJSD = String.Format("left join {1} on {1}.`InstructorID` = {0}.`Lecturer ID`", TB_SR2018, TB_SD);
                //Where
                String WHERE = String.Format("where `Course Title` = \"{0}\" and Day_Of_Week!=\"\" and Room!=\"\"", subject.Name);
                //Final QueryString
                String sqlQueryString = String.Format("{0} {1} {2} {3} {4}", BQuery, LJCP, LJCS, LJSD, WHERE);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQueryString, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubjectDetail detail = new SubjectDetail();
                    detail.CRN = reader.GetString("CRN");
                    detail.SubjectCode = reader.GetString("ITSubject");
                    detail.CompetencyName = reader.GetString("Course Title");
                    detail.StartDate = reader.GetString("Meeting Start Date");
                    detail.EndDate = reader.GetString("Meeting Finish Date");
                    detail.DayOfWeek = reader.GetString("Day_Of_Week");
                    detail.Time = reader.GetString("Time");
                    detail.Room = reader.GetString("Room");
                    detail.Lecturer = reader.GetString("Lecturer");
                    detail.Campus = reader.GetString("Campus");
                    detailsList.Add(detail);
                }
            }
            return detailsList;
        }
    }
}
