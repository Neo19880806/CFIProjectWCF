using CFIProjectUWP.DBServiceRef;
using CFIProjectUWP.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
            String selectedSubject = e.Parameter.ToString();
            CFIDBServiceClient serivce = new CFIDBServiceClient(CFIDBServiceClient.EndpointConfiguration.MybasicHttpBinding);
            try
            {
                GetSubjectDetailsRequest request = new GetSubjectDetailsRequest();
                request.subject = new Subject { Name = selectedSubject };
                GetSubjectDetailsResponse response = await serivce.GetSubjectDetailsAsync(request);
                mResultList.Clear();
                mResultList = response.GetSubjectDetailsResult.ToList();
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
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
            }
            finally
            {


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
