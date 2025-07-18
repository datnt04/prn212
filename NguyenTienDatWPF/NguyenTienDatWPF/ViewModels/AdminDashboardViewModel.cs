using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NguyenTienDatWPF.ViewModels
{
    public class AdminDashboardViewModel : INotifyPropertyChanged
    {
        private string _adminName;
        
        public AdminDashboardViewModel()
        {
            AdminName = "Administrator";
        }
        
        public string AdminName
        {
            get => _adminName;
            set
            {
                _adminName = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    // Add the class that's being referenced in XAML
    public class AdminDashboardViewViewModel : AdminDashboardViewModel
    {
        // This inherits all functionality from AdminDashboardViewModel
    }
}
