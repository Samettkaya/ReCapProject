using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindexScoresController : ControllerBase
    {
        IFindexScoreService _findexScoreService;

        public FindexScoresController(IFindexScoreService findexScoreService)
        {
            _findexScoreService = findexScoreService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findexScoreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int findeksScoreId)
        {
            var result = _findexScoreService.GetById(findeksScoreId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerıd")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _findexScoreService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FindexScore findeksScore)
        {
            var result = _findexScoreService.Add(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FindexScore findeksScore)
        {
            var result = _findexScoreService.Delete(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FindexScore findeksScore)
        {
            var result = _findexScoreService.Update(findeksScore);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
