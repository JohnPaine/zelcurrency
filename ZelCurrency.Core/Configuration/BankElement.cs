//#region References

//using System;
//using System.Globalization;
//using System.Text.RegularExpressions;
//using System.Xml.Serialization;

//#endregion

//namespace Currency.Configuration
//{
//	[Serializable]
//	public class BankElement : BankElementBase
//	{
//        private static readonly CultureInfo cultureInfo = new CultureInfo("en-US");

//		[XmlAttribute("SpecialUrl")]
//		public string SpecialUrl { get; set; }

//		[XmlAttribute("Encoding")]
//		public string Encoding { get; set; }
		
//		[XmlElement("PatternSell")]
//		public string PatternSell { get; set; }
		
//		[XmlElement("PatternBuy")]
//        public string PatternBuy { get; set; }

//        [XmlElement("Parser")]
//        public ParserElement Parser { get; set; }

//        [XmlAttribute("IsExtended")]
//		public bool IsExtended { get; set; }

//		public BankElement()
//		{
//			this.Id = string.Empty;
//			this.Title = string.Empty;
//			this.PatternSell = string.Empty;
//			this.PatternBuy = string.Empty;
//			this.Encoding = System.Text.Encoding.UTF8.ToString();
//		}
		
//	    public string GetCurrencyUrl()
//	    {
//	        return !string.IsNullOrEmpty(SpecialUrl) ? GetSpecialUrl() : Url;
//	    }

//        private string GetSpecialUrl()
//	    {
//            var specialUrl = SpecialUrl.Replace("{RND}", new Random().Next(1, Int32.MaxValue).ToString(CultureInfo.InvariantCulture));

//            if (specialUrl.Contains("{DAYS"))
//            {
//                specialUrl = Regex.Replace(specialUrl, @"\{DAYS:(\d+)", match => DateTime.Now.AddDays(-1 * Int32.Parse(match.Groups[1].Value)).ToString("yyyy-MM-dd"));
//            }

//            return specialUrl;
//	    }

//	    public int ParseCurrency(string answer, bool isSelling)
//	    {
//            string currency = this.Parser != null ? this.Parser.Parse(answer, isSelling) : new Regex(isSelling ? this.PatternSell : this.PatternBuy).Match(answer).Groups[1].Value;
//	        return (int) Math.Round(Default.ParseDouble(currency) * 100);
//	    }
//	}

//    [Serializable]
//    public class BankElementBase
//    {
//        [XmlAttribute("Id")]
//        public string Id { get; set; }

//        [XmlAttribute("Title")]
//        public string Title { get; set; }

//        [XmlAttribute("Url")]
//        public string Url { get; set; }
//    }
//}
