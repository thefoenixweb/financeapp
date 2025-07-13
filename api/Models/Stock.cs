using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public double MarketCap { get; set; }

        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

         public ICollection<BalanceSheetStatement> BalanceSheetStatements { get; set; }
        public ICollection<IncomeStatement> IncomeStatements { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
    }
}