using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFIProjectUWP.Model.API
{
    public class CFIApi : ICFIApi
    {
        public async Task<List<SubjectDetail>> getSubjectDetails(Subject subject)
        {
            string subjectJson = await DAOHelper.GetSubjectDetails(subject);
            List<SubjectDetail> list = new List<SubjectDetail>();
            JArray jArray = JArray.Parse(subjectJson);
            foreach (JObject obj in jArray)
            {
                SubjectDetail details = new SubjectDetail();
                details.CRN = obj["CRN"].ToString();
                details.SubjectCode = obj["SubjectCode"].ToString();
                details.CompetencyName = obj["CompetencyName"].ToString();
                DateTime StartDate = DateTime.Parse(obj["StartDate"].ToString());
                details.StartDate = String.Format("{0:MM/dd/yyyy}", StartDate);
                DateTime EndDate = DateTime.Parse(obj["EndDate"].ToString());
                details.EndDate = String.Format("{0:MM/dd/yyyy}", EndDate);
                details.DayOfWeek = obj["DayOfWeek"].ToString();
                details.Time = obj["Time"].ToString();
                details.Room = obj["Room"].ToString();
                details.Lecturer = obj["Lecturer"].ToString();
                details.Campus = obj["Campus"].ToString();
                list.Add(details);
            }
            return list;
        }

        public async Task<List<Subject>> getSubjects()
        {
            List<Subject> list = new List<Subject>();
            string subjectJson = await DAOHelper.GetValidSubject();
            JArray jArray = JArray.Parse(subjectJson);
            foreach (JObject obj in jArray)
            {
                Subject subject = new Subject { Name = obj["Name"].ToString() };
                list.Add(subject);
            }
            return list;
        }
    }
}
