using CFIProjectUWP.Model;
using CFIProjectUWP.Model.API;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CFIProjectUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CFIValidSubjectPage : Page
    {
        private List<Subject> myResultList = new List<Subject>();
        private ObservableCollection<Subject> validSubjectList = new ObservableCollection<Subject>();
        public CFIValidSubjectPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ICFIApi api = new CFIApi();
                myResultList = await api.getSubjects();
                myResultList.ForEach(c => validSubjectList.Add(c));

                myResultList.ForEach(s => cmbValidSubject.Items.Add(s.Name));
                myResultList.ForEach(s => listBox.Items.Add(s.Name));

                if (cmbValidSubject.Items.Count > 0)
                {
                    cmbValidSubject.SelectedIndex = 0;
                }
            }catch(Exception ex)
            {
                await new MessageDialog(ex.Message.ToString()).ShowAsync();
            }
        }

        private async void btnView_Click(object sender, RoutedEventArgs e)
        {
            string subject = txtValidSubject.Text.Trim();
            var list = validSubjectList.Where(x => x.Name.Equals(subject));
            if (list.Count() <= 0)
            {
                await new MessageDialog("Please input or select full name!").ShowAsync();
            }
            else
            {
                this.Frame.Navigate(typeof(CFIMainPage), subject);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex == -1) { return; }
            this.Frame.Navigate(typeof(CFIMainPage), txtValidSubject.ToString());
        }

        private void txtValidSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            listBox.Items.Clear();
            string filter = txtValidSubject.Text.Trim();
            //We need refine this method,because it is not efficient
            var list = validSubjectList.Where(x => x.Name.ToUpper().Contains(filter.ToUpper())).ToList();
            list.ForEach(s => listBox.Items.Add(s.Name));
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex!= -1){
                txtValidSubject.Text = listBox.SelectedValue.ToString();
            }
        }
    }
}
