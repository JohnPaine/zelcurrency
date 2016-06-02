namespace ZelCurrency.Core
{
    using System;
    using System.Threading.Tasks;

    public class FakeCurrencyInfo : ICurrencyInfo
    {
        private const decimal baseExchangeRate = 64m;

        private static readonly Random rnd = new Random();
        public FakeCurrencyInfo(string bankName, string url, string address)
        {
            this.BankName = bankName;
            this.BankUri = url;
            this.BankAddress = address;
        }

        public string BankAddress { get; }

        public string BankName { get; }

        public string BankUri { get; }

        public decimal? BuyRate { get; private set; }

        public decimal? SellRate { get; private set; }

        public async Task LoadExchangeRates()
        {
            await Task.Delay(rnd.Next(10000) + 500);

            this.BuyRate = baseExchangeRate - (decimal)rnd.NextDouble() * 4m;
            this.SellRate = baseExchangeRate + (decimal)rnd.NextDouble() * 4m;
        }
    }
}