using System.Threading.Tasks;

namespace ZelCurrency.Core
{
    public enum ExchangeDirection
    {
        Buy,
        Sell
    }

    public interface ICurrencyInfo
    {
        string BankName { get; }

        string BankUri { get; }

        decimal? BuyRate { get; }
        decimal? SellRate { get; }

        Task LoadExchangeRates ();
    }
}