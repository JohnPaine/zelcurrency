namespace ZelCurrency.Core
{
    using System.Collections.Generic;
    using System.Linq;

    public class CurrencyProvider : ICurrencyProvider
    {
        public IEnumerable<ICurrencyInfo> CurrencyInfos()
        {
            return new BankConfigProvider().GetConfigRecords()
                .Select(r => new WebPageParserCurrencyInfo(r))
                .ToArray();
        }
    }
}