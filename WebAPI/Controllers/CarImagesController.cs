using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        //[HttpGet("getfilebyid")]
        //public IActionResult GetFileById(int id)
        //{
        //    var result = _carImageService.GetById(id);

        //    if (result.Success)
        //    {
        //        var b = System.IO.File.ReadAllBytes(result.Data.ImagePath);
        //        return File(b, "image/jpeg");
        //    }

        //    return BadRequest(result);
        //}

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesById(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            IResult result = _carImageService.Add(file, carImage);
            if (result.Success)
            {
                return Ok(result)
                    ;
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Boş resim gönderemezsin");
            }
            IResult result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}