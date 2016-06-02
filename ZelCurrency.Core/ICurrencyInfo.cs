namespace ZelCurrency.Core
{
    using System.Threading.Tasks;

    public interface ICurrencyInfo
    {
        string BankName { get; }

        string BankUri { get; }

        decimal? BuyRate { get; }
        decimal? SellRate { get; }

        Task LoadExchangeRates();
    }
}