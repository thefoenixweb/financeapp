using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class CashFlowStatementMapper
    {
        public static CashFlowStatementDto ToDto(this CashFlowStatement model)
        {
            return new CashFlowStatementDto
            {
                Date = model.Date,
                Symbol = model.Symbol,
                ReportedCurrency = model.ReportedCurrency,
                Cik = model.Cik,
                FillingDate = model.FillingDate,
                AcceptedDate = model.AcceptedDate,
                calendarYear = model.calendarYear,
                Period = model.Period,
                NetIncome = model.NetIncome,
                DepreciationAndAmortization = model.DepreciationAndAmortization,
                DeferredIncomeTax = model.DeferredIncomeTax,
                StockBasedCompensation = model.StockBasedCompensation,
                ChangeInWorkingCapital = model.ChangeInWorkingCapital,
                AccountsReceivables = model.AccountsReceivables,
                Inventory = model.Inventory,
                AccountsPayables = model.AccountsPayables,
                OtherWorkingCapital = model.OtherWorkingCapital,
                OtherNonCashItems = model.OtherNonCashItems,
                NetCashProvidedByOperatingActivities = model.NetCashProvidedByOperatingActivities,
                InvestmentsInPropertyPlantAndEquipment = model.InvestmentsInPropertyPlantAndEquipment,
                AcquisitionsNet = model.AcquisitionsNet,
                PurchasesOfInvestments = model.PurchasesOfInvestments,
                SalesMaturitiesOfInvestments = model.SalesMaturitiesOfInvestments,
                OtherInvestingActivites = model.OtherInvestingActivites,
                NetCashUsedForInvestingActivites = model.NetCashUsedForInvestingActivites,
                DebtRepayment = model.DebtRepayment,
                CommonStockIssued = model.CommonStockIssued,
                CommonStockRepurchased = model.CommonStockRepurchased,
                DividendsPaid = model.DividendsPaid,
                OtherFinancingActivites = model.OtherFinancingActivites,
                NetCashUsedProvidedByFinancingActivities = model.NetCashUsedProvidedByFinancingActivities,
                EffectOfForexChangesOnCash = model.EffectOfForexChangesOnCash,
                NetChangeInCash = model.NetChangeInCash,
                CashAtEndOfPeriod = model.CashAtEndOfPeriod,
                CashAtBeginningOfPeriod = model.CashAtBeginningOfPeriod,
                OperatingCashFlow = model.OperatingCashFlow,
                CapitalExpenditure = model.CapitalExpenditure,
                FreeCashFlow = model.FreeCashFlow,
                Link = model.Link,
                FinalLink = model.FinalLink
            };
        }

        public static CashFlowStatement ToModel(this CashFlowStatementDto dto)
        {
            return new CashFlowStatement
            {
                Date = dto.Date,
                Symbol = dto.Symbol,
                ReportedCurrency = dto.ReportedCurrency,
                Cik = dto.Cik,
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
        }
    }
}