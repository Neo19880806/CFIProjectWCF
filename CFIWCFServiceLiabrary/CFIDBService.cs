using System.Collections.Generic;
using CFIWCFServiceLiabrary.Model;
using System.Web.Script.Serialization;
using System.ServiceModel.Activation;
namespace CFIWCFServiceLiabrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBService" in both code and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CFIDBService : ICFIDBService
    {
        public List<SubjectDetail> GetSubjectDetails(string subjectJson)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            Subject subject = jsSerializer.Deserialize<Subject>(subjectJson);
            return DBHelper.DefaultInstance.GetSubjectDetails(subject);
        }

        public Subject GetASubject()
        {
            Subject subject = new Subject { Name = "Test" };
            return subject;
        }
        public List<Subject> GetValidSubject()
        {
            return DBHelper.DefaultInstance.GetValidSubject();
        }
    }
}
