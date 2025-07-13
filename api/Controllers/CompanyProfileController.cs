using api.Dtos.Stock;
using api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/company-profile")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileService _service;

        public CompanyProfileController(CompanyProfileService service)
        {
            _service = service;
        }

        // Fetch from FMP and store in DB
        [HttpGet("{symbol}/fetch")]
        public async Task<ActionResult<CompanyProfileDto>> FetchAndStore(string symbol)
        {
            var result = await _service.FetchAndStoreFromFmpAsync(symbol);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Get from DB only
        [HttpGet("{symbol}")]
        public async Task<ActionResult<CompanyProfileDto>> GetProfile(string symbol)
        {
            var result = await _service.GetProfileAsync(symbol);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyProfileDto>> Create([FromBody] CompanyProfileDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _service.StoreProfileAsync(dto);
            if (result == null) return BadRequest();
            return CreatedAtAction(nameof(GetProfile), new { symbol = result.Symbol }, result);
        }
    }
}