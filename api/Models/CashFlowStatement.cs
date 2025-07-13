using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
    [Table("CashFlowStatements")]
    public class CashFlowStatement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public string ReportedCurrency { get; set; }
        public string Cik { get; set; }
        public DateTime FillingDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public int calendarYear { get; set; }
        public string Period { get; set; }
        public double NetIncome { get; set; }
        public double DepreciationAndAmortization { get; set; }
        public double DeferredIncomeTax { get; set; }
        public double StockBasedCompensation { get; set; }
        public double ChangeInWorkingCapital { get; set; }
        public double AccountsReceivables { get; set; }
        public double Inventory { get; set; }
        public double AccountsPayables { get; set; }
        public double OtherWorkingCapital { get; set; }
        public double OtherNonCashItems { get; set; }
        public double NetCashProvidedByOperatingActivities { get; set; }
        public double InvestmentsInPropertyPlantAndEquipment { get; set; }
        public double AcquisitionsNet { get; set; }
        public double PurchasesOfInvestments { get; set; }
        public double SalesMaturitiesOfInvestments { get; set; }
        public double OtherInvestingActivites { get; set; }
        public double NetCashUsedForInvestingActivites { get; set; }
        public double DebtRepayment { get; set; }
        public double CommonStockIssued { get; set; }
        public double CommonStockRepurchased { get; set; }
        public double DividendsPaid { get; set; }
        public double OtherFinancingActivites { get; set; }
        public double NetCashUsedProvidedByFinancingActivities { get; set; }
        public double EffectOfForexChangesOnCash { get; set; }
        public double NetChangeInCash { get; set; }
        public double CashAtEndOfPeriod { get; set; }
        public double CashAtBeginningOfPeriod { get; set; }
        public double OperatingCashFlow { get; set; }
        public double CapitalExpenditure { get; set; }
        public double FreeCashFlow { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }

        // Relationship to Stock
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}