﻿using RoomFinder.Core.Services.IServices;
using RoomFinder.Model.Model.VM;
using RoomFinder.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomFinder.DataAccess.Repository.IRepository;

namespace RoomFinder.Core.Services
{
    public class StudyRoomBookingService : IStudyRoomBookingService
    {
        private readonly IStudyRoomBookingRepository _studyRoomBookingRepository;
        private readonly IStudyRoomRepository _studyRoomRepository;

        public StudyRoomBookingService(IStudyRoomBookingRepository studyRoomBookingRepository,
          IStudyRoomRepository studyRoomRepository)
        {
            _studyRoomRepository = studyRoomRepository;
            _studyRoomBookingRepository = studyRoomBookingRepository;
        }

        public StudyRoomBookingResult BookStudyRoom(StudyRoomBooking request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            StudyRoomBookingResult result = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };

            IEnumerable<int> bookedRooms = _studyRoomBookingRepository.GetAll(request.Date).Select(u => u.StudyRoomId);
            IEnumerable<StudyRoom> availableRooms = _studyRoomRepository.GetAll().Where(u => !bookedRooms.Contains(u.Id));
            if (availableRooms.Any())
            {
                StudyRoomBooking studyRoomBooking = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Date = request.Date
                };
                studyRoomBooking.StudyRoomId = availableRooms.FirstOrDefault().Id;
                _studyRoomBookingRepository.Book(studyRoomBooking);
                result.BookingId = studyRoomBooking.BookingId;
                result.Code = StudyRoomBookingCode.Success;
            }
            else
            {
                result.Code = StudyRoomBookingCode.NoRoomAvailable;
            }

            return result;
        }

        public IEnumerable<StudyRoomBooking> GetAllBooking()
        {
            return _studyRoomBookingRepository.GetAll(null);
        }


    }
}
