using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace CFIProjectUWP.Model
{
    class DAOHelper
    {
        public static async Task<string> GetValidSubject()
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(
            HttpMethod.Get, new Uri("http://www.mygithub.top/phpadmin/test/test_pdo.php"));

            //HttpRequestMessage httpRequest = new HttpRequestMessage(
            //HttpMethod.Get, new Uri("http://www.mygithub.top/web/CFIWebEJBService-war/ValidSubject"));

            string jsonString =  await  HttpConnectionHelper.GetString(httpRequest);
            return jsonString;
        }

        public static async Task<string> GetSubjectDetails(Subject subject)
        {
            JObject requestJsonObject = JObject.FromObject(subject);
            string url = "http://www.mygithub.top/web/CFIWebEJBService-war/SubjectDetails?SubjectName=";
            string jsonSubject = requestJsonObject.ToString();
            String uriString = String.Format("{0}{1}", url, jsonSubject);
            Uri uri = new Uri(uriString);
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            string jsonString = await HttpConnectionHelper.GetString(httpRequest);
            return jsonString;
        }
    }
}
