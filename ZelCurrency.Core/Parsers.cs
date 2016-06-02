namespace Currency
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Parsers
    {
        public static ParserResult GetCitadele(Match match)
        {
            int rowNumber = match.Groups[1].Value.Split(new string[] { "</tr>" }, StringSplitOptions.None).Length;
            string row = match.Groups[2].Value.Split(new string[] { "</tr>" }, StringSplitOptions.None).Skip(rowNumber - 1).Take(1).Single();
            MatchCollection matches = Regex.Matches(row, @"<td[^>]*>([\d\.\,]+)<\/td>");
            return new ParserResult
            {
                SellResult = matches[1].Groups[1].Value,
                BuyResult = matches[0].Groups[1].Value
            };
        }
    }

    public class ParserResult
    {
        public string SellResult { get; set; }

        public string BuyResult { get; set; }
    }
}