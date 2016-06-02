using System.Collections.Generic;

namespace ZelCurrency.Droid.Core
{
    public interface ICurrencyProvider
    {
        IEnumerable<ICurrencyInfo> CurrencyInfos ();
    }
}