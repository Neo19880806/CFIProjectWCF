using CFIProjectUWP.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CFIProjectUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CFIValidSubjectPage : Page
    {
        public CFIValidSubjectPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(
    HttpMethod.Get, new Uri("http://localhost:1988/MywebHttpBinding/"));

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = await httpClient.SendRequestAsync(httpRequest);

                if (httpResponse.StatusCode == HttpStatusCode.Ok)
                {
                    IHttpContent httpContent = httpResponse.Content;
                    IInputStream stream = await httpContent.ReadAsInputStreamAsync();
                    StreamReader reader = new StreamReader(stream.AsStreamForRead(), Encoding.UTF8);
                    string subjectJson = reader.ReadToEnd();

                    List<Subject> list = new List<Subject>();
                    JArray jArray = JArray.Parse(subjectJson);
                    foreach (JObject obj in jArray)
                    {
                        Subject subject = new Subject { Name = obj["Name"].ToString() };
                        list.Add(subject);
                    }

                    list.ForEach(s => cmbValidSubject.Items.Add(s.Name));
                    if (cmbValidSubject.Items.Count > 0)
                    {
                        cmbValidSubject.SelectedIndex = 0;
                    }
                }
                else
                {
                    await new MessageDialog("HttpResponse Error:" + httpResponse.StatusCode).ShowAsync();
                }
            }catch(Exception ex)
            {
                await new MessageDialog("" + ex.ToString()).ShowAsync();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cmbValidSubject.SelectedIndex == -1) { return; }
            this.Frame.Navigate(typeof(CFIMainPage),cmbValidSubject.SelectedValue.ToString());
        }
    }
}
