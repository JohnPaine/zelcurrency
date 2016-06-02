namespace ZelCurrency.Core
{
    using System.Collections.Generic;

    public interface ICurrencyProvider
    {
        IEnumerable<ICurrencyInfo> CurrencyInfos ();
    }
}