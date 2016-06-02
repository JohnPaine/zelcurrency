namespace ZelCurrency.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    using ZelCurrency.Core.Properties;

    public class BankConfigProvider
    {
        public IEnumerable<BankConfigRecord> GetConfigRecords()
        {
            var doc = System.Xml.Linq.XDocument.Load(new StringReader(Resources.BanksConfig));
            return doc.Element("BanksConfig")
                .Element("Banks")
                .Elements("Bank")
                .Where(e => e.Element("PatternSell") != null)
                .Select(BuildRecord)
                .ToArray();
        }
        private static BankConfigRecord BuildRecord(XElement e)
        {
            return new BankConfigRecord()
            {
                Id = TryAttributeValue(e, "Id"),
                Title = TryAttributeValue(e, "Title"),
                Url = TryAttributeValue(e, "Url"),
                Encoding = Encoding.GetEncoding(TryAttributeValue(e, "Encoding", "UTF-8")),
                SpecialUrl = TryAttributeValue(e, "SpecialUrl"),
                SellPattern = e.Element("PatternSell").Value,
                BuyPattern = e.Element("PatternBuy").Value,
            };
        }

        private static string TryAttributeValue(XElement element, string attributeName, string defaultValue = null)
        {
            var attribute = element.Attribute(attributeName);
            if (attribute != null)
            {
                return attribute.Value;
            }
            return defaultValue;
        }
    }
}