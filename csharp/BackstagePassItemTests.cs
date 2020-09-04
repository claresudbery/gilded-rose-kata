using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class BackstagePassItemTests
    {
        [Test]
        public void Quality_drops_to_zero_after_concert_date()
        {
            const int InitialQualityValue = 10;
            const int PastConcertDate = -1;
            BackstagePassItem backstage_pass_item = new BackstagePassItem(PastConcertDate, InitialQualityValue);
            backstage_pass_item.Update_quality_after_sell_by_date_has_passed();
            Assert.AreEqual(0, backstage_pass_item.Quality);
        }
    }
}