using CFIProjectUWP.Model;
using CFIProjectUWP.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CFIProjectUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CFIMainPage : Page
    {
        private List<SubjectDetail> mResultList = new List<SubjectDetail>();
        private ObservableCollection<SubjectDetail> mQueryList = new ObservableCollection<SubjectDetail>();
        public CFIMainPage()
        {
            this.InitializeComponent();
        }

        private void controlsButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                String selectedSubject = e.Parameter.ToString();
                Subject subject = new Subject { Name = selectedSubject };
                string subjectJson = await DAOHelper.GetSubjectDetails(subject);

                mResultList.Clear();
                JArray jArray = JArray.Parse(subjectJson);
                foreach (JObject obj in jArray)
                {
                    SubjectDetail details = new SubjectDetail();
                    details.CRN = obj["CRN"].ToString();
                    details.SubjectCode = obj["SubjectCode"].ToString();
                    details.CompetencyName = obj["CompetencyName"].ToString();
                    DateTime StartDate = DateTime.Parse(obj["StartDate"].ToString());
                    details.StartDate = String.Format("{0:MM/dd/yyyy}",StartDate);
                    DateTime EndDate = DateTime.Parse(obj["EndDate"].ToString());
                    details.EndDate = String.Format("{0:MM/dd/yyyy}", EndDate);
                    details.DayOfWeek = obj["DayOfWeek"].ToString();
                    details.Time = obj["Time"].ToString();
                    details.Room = obj["Room"].ToString();
                    details.Lecturer = obj["Lecturer"].ToString();
                    details.Campus = obj["Campus"].ToString();
                    mResultList.Add(details);
                }

                if (mResultList.Count > 0)
                {
                    btnFiltering.IsEnabled = true;
                    btnSorting.IsEnabled = true;
                }
                else
                {
                    btnFiltering.IsEnabled = false;
                    btnSorting.IsEnabled = false;
                }
                RefreshListView(mResultList);
            }
            catch(Exception ex)
            {
                await new MessageDialog(ex.ToString()).ShowAsync();
            }
        }

        private async void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var detailDialog = new CFIDetailDialog(myListView.SelectedItem);
            await detailDialog.ShowAsync();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (mResultList.Count <= 0) return;
            RefreshListView(mResultList);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CFIValidSubjectPage));
        }

        private async void btnSorting_Click(object sender, RoutedEventArgs e)
        {
            if (mResultList.Count <= 0) return;
            CFISortingBYDialog dialog = new CFISortingBYDialog();
            var result = await dialog.ShowAsync();

            List<SubjectDetail> list = null;
            switch(dialog.SortBYResult)
            {
                case "Campus":
                    list = mQueryList.OrderBy(x => x.Campus).ToList();
                    break;
                case "Lecturer":
                    list = mQueryList.OrderBy(x => x.Lecturer).ToList();
                    break;
                case "Room":
                    list = mQueryList.OrderBy(x => x.Room).ToList();
                    break;
            default:
                break;
            }

            if (list!=null) { RefreshListView(list); };
        }

        private async void btnFiltering_Click(object sender, RoutedEventArgs e)
        {
            if (mResultList.Count <= 0) return;
            CFIFilteringBYDialog dialog = new CFIFilteringBYDialog();
            var result = await dialog.ShowAsync();

            List<SubjectDetail> list = null;
            switch (dialog.FilterBYResult)
            {
                case "Campus":
                    list = mQueryList.Where(x=>x.Campus.Contains(dialog.FilterBYValue)).ToList();
                    break;
                case "Lecturer":
                    list = mQueryList.Where(x=>x.Lecturer.Contains(dialog.FilterBYValue)).ToList();
                    break;
                default:
                    break;
            }

            if (list != null) { RefreshListView(list); };
        }

        private void RefreshListView(List<SubjectDetail> list)
        {
            mQueryList.Clear();
            list.ForEach(p => mQueryList.Add(p));
        }
    }
}
