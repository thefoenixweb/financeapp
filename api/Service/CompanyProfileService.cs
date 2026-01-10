using api.Dtos.Stock;
using api.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class CompanyProfileService
{
    private readonly ICompanyProfileRepository _repository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
    private readonly ILogger<CompanyProfileService> _logger;

    public CompanyProfileService(
        ICompanyProfileRepository repository,
        IHttpClientFactory httpClientFactory,
        IConfiguration config,
        ILogger<CompanyProfileService> logger)
    {
        _repository = repository;
        _httpClientFactory = httpClientFactory;
        _config = config;
        _logger = logger;
    }

    public async Task<CompanyProfileDto> FetchAndStoreFromFmpAsync(string symbol)
    {
        var apiKey = _config["FMPKey"];
        var url = $"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={apiKey}";
        var client = _httpClientFactory.CreateClient();

        string responseBody;
        try
        {
            var response = await client.GetAsync(url);
            responseBody = await response.Content.ReadAsStringAsync();

            // Log raw HTTP response for debugging (be mindful of sensitive data & size)
            _logger.LogInformation("FMP raw response for {Symbol} (status {StatusCode}): {Body}", symbol, (int)response.StatusCode, responseBody);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("FMP returned non-success status for {Symbol}: {StatusCode}", symbol, (int)response.StatusCode);
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HTTP request to FMP failed for {Symbol} (URL: {Url})", symbol, url);
            return null;
        }

        List<CompanyProfileDto> dtos;
        try
        {
            dtos = JsonConvert.DeserializeObject<List<CompanyProfileDto>>(responseBody);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to deserialize FMP response for {Symbol}. Raw response: {Body}", symbol, responseBody);
            return null;
        }

        var dto = dtos?.FirstOrDefault();
        if (dto == null)
        {
            _logger.LogWarning("FMP returned empty array for {Symbol}. Raw response: {Body}", symbol, responseBody);
            return null;
        }

        // Log DTO (serialized) at Debug level
        _logger.LogDebug("FMP DTO for {Symbol}: {Dto}", symbol, JsonConvert.SerializeObject(dto));

        var entity = new CompanyProfile
        {
              Symbol = dto.Symbol ?? string.Empty,
    Price = dto.Price,
    Beta = dto.Beta,
    VolAvg = dto.VolAvg,
    MktCap = dto.MktCap,
    LastDiv = dto.LastDiv,
    Range = dto.Range ?? string.Empty,
    Changes = dto.Changes,
    CompanyName = dto.CompanyName ?? string.Empty,
    Currency = dto.Currency ?? string.Empty,
    Cik = dto.Cik ?? string.Empty,
    Isin = dto.Isin ?? string.Empty,
    Cusip = dto.Cusip ?? string.Empty,
    Exchange = dto.Exchange ?? string.Empty,
    ExchangeShortName = dto.ExchangeShortName ?? string.Empty, // avoid NOT NULL
    Industry = dto.Industry ?? string.Empty,
    Website = dto.Website ?? string.Empty,
    Description = dto.Description ?? string.Empty,
    Ceo = dto.Ceo ?? string.Empty,
    Sector = dto.Sector ?? string.Empty,
    Country = dto.Country ?? string.Empty,
    FullTimeEmployees = dto.FullTimeEmployees ?? string.Empty,
    Phone = dto.Phone ?? string.Empty,
    Address = dto.Address ?? string.Empty, // avoid NOT NULL
    City = dto.City ?? string.Empty,
    State = dto.State ?? string.Empty,
    Zip = dto.Zip ?? string.Empty,
    DcfDiff = dto.DcfDiff,
    Dcf = dto.Dcf,
    Image = dto.Image ?? string.Empty,
    IpoDate = dto.IpoDate,
    DefaultImage = dto.DefaultImage,
    IsEtf = dto.IsEtf,
    IsActivelyTrading = dto.IsActivelyTrading,
    IsAdr = dto.IsAdr,
    IsFund = dto.IsFund
        };

        // Log mapped entity at Debug level
        _logger.LogDebug("Mapped CompanyProfile entity for {Symbol}: {Entity}", symbol, JsonConvert.SerializeObject(entity));

        try
        {
            await _repository.AddOrUpdateAsync(entity);
            await _repository.SaveChangesAsync();
            _logger.LogInformation("Saved CompanyProfile for {Symbol} to database", symbol);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving CompanyProfile for {Symbol}. Entity: {Entity}", symbol, JsonConvert.SerializeObject(entity));
            throw;
        }

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

        try
        {
            await _repository.AddOrUpdateAsync(entity);
            await _repository.SaveChangesAsync();
            _logger.LogInformation("Stored CompanyProfile for {Symbol} via StoreProfileAsync", dto.Symbol);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error storing CompanyProfile via StoreProfileAsync for {Symbol}. Entity: {Entity}", dto.Symbol, JsonConvert.SerializeObject(entity));
            throw;
        }

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