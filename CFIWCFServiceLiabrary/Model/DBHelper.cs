﻿using MySql.Data.MySqlClient;
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
        private static String connectionString = "database = tafebuddy; Password=lgj123456;User ID = cfiproject; server=www.db4free.net;old guids = true";


        public static DBHelper DefaultInstance = new DBHelper();
        
        public DBHelper()
        {

        }

        public List<Subject> GetValidSubject()
        {
            var subjectList = new List<Subject>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            { 
                string sqlValidSubject = "select DISTINCT `Course Title` from tblSISCRNs_SR004_2016_S2 where Day_Of_Week!='0'";
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
                String sqlQueryString = String.Format("select CRN,tblSubjectCompetencies.ITSubject,`Course Title`,`Meeting Start Date`," +
                "`Meeting Finish Date`,Day_Of_Week,Time,Room,Lecturer,Campus from tblSISCRNs_SR004_2016_S2 " +
                "left join tblSubjectCompetencies on tblSISCRNs_SR004_2016_S2.`Course Code`=tblSubjectCompetencies.CourseNumber " +
                "where `Course Title` = \"{0}\" and Day_Of_Week!='0'",
                subject.Name);
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
