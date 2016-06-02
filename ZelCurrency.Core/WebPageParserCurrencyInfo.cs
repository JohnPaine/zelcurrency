namespace ZelCurrency.Core
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class WebPageParserCurrencyInfo : ICurrencyInfo
    {
        private readonly BankConfigRecord cfgRecord;

        private HttpClient httpClient;
        public WebPageParserCurrencyInfo(BankConfigRecord cfg)
        {
            this.cfgRecord = cfg;
        }

        public string BankName => this.cfgRecord.Title;

        public string BankUri => this.cfgRecord.Url;

        public decimal? BuyRate { get; private set; }

        public decimal? SellRate { get; private set; }

        public async Task LoadExchangeRates()
        {
            var message = await this.GetAsync();
            this.SellRate = this.ParseCurrency(message, true);
            this.BuyRate = this.ParseCurrency(message, false);
        }

        private async Task<string> GetAsync()
        {
            var request = WebRequest.Create(this.cfgRecord.GetCurrencyUrl());

            using (var response = await request.GetResponseAsync())
            {
                var reader = new StreamReader(response.GetResponseStream());
                return await reader.ReadToEndAsync();
            }
        }

        public static double ParseDouble(string number)
        {
            string result = Regex.Replace(number.Replace(",", "."), @"\s+", "");
            return Double.Parse(result);
        }

        private decimal ParseCurrency(string answer, bool isSelling)
        {
            string currency = new Regex(isSelling ? this.cfgRecord.SellPattern : this.cfgRecord.BuyPattern).Match(answer).Groups[1].Value;
            return (int)Math.Round(ParseDouble(currency) * 100) / 100m;
        }
    }
}