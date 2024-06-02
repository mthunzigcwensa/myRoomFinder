using RoomFinder.Core.Services.IServices;
using RoomFinder.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomFinder.Core.Services
{
    public class StudyRoomService : IStudyRoomService
    {
        private readonly IStudyRoomRepository _studyRoomRepository;
        public StudyRoomService(IStudyRoomRepository studyRoomRepository)
        {
            _studyRoomRepository = studyRoomRepository;
        }


        public IEnumerable<StudyRoom> GetAll()
        {
            return _studyRoomRepository.GetAll();
        }


    }
}
