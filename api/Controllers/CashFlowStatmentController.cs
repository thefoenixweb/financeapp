using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/cashflow")]
    public class CashFlowStatementController : ControllerBase
    {
        private readonly CashFlowStatementService _service;

        public CashFlowStatementController(CashFlowStatementService service)
        {
            _service = service;
        }

        [HttpGet("{symbol}")]
        public async Task<ActionResult<List<CashFlowStatementDto>>> GetCashFlowStatements(string symbol)
        {
            var statements = await _service.GetFromDbAsync(symbol);
            if (statements == null || statements.Count == 0)
                return NotFound();
            return Ok(statements);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] api.Dtos.Account.SymbolRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Symbol))
                return BadRequest("Symbol is required.");
            var result = await _service.FetchAndStoreFromFmpAsync(request.Symbol);
            if (result == null || result.Count == 0) return NotFound();
            return Ok(result);
        }
    }
}