//#region References

//using System;
//using System.Globalization;
//using System.Text.RegularExpressions;
//using System.Xml.Serialization;

//#endregion

//namespace Currency.Configuration
//{
//	[Serializable]
//	public class ParserElement
//	{
		
//		[XmlElement("Function")]
//		public string Function { get; set; }
		
//		[XmlElement("Pattern")]
//        public string Pattern { get; set; }

//        public ParserElement()
//		{
//            this.Function = string.Empty;
//            this.Pattern = string.Empty;
//		}

//	    public string Parse(string answer, bool isSelling)
//	    {
//	        Match match = new Regex(this.Pattern).Match(answer);
//	        ParserResult result = (ParserResult)typeof (Parsers).GetMethod(this.Function).Invoke(null, new object[] {match});
//	        return isSelling ? result.SellResult : result.BuyResult;
//	    }
//	}
//}
