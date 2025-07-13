using System;
using System.Collections.Generic;

namespace api.TempDbModels;

public partial class BalanceSheetStatement
{
    public int Id { get; set; }

    public string Symbol { get; set; } = null!;

    public string ReportedCurrency { get; set; } = null!;

    public string Cik { get; set; } = null!;

    public DateTime Date { get; set; }

    public DateTime FillingDate { get; set; }

    public DateTime AcceptedDate { get; set; }

    public int CalendarYear { get; set; }

    public string Period { get; set; } = null!;

    public double CashAndCashEquivalents { get; set; }

    public double ShortTermInvestments { get; set; }

    public double CashAndShortTermInvestments { get; set; }

    public double NetReceivables { get; set; }

    public double Inventory { get; set; }

    public double OtherCurrentAssets { get; set; }

    public double TotalCurrentAssets { get; set; }

    public double PropertyPlantEquipmentNet { get; set; }

    public double Goodwill { get; set; }

    public double IntangibleAssets { get; set; }

    public double GoodwillAndIntangibleAssets { get; set; }

    public double LongTermInvestments { get; set; }

    public double TaxAssets { get; set; }

    public double OtherNonCurrentAssets { get; set; }

    public double TotalNonCurrentAssets { get; set; }

    public double OtherAssets { get; set; }

    public double TotalAssets { get; set; }

    public double AccountPayables { get; set; }

    public double ShortTermDebt { get; set; }

    public double TaxPayables { get; set; }

    public double DeferredRevenue { get; set; }

    public double OtherCurrentLiabilities { get; set; }

    public double TotalCurrentLiabilities { get; set; }

    public double LongTermDebt { get; set; }

    public double DeferredRevenueNonCurrent { get; set; }

    public double DeferredTaxLiabilitiesNonCurrent { get; set; }

    public double OtherNonCurrentLiabilities { get; set; }

    public double TotalNonCurrentLiabilities { get; set; }

    public double OtherLiabilities { get; set; }

    public double CapitalLeaseObligations { get; set; }

    public double TotalLiabilities { get; set; }

    public double PreferredStock { get; set; }

    public double CommonStock { get; set; }

    public double RetainedEarnings { get; set; }

    public double AccumulatedOtherComprehensiveIncomeLoss { get; set; }

    public double OthertotalStockholdersEquity { get; set; }

    public double TotalStockholdersEquity { get; set; }

    public double TotalEquity { get; set; }

    public double TotalLiabilitiesAndStockholdersEquity { get; set; }

    public double MinorityInterest { get; set; }

    public double TotalLiabilitiesAndTotalEquity { get; set; }

    public double TotalInvestments { get; set; }

    public double TotalDebt { get; set; }

    public double NetDebt { get; set; }

    public string Link { get; set; } = null!;

    public string FinalLink { get; set; } = null!;

    public int? StockId { get; set; }

    public virtual Stock? Stock { get; set; }
}
