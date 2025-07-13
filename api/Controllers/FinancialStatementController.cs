using api.Dtos.Stock;
using api.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace api.Controllers
{
    [Route("api/financial-statement/fmp")]
    [ApiController]
    public class FinancialStatementController : ControllerBase
    {
        private readonly IncomeStatementService _incomeService;
        private readonly BalanceSheetStatementService _balanceService;
        private readonly CashFlowStatementService _cashFlowService;
        private readonly BalanceSheetStatementService _balanceSheetService;

        public FinancialStatementController(
            IncomeStatementService incomeService,
            BalanceSheetStatementService balanceService,
            CashFlowStatementService cashFlowService,
            BalanceSheetStatementService balanceSheetService)
        {
            _incomeService = incomeService;
            _balanceService = balanceService;
            _cashFlowService = cashFlowService;
            _balanceSheetService = balanceSheetService;
        }

        [HttpGet("income/{symbol}")]
        public async Task<ActionResult<IEnumerable<IncomeStatementDto>>> GetIncomeStatement(string symbol)
        {
            var result = await _incomeService.GetFromDbAsync(symbol);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpGet("balance/{symbol}")]
        public async Task<ActionResult<IEnumerable<BalanceSheetStatementDto>>> GetBalanceSheet(string symbol)
        {
            var result = await _balanceService.GetFromDbAsync(symbol);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpPost("income")]
        public async Task<IActionResult> CreateIncomeStatement([FromBody] api.Dtos.Account.SymbolRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Symbol))
                return BadRequest("Symbol is required.");

            var result = await _incomeService.FetchAndStoreFromFmpAsync(request.Symbol);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpPost("balance")]
        public async Task<IActionResult> CreateBalanceSheetStatement([FromBody] api.Dtos.Account.SymbolRequestDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Symbol))
                return BadRequest("Symbol is required.");

            var result = await _balanceSheetService.FetchAndStoreFromFmpAsync(request.Symbol);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result);
        }
    }
}