using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class RoomTypeService
    {
        private readonly IRepository<RoomType> _repo = RepositoryManager.Instance.RoomTypeRepository;

        public IEnumerable<RoomType> GetAllRoomTypes() => _repo.GetAll();
        
        public RoomType GetRoomTypeById(int id) => _repo.GetById(id);
        
        public void AddRoomType(RoomType roomType)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(roomType.RoomTypeName)) 
                throw new Exception("Tên loại phòng không được để trống");
                
            _repo.Add(roomType);
        }
        
        public void UpdateRoomType(RoomType roomType)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(roomType.RoomTypeName)) 
                throw new Exception("Tên loại phòng không được để trống");
                
            _repo.Update(roomType);
        }
        
        public void DeleteRoomType(int id)
        {
            var roomType = GetRoomTypeById(id);
            if (roomType != null) _repo.Delete(roomType);
        }
        
        public IEnumerable<RoomType> SearchRoomTypes(string searchTerm) => 
            _repo.Search(rt => rt.RoomTypeName.Contains(searchTerm) || 
                             rt.TypeDescription.Contains(searchTerm));
    }
}
