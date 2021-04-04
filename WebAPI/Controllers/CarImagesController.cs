using Business.Abstract;
using DataAccess.Abstract;
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
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImageService;

        public CarImagesController(ICarImagesService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getbycarimages")]
        public IActionResult GetByCarImages(int imagesId)
        {
            var result = _carImageService.GetAll(c=>c.Id==imagesId);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result.Message);
            

        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile fromFile, [FromForm] CarImages carImages)
        {
            var result = _carImageService.Add(fromFile, carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CarImages carImages)
        {
            var result = _carImageService.Delete(carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile formFile, [FromForm] CarImages carImages)
        {
            var result = _carImageService.Update(formFile, carImages);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetCarById(int id)
        {
            var result = _carImageService.GetAll(c=>c.CarId==id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
