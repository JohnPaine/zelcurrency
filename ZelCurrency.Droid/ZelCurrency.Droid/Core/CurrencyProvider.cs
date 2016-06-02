namespace ZelCurrency.Droid.Core
{
    using System.Collections.Generic;

    public class CurrencyProvider : ICurrencyProvider
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