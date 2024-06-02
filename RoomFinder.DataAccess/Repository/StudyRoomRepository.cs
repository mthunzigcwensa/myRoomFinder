using RoomFinder.DataAccess.Repository.IRepository;
using RoomFinder.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomFinder.DataAccess.Repository
{
    public class StudyRoomRepository : IStudyRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public StudyRoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public IEnumerable<StudyRoom> GetAll()
        {
            return _db.StudyRooms.ToList();
        }


    }
}
