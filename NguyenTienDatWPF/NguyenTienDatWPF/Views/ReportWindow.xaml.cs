using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ReportViewModel _viewModel;

        public ReportWindow()
        {
            InitializeComponent();
            _viewModel = new ReportViewModel();
            DataContext = _viewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
