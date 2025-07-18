using System;
using System.Windows;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    /// <summary>
    /// Interaction logic for BookingHistoryWindow.xaml
    /// </summary>
    public partial class BookingHistoryWindow : Window
    {
        private BookingHistoryViewModel _viewModel;

        public BookingHistoryWindow(int customerID)
        {
            InitializeComponent();
            _viewModel = new BookingHistoryViewModel(customerID);
            DataContext = _viewModel;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
