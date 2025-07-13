using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BalanceSheetStatementRepository : IBalanceSheetStatementRepository
{
    private readonly ApplicationDBContext _context;
    public BalanceSheetStatementRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BalanceSheetStatement>> GetBySymbolAsync(string symbol)
    {
        return await _context.BalanceSheetStatements
            .Where(c => c.Symbol == symbol)
            .ToListAsync();
    }

    public async Task AddAsync(BalanceSheetStatement statement)
    {
        await _context.BalanceSheetStatements.AddAsync(statement);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}