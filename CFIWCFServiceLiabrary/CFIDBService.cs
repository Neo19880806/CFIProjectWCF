using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CFIWCFServiceLiabrary.Model;

namespace CFIWCFServiceLiabrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DBService" in both code and config file together.
    public class CFIDBService : ICFIDBService
    {
        public List<SubjectDetail> GetSubjectDetails(Subject subject)
        {
            return DBHelper.DefaultInstance.GetSubjectDetails(subject);
        }

        public List<Subject> GetValidSubject()
        {
            return DBHelper.DefaultInstance.GetValidSubject();
        }
    }
}
