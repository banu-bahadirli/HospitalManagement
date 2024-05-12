using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomsController : ControllerBase
	{

		private IRoomService _roomService;

		public RoomsController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		[HttpGet("getRoomList")]
		//[Authorize]
		public IActionResult GetList()
		{
			var result = _roomService.GetList();
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}


		[HttpGet("getByRoomId")]
		public IActionResult GetById(int roomId)
		{
			var result = _roomService.GetById(roomId);
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}

		[HttpPost("addRoom")]
		public IActionResult Add(Room room)
		{
			var result = _roomService.Add(room);
			if (result.Success)
			{
				return Ok(result.Message);
			}
			return BadRequest(result.Message);
		}

		[HttpPost("updateRoom")]
		public IActionResult Update(Room room)
		{
			var result = _roomService.Update(room);
			if (result.Success)
			{
				return Ok(result.Message);
			}
			return BadRequest(result.Message);
		}

        [HttpPost("deleteRoom")]
        public IActionResult Delete(Room room)
        {
            var result = _roomService.Delete(room);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
