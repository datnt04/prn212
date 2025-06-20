using BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class DataContext
    {
        private static DataContext instance;
        private static readonly object lockObject = new object();

        public List<Room> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Booking> Bookings { get; set; }

        private DataContext()
        {
            Rooms = new List<Room>();
            RoomTypes = new List<RoomType>();
            Customers = new List<Customer>();
            Bookings = new List<Booking>();
            InitializeData();
        }

        public static DataContext Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new DataContext();
                    }
                    return instance;
                }
            }
        }

        private void InitializeData()
        {
            // Dữ liệu mẫu cho RoomType
            RoomTypes.Add(new RoomType { RoomTypeID = 1, RoomTypeName = "Phòng Tiêu Chuẩn", TypeDescription = "Phòng cơ bản", TypeNote = "Không có tiện ích bổ sung" });
            RoomTypes.Add(new RoomType { RoomTypeID = 2, RoomTypeName = "Phòng Cao Cấp", TypeDescription = "Phòng sang trọng", TypeNote = "Có ban công" });

            // Dữ liệu mẫu cho Room
            Rooms.Add(new Room { RoomID = 1, RoomNumber = "101", RoomDescription = "Phòng tiêu chuẩn", RoomMaxCapacity = 2, RoomStatus = 1, RoomPricePerDate = 500000m, RoomTypeID = 1 });
            Rooms.Add(new Room { RoomID = 2, RoomNumber = "201", RoomDescription = "Phòng cao cấp", RoomMaxCapacity = 4, RoomStatus = 1, RoomPricePerDate = 1000000m, RoomTypeID = 2 });

            // Dữ liệu mẫu cho Customer (Admin và khách hàng thường)
            Customers.Add(new Customer { CustomerID = 1, CustomerFullName = "Quản Trị Viên", Telephone = "0123456789", EmailAddress = "admin@FUMiniHotelSystem.com", CustomerBirthday = DateTime.Now.AddYears(-30), CustomerStatus = 1, Password = "@@abc123@@" });
            Customers.Add(new Customer { CustomerID = 2, CustomerFullName = "Nguyễn Văn A", Telephone = "0987654321", EmailAddress = "nguyen.van.a@example.com", CustomerBirthday = DateTime.Now.AddYears(-25), CustomerStatus = 1, Password = "password123" });
        }
    }
}