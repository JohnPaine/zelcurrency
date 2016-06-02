namespace ZelCurrency.Core
{
    using System.Collections.Generic;

    public class FakeCurrencyProvider : ICurrencyProvider
    {
        public IEnumerable<ICurrencyInfo> CurrencyInfos()
        {
            var result = new List<ICurrencyInfo>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new FakeCurrencyInfo("bank" + i, "http://sbrf.ru", "some address " + i));
            }

            return result;
        }
    }
}