namespace DataAccessLayer
{
    public class RepositoryManager
    {
        private static RepositoryManager _instance;
        private static readonly object _lock = new object();
        private readonly HotelDbContext _context;

        private RepositoryManager()
        {
            _context = new HotelDbContext();
        }

        public static RepositoryManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new RepositoryManager();
                    return _instance;
                }
            }
        }

        public IRepository<Entities.Customer> CustomerRepository => new CustomerRepository(_context);
        public IRepository<Entities.RoomType> RoomTypeRepository => new RoomTypeRepository(_context);
        public IRepository<Entities.RoomInformation> RoomInformationRepository => new RoomInformationRepository(_context);
        public IRepository<Entities.BookingReservation> BookingReservationRepository => new BookingReservationRepository(_context);
        public IRepository<Entities.BookingDetail> BookingDetailRepository => new BookingDetailRepository(_context);
    }
}