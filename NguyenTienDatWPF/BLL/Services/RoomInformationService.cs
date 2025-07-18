using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogicLayer.Services
{
    public class RoomInformationService
    {
        private readonly IRepository<RoomInformation> _repo = RepositoryManager.Instance.RoomInformationRepository;

        public IEnumerable<RoomInformation> GetAllRooms() => _repo.GetAll();
        
        public RoomInformation GetRoomById(int id) => _repo.GetById(id);
        
        public IEnumerable<RoomInformation> GetRoomsByType(int roomTypeId) => 
            _repo.Search(r => r.RoomTypeID == roomTypeId);
            
        public IEnumerable<RoomInformation> GetAvailableRooms() => 
            _repo.Search(r => r.RoomStatus == 1);
            
        public void AddRoom(RoomInformation room)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(room.RoomNumber)) 
                throw new Exception("Số phòng không được để trống");
                
            if (room.RoomTypeID <= 0) 
                throw new Exception("Loại phòng không hợp lệ");
                
            if (room.RoomPricePerDay <= 0) 
                throw new Exception("Giá phòng phải lớn hơn 0");
                
            _repo.Add(room);
        }
        
        public void UpdateRoom(RoomInformation room)
        {
            // Validate tương tự Add
            if (string.IsNullOrWhiteSpace(room.RoomNumber)) 
                throw new Exception("Số phòng không được để trống");
                
            if (room.RoomTypeID <= 0) 
                throw new Exception("Loại phòng không hợp lệ");
                
            if (room.RoomPricePerDay <= 0) 
                throw new Exception("Giá phòng phải lớn hơn 0");
                
            _repo.Update(room);
        }
        
        public void DeleteRoom(int id)
        {
            var room = GetRoomById(id);
            if (room != null) _repo.Delete(room);
        }
        
        public IEnumerable<RoomInformation> SearchRooms(string searchTerm) => 
            _repo.Search(r => r.RoomNumber.Contains(searchTerm) || 
                             r.RoomDetailDescription.Contains(searchTerm));
    }
}
