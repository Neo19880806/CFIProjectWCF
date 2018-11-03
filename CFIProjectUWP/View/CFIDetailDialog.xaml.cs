using CFIProjectUWP.Model;
using System;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Contacts;
using Windows.Graphics.Printing;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CFIProjectUWP
{
    public sealed partial class CFIDetailDialog : ContentDialog
    {
        public CFIDetailDialog()
        {
            this.InitializeComponent();
        }

        private SubjectDetail detail;
        public CFIDetailDialog(object selectedItem)
        {
            this.InitializeComponent();
            detail = selectedItem as SubjectDetail;
            binding(richEBCRN, detail.CRN);
            binding(richEBSubjectCode, detail.SubjectCode);
            binding(richEBCompetencyName, detail.CompetencyName);
            binding(richEBStartDate, detail.StartDate);
            binding(richEBEndDate, detail.EndDate);
            binding(richEBDayOfWeek, detail.DayOfWeek);
            binding(richEBTime, detail.Time);
            binding(richEBRoom, detail.Room);
            binding(richEBLecturer, detail.Lecturer);
            binding(richEBCampus, detail.Campus);
        }

        private void binding(RichEditBox richbox,String content)
        {
            richbox.Document.SetText(TextSetOptions.None, content);
            richbox.IsReadOnly = true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private async void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            string emailto = "";
            richEBEmail.Document.GetText(TextGetOptions.None, out emailto);
            string email = emailto.Trim();
            if (String.IsNullOrEmpty(email))
            {
                await new MessageDialog("Please input email to address").ShowAsync();
            }
            else
            {
                //We need modify this regular expression.
                string pattern = ".+@.+\\.[a-z]+";
                bool isMatch = Regex.IsMatch(email, pattern);
                if(isMatch)
                {
                    Contact contact = new Contact()
                    {
                        Emails =
                        {
                            new ContactEmail()
                            {
                                Address = emailto
                            }
                        }
                    };
                    await EmailHelper.ComposeEmail(contact, "Subject Details", detail.Prepare2Email());
                }
                else
                {
                    await new MessageDialog("Please input valid email!").ShowAsync();
                }
            }
        }

        private async void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            if (PrintManager.IsSupported())
            {
                try
                {
                    //Set printPage,How to deal with failedResut and Show print UI
                    PrinterHelper.DefaultInstance.PrintPage = this;
                    await PrintManager.ShowPrintUIAsync();
                }
                catch
                {
                    // Printing cannot proceed at this time
                    showDialog("Printing error", "\nSorry,printing can't proceed at this time.", "OK");
                }
            }
            else
            {
                showDialog("Printing not supported","\nSorry,printing is not supported on this device","OK");
            }
        }

        private async void showDialog(string title, string content, string btnText)
        {
            // Printing is not supported on this device
            ContentDialog noPrintingDialog = new ContentDialog()
            {
                Title = title,
                Content = content,
                PrimaryButtonText = btnText
            };
            await noPrintingDialog.ShowAsync();
        }
    }
}
