using RoomFinder.Model.Model;
using RoomFinder.Model.Model.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomFinder.Core.Services.IServices
{
    public interface IStudyRoomBookingService
    {
        StudyRoomBookingResult BookStudyRoom(StudyRoomBooking request);
        IEnumerable<StudyRoomBooking> GetAllBooking();
    }
}
