using api.Dtos.Stock;
using api.Models;
using Newtonsoft.Json;

public class BalanceSheetStatementService
{
    private readonly IBalanceSheetStatementRepository _repository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    public BalanceSheetStatementService(IBalanceSheetStatementRepository repository, IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _repository = repository;
        _httpClientFactory = httpClientFactory;
        _config = config;
    }

    public async Task<IEnumerable<BalanceSheetStatementDto>> FetchAndStoreFromFmpAsync(string symbol)
    {
        var apiKey = _config["FMPKey"];
        var url = $"https://financialmodelingprep.com/api/v3/balance-sheet-statement/{symbol}?period=annual&apikey={apiKey}";
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync(url);

        var dtos = JsonConvert.DeserializeObject<List<BalanceSheetStatementDto>>(response);

        foreach (var dto in dtos)
        {
            var entity = new BalanceSheetStatement
            {
                Symbol = dto.Symbol,
                ReportedCurrency = dto.ReportedCurrency,
                Cik = dto.Cik,
                Date = dto.Date,
                FillingDate = dto.FillingDate,
                AcceptedDate = dto.AcceptedDate,
                calendarYear = dto.calendarYear,
                Period = dto.Period,
                CashAndCashEquivalents = dto.CashAndCashEquivalents,
                ShortTermInvestments = dto.ShortTermInvestments,
                CashAndShortTermInvestments = dto.CashAndShortTermInvestments,
                NetReceivables = dto.NetReceivables,
                Inventory = dto.Inventory,
                OtherCurrentAssets = dto.OtherCurrentAssets,
                TotalCurrentAssets = dto.TotalCurrentAssets,
                PropertyPlantEquipmentNet = dto.PropertyPlantEquipmentNet,
                Goodwill = dto.Goodwill,
                IntangibleAssets = dto.IntangibleAssets,
                GoodwillAndIntangibleAssets = dto.GoodwillAndIntangibleAssets,
                LongTermInvestments = dto.LongTermInvestments,
                TaxAssets = dto.TaxAssets,
                OtherNonCurrentAssets = dto.OtherNonCurrentAssets,
                TotalNonCurrentAssets = dto.TotalNonCurrentAssets,
                OtherAssets = dto.OtherAssets,
                TotalAssets = dto.TotalAssets,
                AccountPayables = dto.AccountPayables,
                ShortTermDebt = dto.ShortTermDebt,
                TaxPayables = dto.TaxPayables,
                DeferredRevenue = dto.DeferredRevenue,
                OtherCurrentLiabilities = dto.OtherCurrentLiabilities,
                TotalCurrentLiabilities = dto.TotalCurrentLiabilities,
                LongTermDebt = dto.LongTermDebt,
                DeferredRevenueNonCurrent = dto.DeferredRevenueNonCurrent,
                DeferredTaxLiabilitiesNonCurrent = dto.DeferredTaxLiabilitiesNonCurrent,
                OtherNonCurrentLiabilities = dto.OtherNonCurrentLiabilities,
                TotalNonCurrentLiabilities = dto.TotalNonCurrentLiabilities,
                OtherLiabilities = dto.OtherLiabilities,
                CapitalLeaseObligations = dto.CapitalLeaseObligations,
                TotalLiabilities = dto.TotalLiabilities,
                PreferredStock = dto.PreferredStock,
                CommonStock = dto.CommonStock,
                RetainedEarnings = dto.RetainedEarnings,
                AccumulatedOtherComprehensiveIncomeLoss = dto.AccumulatedOtherComprehensiveIncomeLoss,
                OthertotalStockholdersEquity = dto.OthertotalStockholdersEquity,
                TotalStockholdersEquity = dto.TotalStockholdersEquity,
                TotalEquity = dto.TotalEquity,
                TotalLiabilitiesAndStockholdersEquity = dto.TotalLiabilitiesAndStockholdersEquity,
                MinorityInterest = dto.MinorityInterest,
                TotalLiabilitiesAndTotalEquity = dto.TotalLiabilitiesAndTotalEquity,
                TotalInvestments = dto.TotalInvestments,
                TotalDebt = dto.TotalDebt,
                NetDebt = dto.NetDebt,
                Link = dto.Link,
                FinalLink = dto.FinalLink
            };
            await _repository.AddAsync(entity);
        }
        await _repository.SaveChangesAsync();
        return dtos;
    }

