using api.Dtos.Stock;
using api.Models;
using Newtonsoft.Json;

public class IncomeStatementService
{
    private readonly IIncomeStatementRepository _repository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    public IncomeStatementService(IIncomeStatementRepository repository, IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _repository = repository;
        _httpClientFactory = httpClientFactory;
        _config = config;
    }

    public async Task<IEnumerable<IncomeStatementDto>> FetchAndStoreFromFmpAsync(string symbol)
    {
        var apiKey = _config["FMPKey"];
        var url = $"https://financialmodelingprep.com/api/v3/income-statement/{symbol}?period=annual&apikey={apiKey}";
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetStringAsync(url);

        var dtos = JsonConvert.DeserializeObject<List<IncomeStatementDto>>(response);
        Console.WriteLine($"[DEBUG] Deserialized {dtos.Count} income statements for {symbol}");
        foreach (var dto in dtos)
        {
            Console.WriteLine($"[DEBUG] {symbol} dto.calendarYear: {dto.calendarYear} (type: {dto.calendarYear.GetType()})");
            var entity = new IncomeStatement
            {
                Symbol = dto.Symbol,
                ReportedCurrency = dto.ReportedCurrency,
                Cik = dto.Cik,
                Date = dto.Date,
                FillingDate = dto.FillingDate,
                AcceptedDate = dto.AcceptedDate,
                calendarYear = dto.calendarYear,
                Period = dto.Period,
                Revenue = dto.Revenue,
                CostOfRevenue = dto.CostOfRevenue,
                GrossProfit = dto.GrossProfit,
                GrossProfitRatio = dto.GrossProfitRatio,
                ResearchAndDevelopmentExpenses = dto.ResearchAndDevelopmentExpenses,
                GeneralAndAdministrativeExpenses = dto.GeneralAndAdministrativeExpenses,
                SellingAndMarketingExpenses = dto.SellingAndMarketingExpenses,
                SellingGeneralAndAdministrativeExpenses = dto.SellingGeneralAndAdministrativeExpenses,
                OtherExpenses = dto.OtherExpenses,
                OperatingExpenses = dto.OperatingExpenses,
                CostAndExpenses = dto.CostAndExpenses,
                InterestIncome = dto.InterestIncome,
                InterestExpense = dto.InterestExpense,
                DepreciationAndAmortization = dto.DepreciationAndAmortization,
                Ebitda = dto.Ebitda,
                EbitdaRatio = dto.EbitdaRatio,
                OperatingIncome = dto.OperatingIncome,
                OperatingIncomeRatio = dto.OperatingIncomeRatio,
                TotalOtherIncomeExpensesNet = dto.TotalOtherIncomeExpensesNet,
                IncomeBeforeTax = dto.IncomeBeforeTax,
                IncomeBeforeTaxRatio = dto.IncomeBeforeTaxRatio,
                IncomeTaxExpense = dto.IncomeTaxExpense,
                NetIncome = dto.NetIncome,
                NetIncomeRatio = dto.NetIncomeRatio,
                Eps = dto.Eps,
                Epsdiluted = dto.Epsdiluted,
                WeightedAverageShsOut = dto.WeightedAverageShsOut,
                WeightedAverageShsOutDil = dto.WeightedAverageShsOutDil,
                Link = dto.Link,
                FinalLink = dto.FinalLink
            };
            Console.WriteLine($"[DEBUG] {symbol} entity.calendarYear: {entity.calendarYear} (type: {entity.calendarYear.GetType()})");
            await _repository.AddAsync(entity);
        }
        await _repository.SaveChangesAsync();
        return dtos;
    }

