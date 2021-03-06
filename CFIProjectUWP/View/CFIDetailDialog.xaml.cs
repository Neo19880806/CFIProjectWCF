﻿using CFIProjectUWP.DBServiceRef;
using System;
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
    }
}
