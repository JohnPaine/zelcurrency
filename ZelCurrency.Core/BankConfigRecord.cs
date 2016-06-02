namespace ZelCurrency.Core
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class BankConfigRecord
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string SpecialUrl { get; set; }

        public Encoding Encoding { get; set; }

        public string SellPattern { get; set; }

        public string BuyPattern { get; set; }

        public string GetCurrencyUrl()
        {
            return !string.IsNullOrEmpty(SpecialUrl) ? GetSpecialUrl() : Url;
        }

        private string GetSpecialUrl()
        {
            var specialUrl = SpecialUrl.Replace("{RND}", new Random().Next(1, Int32.MaxValue).ToString(CultureInfo.InvariantCulture));

            if (specialUrl.Contains("{DAYS"))
            {
                specialUrl = Regex.Replace(specialUrl, @"\{DAYS:(\d+)", match => DateTime.Now.AddDays(-1 * Int32.Parse(match.Groups[1].Value)).ToString("yyyy-MM-dd"));
            }

            return specialUrl;
        }
    }
}