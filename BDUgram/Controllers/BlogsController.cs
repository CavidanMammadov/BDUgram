using AutoMapper;
using BDUgram.BL.DTOs.CategoryDTOs;
using BDUgram.BL.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDUgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogsController(IBlogService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
