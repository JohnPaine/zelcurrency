using System.Collections.Generic;

namespace ZelCurrency.Core
{
    public class FakeCurrencyProvider : ICurrencyProvider
    {
        public IEnumerable<ICurrencyInfo> CurrencyInfos () {
            var result = new List<ICurrencyInfo> ();

            for (var i = 0; i < 10; i++) {
                result.Add (new FakeCurrencyInfo ("bank" + i, "http://sbrf.ru", "some address " + i));
            }

            return result;
        }
    }
}