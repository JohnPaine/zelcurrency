namespace ZelCurrency.Core.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BankConfigProviderTests
    {
        [Test]
        public void GetConfigRecords_ShouldReturnValidRecords()
        {
            var target = new BankConfigProvider();
            var records = target.GetConfigRecords();

            Assert.NotNull(records);
            foreach (var bankConfigRecord in records)
            {
                Assert.False(string.IsNullOrWhiteSpace(bankConfigRecord.SellPattern));
                Assert.False(string.IsNullOrWhiteSpace(bankConfigRecord.BuyPattern));
                Assert.NotNull(bankConfigRecord.Encoding);
                Assert.False(string.IsNullOrWhiteSpace(bankConfigRecord.Id));
                Assert.False(string.IsNullOrWhiteSpace(bankConfigRecord.Title));
                Assert.False(string.IsNullOrWhiteSpace(bankConfigRecord.Url));
            }
        }
    }
}