    public async Task<BalanceSheetStatementDto> StoreAsync(BalanceSheetStatementDto dto)
    {
        var entity = new BalanceSheetStatement
        {
            Symbol = dto.Symbol,
            ReportedCurrency = dto.ReportedCurrency,
            Cik = dto.Cik,
            Date = dto.Date,
            FillingDate = dto.FillingDate,
            AcceptedDate = dto.AcceptedDate,
            calendarYear = dto.calendarYear,
            Period = dto.Period,
            CashAndCashEquivalents = dto.CashAndCashEquivalents,
            ShortTermInvestments = dto.ShortTermInvestments,
            CashAndShortTermInvestments = dto.CashAndShortTermInvestments,
            NetReceivables = dto.NetReceivables,
            Inventory = dto.Inventory,
            OtherCurrentAssets = dto.OtherCurrentAssets,
            TotalCurrentAssets = dto.TotalCurrentAssets,
            PropertyPlantEquipmentNet = dto.PropertyPlantEquipmentNet,
            Goodwill = dto.Goodwill,
            IntangibleAssets = dto.IntangibleAssets,
            GoodwillAndIntangibleAssets = dto.GoodwillAndIntangibleAssets,
            LongTermInvestments = dto.LongTermInvestments,
            TaxAssets = dto.TaxAssets,
            OtherNonCurrentAssets = dto.OtherNonCurrentAssets,
            TotalNonCurrentAssets = dto.TotalNonCurrentAssets,
            OtherAssets = dto.OtherAssets,
            TotalAssets = dto.TotalAssets,
            AccountPayables = dto.AccountPayables,
            ShortTermDebt = dto.ShortTermDebt,
            TaxPayables = dto.TaxPayables,
            DeferredRevenue = dto.DeferredRevenue,
            OtherCurrentLiabilities = dto.OtherCurrentLiabilities,
            TotalCurrentLiabilities = dto.TotalCurrentLiabilities,
            LongTermDebt = dto.LongTermDebt,
            DeferredRevenueNonCurrent = dto.DeferredRevenueNonCurrent,
            DeferredTaxLiabilitiesNonCurrent = dto.DeferredTaxLiabilitiesNonCurrent,
            OtherNonCurrentLiabilities = dto.OtherNonCurrentLiabilities,
            TotalNonCurrentLiabilities = dto.TotalNonCurrentLiabilities,
            OtherLiabilities = dto.OtherLiabilities,
            CapitalLeaseObligations = dto.CapitalLeaseObligations,
            TotalLiabilities = dto.TotalLiabilities,
            PreferredStock = dto.PreferredStock,
            CommonStock = dto.CommonStock,
            RetainedEarnings = dto.RetainedEarnings,
            AccumulatedOtherComprehensiveIncomeLoss = dto.AccumulatedOtherComprehensiveIncomeLoss,
            OthertotalStockholdersEquity = dto.OthertotalStockholdersEquity,
            TotalStockholdersEquity = dto.TotalStockholdersEquity,
            TotalEquity = dto.TotalEquity,
            TotalLiabilitiesAndStockholdersEquity = dto.TotalLiabilitiesAndStockholdersEquity,
            MinorityInterest = dto.MinorityInterest,
            TotalLiabilitiesAndTotalEquity = dto.TotalLiabilitiesAndTotalEquity,
            TotalInvestments = dto.TotalInvestments,
            TotalDebt = dto.TotalDebt,
            NetDebt = dto.NetDebt,
            Link = dto.Link,
            FinalLink = dto.FinalLink
        };
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return dto;
    }

    public async Task<IEnumerable<BalanceSheetStatementDto>> GetFromDbAsync(string symbol)
    {
        var entities = await _repository.GetBySymbolAsync(symbol);
        return entities.Select(e => new BalanceSheetStatementDto
        {
            Symbol = e.Symbol,
            ReportedCurrency = e.ReportedCurrency,
            Cik = e.Cik,
            Date = e.Date,
            FillingDate = e.FillingDate,
            AcceptedDate = e.AcceptedDate,
            calendarYear = e.calendarYear,
            Period = e.Period,
            CashAndCashEquivalents = e.CashAndCashEquivalents,
            ShortTermInvestments = e.ShortTermInvestments,
            CashAndShortTermInvestments = e.CashAndShortTermInvestments,
            NetReceivables = e.NetReceivables,
            Inventory = e.Inventory,
            OtherCurrentAssets = e.OtherCurrentAssets,
            TotalCurrentAssets = e.TotalCurrentAssets,
            PropertyPlantEquipmentNet = e.PropertyPlantEquipmentNet,
            Goodwill = e.Goodwill,
            IntangibleAssets = e.IntangibleAssets,
            GoodwillAndIntangibleAssets = e.GoodwillAndIntangibleAssets,
            LongTermInvestments = e.LongTermInvestments,
            TaxAssets = e.TaxAssets,
            OtherNonCurrentAssets = e.OtherNonCurrentAssets,
            TotalNonCurrentAssets = e.TotalNonCurrentAssets,
            OtherAssets = e.OtherAssets,
            TotalAssets = e.TotalAssets,
            AccountPayables = e.AccountPayables,
            ShortTermDebt = e.ShortTermDebt,
            TaxPayables = e.TaxPayables,
            DeferredRevenue = e.DeferredRevenue,
            OtherCurrentLiabilities = e.OtherCurrentLiabilities,
            TotalCurrentLiabilities = e.TotalCurrentLiabilities,
            LongTermDebt = e.LongTermDebt,
            DeferredRevenueNonCurrent = e.DeferredRevenueNonCurrent,
            DeferredTaxLiabilitiesNonCurrent = e.DeferredTaxLiabilitiesNonCurrent,
            OtherNonCurrentLiabilities = e.OtherNonCurrentLiabilities,
            TotalNonCurrentLiabilities = e.TotalNonCurrentLiabilities,
            OtherLiabilities = e.OtherLiabilities,
            CapitalLeaseObligations = e.CapitalLeaseObligations,
            TotalLiabilities = e.TotalLiabilities,
            PreferredStock = e.PreferredStock,
            CommonStock = e.CommonStock,
            RetainedEarnings = e.RetainedEarnings,
            AccumulatedOtherComprehensiveIncomeLoss = e.AccumulatedOtherComprehensiveIncomeLoss,
            OthertotalStockholdersEquity = e.OthertotalStockholdersEquity,
            TotalStockholdersEquity = e.TotalStockholdersEquity,
            TotalEquity = e.TotalEquity,
            TotalLiabilitiesAndStockholdersEquity = e.TotalLiabilitiesAndStockholdersEquity,
            MinorityInterest = e.MinorityInterest,
            TotalLiabilitiesAndTotalEquity = e.TotalLiabilitiesAndTotalEquity,
            TotalInvestments = e.TotalInvestments,
            TotalDebt = e.TotalDebt,
            NetDebt = e.NetDebt,
            Link = e.Link,
            FinalLink = e.FinalLink
        });
    }
}