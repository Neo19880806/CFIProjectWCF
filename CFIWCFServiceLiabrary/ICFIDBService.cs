using CFIWCFServiceLiabrary.Model;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace CFIWCFServiceLiabrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDBService" in both code and config file together.
    [ServiceContract]
    public interface ICFIDBService
    {
        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetSubject")]
        List<Subject> GetValidSubject();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/GetASubject")]
        Subject GetASubject();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Details?SubjectName={subjectJson}")]
        List<SubjectDetail> GetSubjectDetails(string subjectJson);
    }
}
