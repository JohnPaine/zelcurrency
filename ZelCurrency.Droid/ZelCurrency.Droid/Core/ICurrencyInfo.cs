namespace ZelCurrency.Droid.Core
{
    using System.Threading.Tasks;

    public interface ICurrencyInfo
    {
        string BankName { get; }

        string BankUri { get; }

        string BankAddress { get; }

        Task<decimal> GetBuyingCurrency();

        Task<decimal> GetSellingCurrency();
    }
}