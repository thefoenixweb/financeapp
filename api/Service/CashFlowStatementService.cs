using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using api.Repository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;

namespace api.Service
{
    public class CashFlowStatementService
    {
        private readonly CashFlowStatementRepository _repository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public CashFlowStatementService(CashFlowStatementRepository repository, HttpClient httpClient, IConfiguration config)
        {
            _repository = repository;
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<CashFlowStatementDto>> FetchAndStoreFromFmpAsync(string symbol)
        {
            var url = $"https://financialmodelingprep.com/api/v3/cash-flow-statement/{symbol}?period=annual&apikey={_config["FMPKey"]}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var dtos = JsonConvert.DeserializeObject<List<CashFlowStatementDto>>(content);

            var entities = new List<CashFlowStatement>();
            foreach (var dto in dtos)
            {
                var entity = new CashFlowStatement
                {
                    Symbol = dto.Symbol,
                    ReportedCurrency = dto.ReportedCurrency,
                    Cik = dto.Cik,
                    Date = dto.Date,
                    FillingDate = dto.FillingDate,
                    AcceptedDate = dto.AcceptedDate,
                    calendarYear = dto.calendarYear,
                    Period = dto.Period,
                    NetIncome = dto.NetIncome,
                    DepreciationAndAmortization = dto.DepreciationAndAmortization,
                    DeferredIncomeTax = dto.DeferredIncomeTax,
                    StockBasedCompensation = dto.StockBasedCompensation,
                    ChangeInWorkingCapital = dto.ChangeInWorkingCapital,
                    AccountsReceivables = dto.AccountsReceivables,
                    Inventory = dto.Inventory,
                    AccountsPayables = dto.AccountsPayables,
                    OtherWorkingCapital = dto.OtherWorkingCapital,
                    OtherNonCashItems = dto.OtherNonCashItems,
                    NetCashProvidedByOperatingActivities = dto.NetCashProvidedByOperatingActivities,
                    InvestmentsInPropertyPlantAndEquipment = dto.InvestmentsInPropertyPlantAndEquipment,
                    AcquisitionsNet = dto.AcquisitionsNet,
                    PurchasesOfInvestments = dto.PurchasesOfInvestments,
                    SalesMaturitiesOfInvestments = dto.SalesMaturitiesOfInvestments,
                    OtherInvestingActivites = dto.OtherInvestingActivites,
                    NetCashUsedForInvestingActivites = dto.NetCashUsedForInvestingActivites,
                    DebtRepayment = dto.DebtRepayment,
                    CommonStockIssued = dto.CommonStockIssued,
                    CommonStockRepurchased = dto.CommonStockRepurchased,
                    DividendsPaid = dto.DividendsPaid,
                    OtherFinancingActivites = dto.OtherFinancingActivites,
                    NetCashUsedProvidedByFinancingActivities = dto.NetCashUsedProvidedByFinancingActivities,
                    EffectOfForexChangesOnCash = dto.EffectOfForexChangesOnCash,
                    NetChangeInCash = dto.NetChangeInCash,
                    CashAtEndOfPeriod = dto.CashAtEndOfPeriod,
                    CashAtBeginningOfPeriod = dto.CashAtBeginningOfPeriod,
                    OperatingCashFlow = dto.OperatingCashFlow,
                    CapitalExpenditure = dto.CapitalExpenditure,
                    FreeCashFlow = dto.FreeCashFlow,
                    Link = dto.Link,
                    FinalLink = dto.FinalLink
                };
                entities.Add(entity);
            }
            await _repository.AddRangeAsync(entities);
            return dtos;
        }

        public async Task<CashFlowStatementDto> StoreAsync(CashFlowStatementDto dto)
        {
            var entity = new CashFlowStatement
            {
                Symbol = dto.Symbol,
                ReportedCurrency = dto.ReportedCurrency,
                Cik = dto.Cik,
                Date = dto.Date,
                FillingDate = dto.FillingDate,
                AcceptedDate = dto.AcceptedDate,
                calendarYear = dto.calendarYear,
                Period = dto.Period,
                NetIncome = dto.NetIncome,
                DepreciationAndAmortization = dto.DepreciationAndAmortization,
                DeferredIncomeTax = dto.DeferredIncomeTax,
                StockBasedCompensation = dto.StockBasedCompensation,
                ChangeInWorkingCapital = dto.ChangeInWorkingCapital,
                AccountsReceivables = dto.AccountsReceivables,
                Inventory = dto.Inventory,
                AccountsPayables = dto.AccountsPayables,
                OtherWorkingCapital = dto.OtherWorkingCapital,
                OtherNonCashItems = dto.OtherNonCashItems,
                NetCashProvidedByOperatingActivities = dto.NetCashProvidedByOperatingActivities,
                InvestmentsInPropertyPlantAndEquipment = dto.InvestmentsInPropertyPlantAndEquipment,
                AcquisitionsNet = dto.AcquisitionsNet,
                PurchasesOfInvestments = dto.PurchasesOfInvestments,
                SalesMaturitiesOfInvestments = dto.SalesMaturitiesOfInvestments,
                OtherInvestingActivites = dto.OtherInvestingActivites,
                NetCashUsedForInvestingActivites = dto.NetCashUsedForInvestingActivites,
                DebtRepayment = dto.DebtRepayment,
                CommonStockIssued = dto.CommonStockIssued,
                CommonStockRepurchased = dto.CommonStockRepurchased,
                DividendsPaid = dto.DividendsPaid,
                OtherFinancingActivites = dto.OtherFinancingActivites,
                NetCashUsedProvidedByFinancingActivities = dto.NetCashUsedProvidedByFinancingActivities,
                EffectOfForexChangesOnCash = dto.EffectOfForexChangesOnCash,
                NetChangeInCash = dto.NetChangeInCash,
                CashAtEndOfPeriod = dto.CashAtEndOfPeriod,
                CashAtBeginningOfPeriod = dto.CashAtBeginningOfPeriod,
                OperatingCashFlow = dto.OperatingCashFlow,
                CapitalExpenditure = dto.CapitalExpenditure,
                FreeCashFlow = dto.FreeCashFlow,
                Link = dto.Link,
                FinalLink = dto.FinalLink
            };
            await _repository.AddAsync(entity);
            return dto;
        }

        public async Task<List<CashFlowStatementDto>> GetFromDbAsync(string symbol)
        {
            var entities = await _repository.GetBySymbolAsync(symbol);
            return entities.Select(e => new CashFlowStatementDto
            {
                Symbol = e.Symbol,
                ReportedCurrency = e.ReportedCurrency,
                Cik = e.Cik,
                Date = e.Date,
                FillingDate = e.FillingDate,
                AcceptedDate = e.AcceptedDate,
                calendarYear = e.calendarYear,
                Period = e.Period,
                NetIncome = e.NetIncome,
                DepreciationAndAmortization = e.DepreciationAndAmortization,
                DeferredIncomeTax = e.DeferredIncomeTax,
                StockBasedCompensation = e.StockBasedCompensation,
                ChangeInWorkingCapital = e.ChangeInWorkingCapital,
                AccountsReceivables = e.AccountsReceivables,
                Inventory = e.Inventory,
                AccountsPayables = e.AccountsPayables,
                OtherWorkingCapital = e.OtherWorkingCapital,
                OtherNonCashItems = e.OtherNonCashItems,
                NetCashProvidedByOperatingActivities = e.NetCashProvidedByOperatingActivities,
                InvestmentsInPropertyPlantAndEquipment = e.InvestmentsInPropertyPlantAndEquipment,
                AcquisitionsNet = e.AcquisitionsNet,
                PurchasesOfInvestments = e.PurchasesOfInvestments,
                SalesMaturitiesOfInvestments = e.SalesMaturitiesOfInvestments,
                OtherInvestingActivites = e.OtherInvestingActivites,
                NetCashUsedForInvestingActivites = e.NetCashUsedForInvestingActivites,
                DebtRepayment = e.DebtRepayment,
                CommonStockIssued = e.CommonStockIssued,
                CommonStockRepurchased = e.CommonStockRepurchased,
                DividendsPaid = e.DividendsPaid,
                OtherFinancingActivites = e.OtherFinancingActivites,
                NetCashUsedProvidedByFinancingActivities = e.NetCashUsedProvidedByFinancingActivities,
                EffectOfForexChangesOnCash = e.EffectOfForexChangesOnCash,
                NetChangeInCash = e.NetChangeInCash,
                CashAtEndOfPeriod = e.CashAtEndOfPeriod,
                CashAtBeginningOfPeriod = e.CashAtBeginningOfPeriod,
                OperatingCashFlow = e.OperatingCashFlow,
                CapitalExpenditure = e.CapitalExpenditure,
                FreeCashFlow = e.FreeCashFlow,
                Link = e.Link,
                FinalLink = e.FinalLink
            }).ToList();
        }
    }
}