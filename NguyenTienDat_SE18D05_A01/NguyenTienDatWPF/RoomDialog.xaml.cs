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
using NguyenTienDatWPF.ViewModels;
using DataAccess;

namespace NguyenTienDatWPF
{
    public partial class RoomDialog : Window
    {
        public Room Room { get; private set; }
        public ObservableCollection<RoomType> RoomTypes { get; }

        public RoomDialog(Room room = null)
        {
            InitializeComponent();
            Room = room != null ? new Room
            {
                RoomID = room.RoomID,
                RoomNumber = room.RoomNumber,
                RoomDescription = room.RoomDescription,
                RoomMaxCapacity = room.RoomMaxCapacity,
                RoomStatus = room.RoomStatus,
                RoomPricePerDate = room.RoomPricePerDate,
                RoomTypeID = room.RoomTypeID,
                RoomType = room.RoomType
            } : new Room { RoomStatus = 1 };
            RoomTypes = new ObservableCollection<RoomType>(DataAccess.DataContext.Instance.RoomTypes);
            DataContext = new RoomDialogViewModel(this);
        }
    }

    public class RoomDialogViewModel : ViewModelBase
    {
        private readonly RoomDialog _dialog;

        private Room _room;
        public Room Room
        {
            get => _room;
            set => SetProperty(ref _room, value);
        }

        public ObservableCollection<RoomType> RoomTypes => _dialog.RoomTypes;

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }

        public RoomDialogViewModel(RoomDialog dialog)
        {
            _dialog = dialog;
            _room = _dialog.Room;
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            // Debug để xem giá trị của các trường
            string debugInfo = $"RoomNumber: '{Room.RoomNumber}', Length: {Room.RoomNumber?.Length}\n" +
                               $"RoomDescription: '{Room.RoomDescription}', Length: {Room.RoomDescription?.Length}\n" +
                               $"RoomMaxCapacity: {Room.RoomMaxCapacity}\n" +
                               $"RoomPricePerDate: {Room.RoomPricePerDate}\n" +
                               $"RoomTypeID: {Room.RoomTypeID}";
            
            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(Room.RoomNumber) || Room.RoomNumber.Length > 50)
            {
                MessageBox.Show("Số phòng không được để trống và không quá 50 ký tự.", "Lỗi Kiểm Tra");
                return;
            }
            
            if (string.IsNullOrEmpty(Room.RoomDescription) || Room.RoomDescription.Length > 220)
            {
                MessageBox.Show("Mô tả phòng không được để trống và không quá 220 ký tự.", "Lỗi Kiểm Tra");
                return;
            }
            
            if (Room.RoomMaxCapacity <= 0)
            {
                MessageBox.Show("Sức chứa phải lớn hơn 0.", "Lỗi Kiểm Tra");
                return;
            }
            
            if (Room.RoomPricePerDate <= 0)
            {
                MessageBox.Show("Giá phòng phải lớn hơn 0.", "Lỗi Kiểm Tra");
                return;
            }
            
            // Kiểm tra và hiển thị thông báo cụ thể cho RoomTypeID
            if (Room.RoomTypeID <= 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng.", "Lỗi Kiểm Tra");
                return;
            }
            
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