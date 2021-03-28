using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            Thread.Sleep(millisecondsTimeout: 5000);
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int carId)
        {
            Thread.Sleep(millisecondsTimeout: 1000);
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


   

     

        [HttpGet("getallprice")]

        public IActionResult GetByDailyPrice(decimal min, decimal max)
        {
            var result = _carService.GetByDailyPrice(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallyear")]

        public IActionResult GetByModelYear(string year)
        {
            var result = _carService.GetByModelYear(year);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("getbyselected")]
        public IActionResult GetCarsBySelect(int brandId, int colorId)
        {
            var result = _carService.GetCarsBySelect(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            Thread.Sleep(1000);
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallcardetail")]
        public IActionResult GetAllCarDetail()
        {
            Thread.Sleep(1000);
            var result = _carService.GetAllCarDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int carId)
        {
            Thread.Sleep(1000);
            var result = _carService.GetCarDetail(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        //[HttpGet("getcarsdetails")]
        //public IActionResult GetCarsDetails([FromQuery] FilterDto filterDto)
        //{
        //    var result = _carService.GetCarsDetails(filterDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}







    }
}
