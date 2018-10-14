using System.Collections.Generic;
using CFIWCFServiceLiabrary.Model;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace CFIWCFServiceLiabrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBService" in both code and config file together.

    public class CFIDBService : ICFIDBService
    {
        public List<SubjectDetail> GetSubjectDetails(string subjectJson)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Subject subject = jsSerializer.Deserialize<Subject>(subjectJson);
            return DBHelper.DefaultInstance.GetSubjectDetails(subject);
        }

        public List<Subject> GetValidSubject()
        {
            return DBHelper.DefaultInstance.GetValidSubject();
        }
    }
}
