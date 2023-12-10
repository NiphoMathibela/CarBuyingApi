using CarBuyingApi.Services;
using CarBuyingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors;

namespace CarBuyingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;

        public CarsController(CarService carService) => _carService = carService;

        [HttpGet]
        public async Task<List<Car>> Get() => await _carService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Car>> Get(string id)
        {
            var car = await _carService.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        [Microsoft.AspNetCore.Cors.EnableCors("CarPolicy")]
        public async Task<IActionResult> Post(Car newCar)
        {
            await _carService.CreateAsync(newCar);

            return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Car updatedCar)
        {
            var car = await _carService.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            updatedCar.Id = car.Id;

            await _carService.UpdateAsync(id, updatedCar);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var car = _carService.GetAsync(id);

            if(car == null)
            {
                return NotFound();
            }

            await _carService.RemoveAsync(id);

            return NoContent();
        }
    }
}