    public async Task<IncomeStatementDto> StoreAsync(IncomeStatementDto dto)
    {
        var entity = new IncomeStatement
        {
            Symbol = dto.Symbol,
            ReportedCurrency = dto.ReportedCurrency,
            Cik = dto.Cik,
            Date = dto.Date,
            FillingDate = dto.FillingDate,
            AcceptedDate = dto.AcceptedDate,
            calendarYear = dto.calendarYear,
            Period = dto.Period,
            Revenue = dto.Revenue,
            CostOfRevenue = dto.CostOfRevenue,
            GrossProfit = dto.GrossProfit,
            GrossProfitRatio = dto.GrossProfitRatio,
            ResearchAndDevelopmentExpenses = dto.ResearchAndDevelopmentExpenses,
            GeneralAndAdministrativeExpenses = dto.GeneralAndAdministrativeExpenses,
            SellingAndMarketingExpenses = dto.SellingAndMarketingExpenses,
            SellingGeneralAndAdministrativeExpenses = dto.SellingGeneralAndAdministrativeExpenses,
            OtherExpenses = dto.OtherExpenses,
            OperatingExpenses = dto.OperatingExpenses,
            CostAndExpenses = dto.CostAndExpenses,
            InterestIncome = dto.InterestIncome,
            InterestExpense = dto.InterestExpense,
            DepreciationAndAmortization = dto.DepreciationAndAmortization,
            Ebitda = dto.Ebitda,
            EbitdaRatio = dto.EbitdaRatio,
            OperatingIncome = dto.OperatingIncome,
            OperatingIncomeRatio = dto.OperatingIncomeRatio,
            TotalOtherIncomeExpensesNet = dto.TotalOtherIncomeExpensesNet,
            IncomeBeforeTax = dto.IncomeBeforeTax,
            IncomeBeforeTaxRatio = dto.IncomeBeforeTaxRatio,
            IncomeTaxExpense = dto.IncomeTaxExpense,
            NetIncome = dto.NetIncome,
            NetIncomeRatio = dto.NetIncomeRatio,
            Eps = dto.Eps,
            Epsdiluted = dto.Epsdiluted,
            WeightedAverageShsOut = dto.WeightedAverageShsOut,
            WeightedAverageShsOutDil = dto.WeightedAverageShsOutDil,
            Link = dto.Link,
            FinalLink = dto.FinalLink
        };
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return dto;
    }

    public async Task<IEnumerable<IncomeStatementDto>> GetFromDbAsync(string symbol)
    {
        var entities = await _repository.GetBySymbolAsync(symbol);
        return entities.Select(e => new IncomeStatementDto
        {
            Symbol = e.Symbol,
            ReportedCurrency = e.ReportedCurrency,
            Cik = e.Cik,
            Date = e.Date,
            FillingDate = e.FillingDate,
            AcceptedDate = e.AcceptedDate,
            calendarYear = e.calendarYear,
            Period = e.Period,
            Revenue = e.Revenue,
            CostOfRevenue = e.CostOfRevenue,
            GrossProfit = e.GrossProfit,
            GrossProfitRatio = e.GrossProfitRatio,
            ResearchAndDevelopmentExpenses = e.ResearchAndDevelopmentExpenses,
            GeneralAndAdministrativeExpenses = e.GeneralAndAdministrativeExpenses,
            SellingAndMarketingExpenses = e.SellingAndMarketingExpenses,
            SellingGeneralAndAdministrativeExpenses = e.SellingGeneralAndAdministrativeExpenses,
            OtherExpenses = e.OtherExpenses,
            OperatingExpenses = e.OperatingExpenses,
            CostAndExpenses = e.CostAndExpenses,
            InterestIncome = e.InterestIncome,
            InterestExpense = e.InterestExpense,
            DepreciationAndAmortization = e.DepreciationAndAmortization,
            Ebitda = e.Ebitda,
            EbitdaRatio = e.EbitdaRatio,
            OperatingIncome = e.OperatingIncome,
            OperatingIncomeRatio = e.OperatingIncomeRatio,
            TotalOtherIncomeExpensesNet = e.TotalOtherIncomeExpensesNet,
            IncomeBeforeTax = e.IncomeBeforeTax,
            IncomeBeforeTaxRatio = e.IncomeBeforeTaxRatio,
            IncomeTaxExpense = e.IncomeTaxExpense,
            NetIncome = e.NetIncome,
            NetIncomeRatio = e.NetIncomeRatio,
            Eps = e.Eps,
            Epsdiluted = e.Epsdiluted,
            WeightedAverageShsOut = e.WeightedAverageShsOut,
            WeightedAverageShsOutDil = e.WeightedAverageShsOutDil,
            Link = e.Link,
            FinalLink = e.FinalLink
        });
    }
}