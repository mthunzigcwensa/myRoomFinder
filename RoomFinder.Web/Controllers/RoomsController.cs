using Microsoft.AspNetCore.Mvc;
using RoomFinder.Core.Services.IServices;

namespace RoomFinder.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IStudyRoomService _studyRoomService;
        public RoomsController(IStudyRoomService studyRoomService)
        {
            _studyRoomService = studyRoomService;
        }
        public IActionResult Index()
        {
            return View(_studyRoomService.GetAll());
        }


    }
}
