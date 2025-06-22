using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NguyenTienDatWPF.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        private bool _isAdmin;
        private bool _isCustomer;

        public bool IsAdmin
        {
            get => _isAdmin;
            set => SetProperty(ref _isAdmin, value);
        }

        public bool IsCustomer
        {
            get => _isCustomer;
            set => SetProperty(ref _isCustomer, value);
        }
    }
}
