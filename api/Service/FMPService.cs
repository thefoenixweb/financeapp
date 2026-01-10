using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Service
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;
        private readonly ILogger<FMPService> _logger;
        public FMPService(HttpClient httpClient, IConfiguration config, ILogger<FMPService> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                // NOTE: symbol is used as-is (no URL encoding)
                var url = $"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={_config["FMPKey"]}";
                var result = await _httpClient.GetAsync(url);

                var content = await result.Content.ReadAsStringAsync();

                if (!result.IsSuccessStatusCode)
                {
                    // log raw response body for debugging
                    Console.WriteLine($"FMP request failed. URL: {url} StatusCode: {(int)result.StatusCode} Body: {content}");
                    return null;
                }

                var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                var stock = tasks != null && tasks.Length > 0 ? tasks[0] : null;
                if (stock != null)
                {
                    return stock.ToStockFromFMP();
                }
                // log empty response body when no stock found
                Console.WriteLine($"FMP returned no stock for symbol '{symbol}'. Raw body: {content}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}