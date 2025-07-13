using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CashFlowStatementRepository
    {
        private readonly ApplicationDBContext _context;
        public CashFlowStatementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<CashFlowStatement>> GetByStockIdAsync(int stockId)
        {
            return await _context.CashFlowStatements.Where(c => c.StockId == stockId).ToListAsync();
        }

        public async Task AddAsync(CashFlowStatement statement)
        {
            await _context.CashFlowStatements.AddAsync(statement);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<CashFlowStatement> statements)
        {
            await _context.CashFlowStatements.AddRangeAsync(statements);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CashFlowStatement>> GetBySymbolAsync(string symbol)
        {
            return await _context.CashFlowStatements.Where(c => c.Symbol == symbol).ToListAsync();
        }
    }
}