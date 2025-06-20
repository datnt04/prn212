using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Repositories;
using NguyenTienDatWPF.ViewModels;

namespace NguyenTienDatWPF
{
    public partial class BookingDialog : Window
    {
        public Booking Booking { get; private set; }
        public ObservableCollection<Room> Rooms { get; }

        public BookingDialog(Customer customer)
        {
            InitializeComponent();
            Booking = new Booking { CustomerID = customer.CustomerID };
            Rooms = new ObservableCollection<Room>(new RoomRepository().GetAllRooms());
            DataContext = new BookingDialogViewModel(this);
        }
    }

    public class BookingDialogViewModel : ViewModelBase
    {
        private readonly BookingDialog _dialog;
        private readonly IRoomRepository _roomRepository;
        private Booking _booking;

        public Booking Booking
        {
            get => _booking;
            set => SetProperty(ref _booking, value);
        }

        public ObservableCollection<Room> Rooms => _dialog.Rooms;

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }

        public BookingDialogViewModel(BookingDialog dialog)
        {
            _dialog = dialog;
            _booking = _dialog.Booking;
            _roomRepository = new RoomRepository();
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            if (Booking.Room == null || Booking.StartDate == default || Booking.EndDate == default || Booking.EndDate < Booking.StartDate)
            {
                MessageBox.Show("Vui lòng điền đầy đủ và đúng các trường.", "Lỗi Kiểm Tra");
                return;
            }
            Booking.RoomID = Booking.Room.RoomID;
            Booking.TotalPrice = (decimal)(Booking.EndDate - Booking.StartDate).TotalDays * Booking.Room.RoomPricePerDate;
            _dialog.DialogResult = true;
            _dialog.Close();
        }

        private void OnCancel()
        {
            _dialog.DialogResult = false;
            _dialog.Close();
        }
    }
}