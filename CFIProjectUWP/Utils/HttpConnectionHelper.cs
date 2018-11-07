using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace CFIProjectUWP.Model
{
    class HttpConnectionHelper
    {
        public static async Task<string> GetString(HttpRequestMessage httpRequest)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.SendRequestAsync(httpRequest);

                if (httpResponse.StatusCode == HttpStatusCode.Ok)
                {
                    IHttpContent httpContent = httpResponse.Content;
                    IInputStream stream = await httpContent.ReadAsInputStreamAsync();
                    StreamReader reader = new StreamReader(stream.AsStreamForRead(), Encoding.UTF8);
                    string subjectJson = reader.ReadToEnd();
                    return subjectJson;
                }
                else
                {
                    throw new Exception("HttpResponse Error:" + httpResponse.StatusCode);
                }
            }
            catch(Exception)
            {
                throw new Exception("Connect to http server failed");
            }
        }
    }
}
