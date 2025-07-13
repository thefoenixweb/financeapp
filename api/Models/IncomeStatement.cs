using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
    public class IncomeStatement
    {
        [Key]
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string ReportedCurrency { get; set; }
        public string Cik { get; set; }
        public DateTime Date { get; set; }
        public DateTime FillingDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public int calendarYear { get; set; }
        public string Period { get; set; }
        public double Revenue { get; set; }
        public double CostOfRevenue { get; set; }
        public double GrossProfit { get; set; }
        public double GrossProfitRatio { get; set; }
        public double ResearchAndDevelopmentExpenses { get; set; }
        public double GeneralAndAdministrativeExpenses { get; set; }
        public double SellingAndMarketingExpenses { get; set; }
        public double SellingGeneralAndAdministrativeExpenses { get; set; }
        public double OtherExpenses { get; set; }
        public double OperatingExpenses { get; set; }
        public double CostAndExpenses { get; set; }
        public double InterestIncome { get; set; }
        public double InterestExpense { get; set; }
        public double DepreciationAndAmortization { get; set; }
        public double Ebitda { get; set; }
        public double EbitdaRatio { get; set; }
        public double OperatingIncome { get; set; }
        public double OperatingIncomeRatio { get; set; }
        public double TotalOtherIncomeExpensesNet { get; set; }
        public double IncomeBeforeTax { get; set; }
        public double IncomeBeforeTaxRatio { get; set; }
        public double IncomeTaxExpense { get; set; }
        public double NetIncome { get; set; }
        public double NetIncomeRatio { get; set; }
        public double Eps { get; set; }
        public double Epsdiluted { get; set; }
        public long WeightedAverageShsOut { get; set; }
        public long WeightedAverageShsOutDil { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }

        // Relationship to Stock
        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}