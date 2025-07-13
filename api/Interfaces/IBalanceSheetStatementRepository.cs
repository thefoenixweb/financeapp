using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBalanceSheetStatementRepository
{
    Task<IEnumerable<BalanceSheetStatement>> GetBySymbolAsync(string symbol);
    Task AddAsync(BalanceSheetStatement statement);
    Task SaveChangesAsync();
}