using api.Dtos.Stock;
using api.Models;
using Newtonsoft.Json;

public class CompanyProfileService
{
    private readonly ICompanyProfileRepository _repository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    public CompanyProfileService(ICompanyProfileRepository repository, IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _repository = repository;
        _httpClientFactory = httpClientFactory;
        _config = config;
    }

    public async Task<CompanyProfileDto> FetchAndStoreFromFmpAsync(string symbol)
    {
        var apiKey = _config["FMPKey"];
        var url = $"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMPKey"]}";
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync(url);

        var dtos = JsonConvert.DeserializeObject<List<CompanyProfileDto>>(response);
        var dto = dtos?.FirstOrDefault();
        if (dto == null) return null;

        var entity = new CompanyProfile
        {
            Symbol = dto.Symbol,
            Price = dto.Price,
            Beta = dto.Beta,
            VolAvg = dto.VolAvg,
            MktCap = dto.MktCap,
            LastDiv = dto.LastDiv,
            Range = dto.Range,
            Changes = dto.Changes,
            CompanyName = dto.CompanyName,
            Currency = dto.Currency,
            Cik = dto.Cik,
            Isin = dto.Isin,
            Cusip = dto.Cusip,
            Exchange = dto.Exchange,
            ExchangeShortName = dto.ExchangeShortName,
            Industry = dto.Industry,
            Website = dto.Website,
            Description = dto.Description,
            Ceo = dto.Ceo,
            Sector = dto.Sector,
            Country = dto.Country,
            FullTimeEmployees = dto.FullTimeEmployees,
            Phone = dto.Phone,
            Address = dto.Address,
            City = dto.City,
            State = dto.State,
            Zip = dto.Zip,
            DcfDiff = dto.DcfDiff,
            Dcf = dto.Dcf,
            Image = dto.Image,
            IpoDate = dto.IpoDate,
            DefaultImage = dto.DefaultImage,
            IsEtf = dto.IsEtf,
            IsActivelyTrading = dto.IsActivelyTrading,
            IsAdr = dto.IsAdr,
            IsFund = dto.IsFund
        };

        await _repository.AddOrUpdateAsync(entity);
        await _repository.SaveChangesAsync();
        return dto;
    }

    public async Task<CompanyProfileDto> StoreProfileAsync(CompanyProfileDto dto)
    {
        var entity = new CompanyProfile
        {
            Symbol = dto.Symbol,
            Price = dto.Price,
            Beta = dto.Beta,
            VolAvg = dto.VolAvg,
            MktCap = dto.MktCap,
            LastDiv = dto.LastDiv,
            Range = dto.Range,
            Changes = dto.Changes,
            CompanyName = dto.CompanyName,
            Currency = dto.Currency,
            Cik = dto.Cik,
            Isin = dto.Isin,
            Cusip = dto.Cusip,
            Exchange = dto.Exchange,
            ExchangeShortName = dto.ExchangeShortName,
            Industry = dto.Industry,
            Website = dto.Website,
            Description = dto.Description,
            Ceo = dto.Ceo,
            Sector = dto.Sector,
            Country = dto.Country,
            FullTimeEmployees = dto.FullTimeEmployees,
            Phone = dto.Phone,
            Address = dto.Address,
            City = dto.City,
            State = dto.State,
            Zip = dto.Zip,
            DcfDiff = dto.DcfDiff,
            Dcf = dto.Dcf,
            Image = dto.Image,
            IpoDate = dto.IpoDate,
            DefaultImage = dto.DefaultImage,
            IsEtf = dto.IsEtf,
            IsActivelyTrading = dto.IsActivelyTrading,
            IsAdr = dto.IsAdr,
            IsFund = dto.IsFund
        };
        await _repository.AddOrUpdateAsync(entity);
        await _repository.SaveChangesAsync();
        return dto;
    }

    public async Task<CompanyProfileDto> GetProfileAsync(string symbol)
    {
        var entity = await _repository.GetBySymbolAsync(symbol);
        if (entity == null) return null;

        return new CompanyProfileDto
        {
            Symbol = entity.Symbol,
            Price = entity.Price,
            Beta = entity.Beta,
            VolAvg = entity.VolAvg,
            MktCap = entity.MktCap,
            LastDiv = entity.LastDiv,
            Range = entity.Range,
            Changes = entity.Changes,
            CompanyName = entity.CompanyName,
            Currency = entity.Currency,
            Cik = entity.Cik,
            Isin = entity.Isin,
            Cusip = entity.Cusip,
            Exchange = entity.Exchange,
            ExchangeShortName = entity.ExchangeShortName,
            Industry = entity.Industry,
            Website = entity.Website,
            Description = entity.Description,
            Ceo = entity.Ceo,
            Sector = entity.Sector,
            Country = entity.Country,
            FullTimeEmployees = entity.FullTimeEmployees,
            Phone = entity.Phone,
            Address = entity.Address,
            City = entity.City,
            State = entity.State,
            Zip = entity.Zip,
            DcfDiff = entity.DcfDiff,
            Dcf = entity.Dcf,
            Image = entity.Image,
            IpoDate = entity.IpoDate,
            DefaultImage = entity.DefaultImage,
            IsEtf = entity.IsEtf,
            IsActivelyTrading = entity.IsActivelyTrading,
            IsAdr = entity.IsAdr,
            IsFund = entity.IsFund
        };
    }
}