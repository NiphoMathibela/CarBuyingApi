﻿using CarBuyingApi.Services;
using Microsoft.AspNetCore.Mvc;
using CarBuyingApi.Models;

namespace CarBuyingApi.Controllers
{

    [Route("user/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;

        public UserController(UserService userService) => _userService = userService;

        //Getting user route
        [HttpGet]
        public async Task<List<User>> Get() =>
        await _userService.GetAsync();


        [HttpGet("{email}")]
        [Microsoft.AspNetCore.Cors.EnableCors("CarPolicy")]
        public async Task<ActionResult<User>> Get(string email)
        {
            var user = await _userService.GetAsync(email);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPost]
        [Microsoft.AspNetCore.Cors.EnableCors("CarPolicy")]
        public async Task<IActionResult> Post(User newUser)
        {
            await _userService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            await _userService.UpdateAsync(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = _userService.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.RemoveAsync(id);

            return NoContent();
        }

    }
}
