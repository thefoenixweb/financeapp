using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IncomeStatementRepository : IIncomeStatementRepository
{
    private readonly ApplicationDBContext _context;
    public IncomeStatementRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IncomeStatement>> GetBySymbolAsync(string symbol)
    {
        return await _context.IncomeStatements
            .Where(c => c.Symbol == symbol)
            .ToListAsync();
    }

    public async Task AddAsync(IncomeStatement statement)
    {
        await _context.IncomeStatements.AddAsync(statement);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}