using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CompanyProfileRepository : ICompanyProfileRepository
{
    private readonly ApplicationDBContext _context;
    public CompanyProfileRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<CompanyProfile> GetBySymbolAsync(string symbol)
    {
        return await _context.CompanyProfiles.FirstOrDefaultAsync(c => c.Symbol == symbol);
    }

    public async Task AddOrUpdateAsync(CompanyProfile profile)
    {
        var existing = await GetBySymbolAsync(profile.Symbol);
        if (existing == null)
        {
            // Clear the Id to ensure it's treated as a new entity
            profile.Id = 0;
            await _context.CompanyProfiles.AddAsync(profile);
        }
        else
        {
            // Remove the existing entity and add the new one to avoid key conflicts
            _context.CompanyProfiles.Remove(existing);
            await _context.SaveChangesAsync();
            
            // Clear the Id to ensure it's treated as a new entity
            profile.Id = 0;
            await _context.CompanyProfiles.AddAsync(profile);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}