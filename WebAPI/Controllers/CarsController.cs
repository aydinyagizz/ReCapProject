using Business.Abstrack;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
    [ApiController] //attribute
    //attribute; bir class ile ilgili bilgi verme, onu imzalama yöntemidir.
    public class CarsController : ControllerBase
    {
        //IoC Container -- Inversion of Control (Değişimin kontrolü)


        //Loosely coupled - Geçşek bağlılık
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")] // ("getall"); isim vermek demek. aynı isimde birden çok fonksiyon olursa karışmasını önlüyoruz.
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")] // ("getbyid"); isim vermek demek. aynı isimde birden çok fonksiyon olursa karışmasını önlüyoruz.
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")] // ("add"); isim vermek demek. aynı isimde birden çok fonksiyon olursa karışmasını önlüyoruz.
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
