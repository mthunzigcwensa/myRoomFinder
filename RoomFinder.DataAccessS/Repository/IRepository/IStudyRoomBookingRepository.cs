﻿using RoomFinder.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomFinder.DataAccess.Repository.IRepository
{
    public interface IStudyRoomBookingRepository
    {
        void Book(StudyRoomBooking booking);
        IEnumerable<StudyRoomBooking> GetAll(DateTime? dateTime);

    }
}
