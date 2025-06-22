using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public List<Room> GetAllRooms() => _context.Rooms.Where(r => r.RoomStatus == 1).ToList();

        public Room GetRoomById(int roomId) => _context.Rooms.FirstOrDefault(r => r.RoomID == roomId);

        public void AddRoom(Room room)
        {
            room.RoomID = _context.Rooms.Any() ? _context.Rooms.Max(r => r.RoomID) + 1 : 1;
            _context.Rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            var existing = GetRoomById(room.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.RoomDescription = room.RoomDescription;
                existing.RoomMaxCapacity = room.RoomMaxCapacity;
                existing.RoomStatus = room.RoomStatus;
                existing.RoomPricePerDate = room.RoomPricePerDate;
                existing.RoomTypeID = room.RoomTypeID;
            }
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomID == roomId);
            if (room != null)
            {
                room.RoomStatus = 2; // Xóa mềm
            }
        }

        public List<Room> SearchRooms(string keyword) =>
            _context.Rooms.Where(r => r.RoomStatus == 1 &&
                (r.RoomNumber.Contains(keyword) || r.RoomDescription.Contains(keyword))).ToList();

        public List<Room> GetRoomsByKeyword(string keyword) =>
            _context.Rooms.Where(r => r.RoomStatus == 1 &&
                (r.RoomNumber.Contains(keyword) || r.RoomDescription.Contains(keyword))).ToList();
    }
}
