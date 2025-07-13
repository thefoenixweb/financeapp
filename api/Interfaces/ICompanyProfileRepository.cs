using api.Models;
using System.Threading.Tasks;

public interface ICompanyProfileRepository
{
    Task<CompanyProfile> GetBySymbolAsync(string symbol);
    Task AddOrUpdateAsync(CompanyProfile profile);
    Task SaveChangesAsync();
}