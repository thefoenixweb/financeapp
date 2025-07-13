using System;
using System.Collections.Generic;

namespace api.TempDbModels;

public partial class CompanyProfile
{
    public int Id { get; set; }

    public string Symbol { get; set; } = null!;

    public double Price { get; set; }

    public double Beta { get; set; }

    public double VolAvg { get; set; }

    public double MktCap { get; set; }

    public double LastDiv { get; set; }

    public string Range { get; set; } = null!;

    public double Changes { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string Cik { get; set; } = null!;

    public string Isin { get; set; } = null!;

    public string Cusip { get; set; } = null!;

    public string Exchange { get; set; } = null!;

    public string ExchangeShortName { get; set; } = null!;

    public string Industry { get; set; } = null!;

    public string Website { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Ceo { get; set; } = null!;

    public string Sector { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string FullTimeEmployees { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public double DcfDiff { get; set; }

    public double Dcf { get; set; }

    public string Image { get; set; } = null!;

    public DateTime IpoDate { get; set; }

    public bool DefaultImage { get; set; }

    public bool IsEtf { get; set; }

    public bool IsActivelyTrading { get; set; }

    public bool IsAdr { get; set; }

    public bool IsFund { get; set; }

    public int? StockId { get; set; }

    public virtual Stock? Stock { get; set; }
}
