using System;
using System.Collections.Generic;

namespace api.TempDbModels;

public partial class Stock
{
    public int Id { get; set; }

    public string Symbol { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public decimal Purchase { get; set; }

    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = null!;

    public double MarketCap { get; set; }

    public virtual ICollection<BalanceSheetStatement> BalanceSheetStatements { get; set; } = new List<BalanceSheetStatement>();

    public virtual ICollection<CashFlowStatement> CashFlowStatements { get; set; } = new List<CashFlowStatement>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual CompanyProfile? CompanyProfile { get; set; }

    public virtual ICollection<IncomeStatement> IncomeStatements { get; set; } = new List<IncomeStatement>();

    public virtual ICollection<AspNetUser> AppUsers { get; set; } = new List<AspNetUser>();
}
