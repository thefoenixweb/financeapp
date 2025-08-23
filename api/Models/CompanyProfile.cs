using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("CompanyProfiles")]
    public class CompanyProfile
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Symbol { get; set; }

        public double Price { get; set; }
        public double Beta { get; set; }
        public double VolAvg { get; set; }
        public double MktCap { get; set; }
        public double LastDiv { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Range { get; set; }

        public double Changes { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Currency { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Cik { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Isin { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Cusip { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Exchange { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string ExchangeShortName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Industry { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Website { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Ceo { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Sector { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FullTimeEmployees { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string State { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Zip { get; set; }

        public double DcfDiff { get; set; }
        public double Dcf { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }

        public DateTime IpoDate { get; set; }
        public bool DefaultImage { get; set; }
        public bool IsEtf { get; set; }
        public bool IsActivelyTrading { get; set; }
        public bool IsAdr { get; set; }
        public bool IsFund { get; set; }

        public int? StockId { get; set; }
        public Stock Stock { get; set; }
    }
}