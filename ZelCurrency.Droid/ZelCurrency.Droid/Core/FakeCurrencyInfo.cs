namespace ZelCurrency.Droid.Core
{
    using System;
    using System.Threading.Tasks;

    public class FakeCurrencyInfo : ICurrencyInfo
    {
        public FakeCurrencyInfo(string bankName, string url, string address)
        {
            this.BankName = bankName;
            this.BankUri = url;
            this.BankAddress = address;
        }

        public string BankName { get; }

        public string BankUri { get; }

        public string BankAddress { get; }

        private static Random rnd = new Random();
        private const decimal baseExchangeRate = 64m;
        public async Task<decimal> GetBuyingCurrency()
        {
            await Task.Delay(rnd.Next(10000) + 500);

            return baseExchangeRate + (decimal)rnd.NextDouble() * 4m;
        }

        public async Task<decimal> GetSellingCurrency()
        {
            await Task.Delay(rnd.Next(10000) + 500);

            return baseExchangeRate - (decimal)rnd.NextDouble() * 4m;
        }
    }
}