using System.Windows;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF.Views
{
    public partial class BookingManagementWindow : Window
    {
        private BookingManagementViewModel _viewModel;
        
        public BookingManagementWindow()
        {
            InitializeComponent();
            _viewModel = new BookingManagementViewModel();
            DataContext = _viewModel;
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}