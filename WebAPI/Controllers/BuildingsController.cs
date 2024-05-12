using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet("getBuildingList")]
        [Authorize]
        public IActionResult GetList()
        {
            var result = _buildingService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getByBuildingId")]
        public IActionResult GetById(int buildingId)
        {
            var result = _buildingService.GetById(buildingId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("addBuilding")]
		[Authorize]
		public IActionResult Add(Building building)
        {
            var result = _buildingService.Add(building);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateBuilding")]
        public IActionResult Update(Building building)
        {
            var result = _buildingService.Update(building);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("deleteBuilding")]
        public IActionResult Delete(Building building)
        {
            var result = _buildingService.Delete(building);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
