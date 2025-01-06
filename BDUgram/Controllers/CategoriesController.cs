using BDugram.Core.Entities;
using BDugram.Core.Repositories;
using BDUgram.BL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BDUgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryRepository _repo) : ControllerBase
    {
        [HttpGet("hash")]
        public async Task<IActionResult> Hash(string s)
        {
            return Ok(HashHelper.HashPassword(s));
        }[HttpGet("HashIsTrue")]
        public async Task<IActionResult> HashIsTrue(string s , string password)
        {
            return Ok(HashHelper.VerifyHashedPassword(s ,password));
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _repo.GetAll().ToListAsync());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await _repo.AddAsync(category);
            await _repo.SaveAsync();
            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
