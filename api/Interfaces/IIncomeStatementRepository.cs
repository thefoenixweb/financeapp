using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IIncomeStatementRepository
{
    Task<IEnumerable<IncomeStatement>> GetBySymbolAsync(string symbol);
    Task AddAsync(IncomeStatement statement);
    Task SaveChangesAsync();
}