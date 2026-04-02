using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvestingManagerApp.Services
{
    public class MOEXService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<decimal?> GetLastPriceAsync(Security security)
        {
            var url = GetMoexUrl(security);

            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty("marketdata", out var marketData))
                return null;

            var columns = marketData.GetProperty("columns");
            var data = marketData.GetProperty("data");

            if (data.GetArrayLength() == 0)
                return null;

            var priceIndex = -1;

            for (var i = 0; i < columns.GetArrayLength(); i++)
            {
                if (columns[i].GetString() == "LAST")
                {
                    priceIndex = i;
                    break;
                }
            }

            if (priceIndex == -1)
                return null;

            var firstRow = data[0];

            if (firstRow[priceIndex].ValueKind == JsonValueKind.Null)
                return null;

            return firstRow[priceIndex].GetDecimal();
        }
        private string GetMoexUrl(Security security)
        {
            return security.Type switch
            {
                SecurityType.Stock => $"https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities/{security.Ticker}.json",
                SecurityType.Fund => $"https://iss.moex.com/iss/engines/stock/markets/shares/boards/TQTF/securities/{security.Ticker}.json",
                SecurityType.Bond => $"https://iss.moex.com/iss/engines/stock/markets/bonds/boards/TQOB/securities/{security.Ticker}.json",
                _ => throw new InvalidOperationException("Неизвестный тип бумаги")
            };
        }
    }
}
