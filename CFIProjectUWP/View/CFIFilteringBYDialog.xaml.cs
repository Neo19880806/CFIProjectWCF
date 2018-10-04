using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CFIProjectUWP.View
{
    public sealed partial class CFIFilteringBYDialog : ContentDialog
    {
        public string FilterBYResult;
        public string FilterBYValue;
        public CFIFilteringBYDialog()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            richEBValue.Document.GetText(TextGetOptions.None,out FilterBYValue);
            FilterBYValue = FilterBYValue.Trim();
            if (string.IsNullOrEmpty(FilterBYValue))
            {
                FilterBYResult = "";
            }
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            FilterBYResult = "";
            this.Hide();
        }

        private void radio_CheckedChanged(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            FilterBYResult = radioButton.IsChecked.Value ? radioButton.Content.ToString().Trim() : FilterBYResult;
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            FilterBYResult = rbLecturer.Content.ToString().Trim();
        }
    }
}
