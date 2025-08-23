using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("CashFlowStatements")]
    public class CashFlowStatement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Symbol { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string ReportedCurrency { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Cik { get; set; }

        public DateTime FillingDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public int calendarYear { get; set; }

        [Column(TypeName = "varchar(255)")]
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

        [Column(TypeName = "varchar(255)")]
        public string Link { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FinalLink { get; set; }

        // Relationship to Stock
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}