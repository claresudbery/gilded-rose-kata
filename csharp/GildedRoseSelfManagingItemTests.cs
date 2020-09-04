using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseSelfManagingItemTests
    {
        RegularItem _test_ordinary_item_01 = new RegularItem("+5 Dexterity Vest", 10, 20);
        AgedBrieItem _test_aged_brie = new AgedBrieItem(2, 0);
        RegularItem _test_ordinary_item_02 = new RegularItem("Elixir of the Mongoose", 5, 7);
        LegendaryItem _test_sulfuras_01 = new LegendaryItem(0, 80);
        LegendaryItem _test_sulfuras_02 = new LegendaryItem(-1, 80);
        BackstagePassItem _test_backstage_01 = new BackstagePassItem(" to a TAFKAL80ETC concert", 15, 20);
        BackstagePassItem _test_backstage_02 = new BackstagePassItem(" to a Bob Marley concert", 10, 49);
        BackstagePassItem _test_backstage_03 = new BackstagePassItem(" to a Jungle Boys concert", 5, 49);
        // this conjured item does not work properly yet
        RegularItem _test_conjured_01 = new RegularItem(ItemNames.Conjured, 3, 6);

        [Test]
        public void After_daily_update_SellIn_value_for_backstage_pass_items_goes_down_by_one()
        {
            int initial_sellin_value = 10;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem(" to a TAFKAL80ETC concert", initial_sellin_value, 20) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value - 1, self_managing_items[0].SellIn);
        }

        [Test]
        public void After_daily_update_SellIn_value_for_regular_items_goes_down_by_one()
        {
            int initial_sellin_value = 10;
            IList<IItem> self_managing_items = new List<IItem> { new RegularItem("some miscellaneous item", initial_sellin_value, 20) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value - 1, self_managing_items[0].SellIn);
        }

        [Test]
        public void After_daily_update_SellIn_value_for_aged_brie_items_goes_down_by_one()
        {
            int initial_sellin_value = 10;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(initial_sellin_value, 20) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value - 1, self_managing_items[0].SellIn);
        }

        [Test]
        public void After_daily_update_SellIn_value_for_sulfuras_remains_the_same()
        {
            int initial_sellin_value = _test_sulfuras_01.SellIn;
            IList<IItem> self_managing_items = new List<IItem> { _test_sulfuras_01 };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value, self_managing_items[0].SellIn);
        }

        [Test]
        public void After_daily_update_Quality_value_for_sulfuras_remains_the_same()
        {
            int initial_quality_value = _test_sulfuras_01.Quality;
            IList<IItem> self_managing_items = new List<IItem> { _test_sulfuras_01 };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value, self_managing_items[0].Quality);
        }

        [Test]
        public void After_daily_update_Quality_value_for_ordinary_items_goes_down_by_one()
        {
            int initial_quality_value_01 = _test_ordinary_item_01.Quality;
            int initial_quality_value_02 = _test_ordinary_item_02.Quality;
            IList<IItem> self_managing_items = new List<IItem> { _test_ordinary_item_01, _test_ordinary_item_02 };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value_01 - 1, self_managing_items[0].Quality);
            Assert.AreEqual(initial_quality_value_02 - 1, self_managing_items[1].Quality);
        }

        [Test]
        public void After_daily_update_Quality_value_for_aged_brie_goes_up_by_one()
        {
            int initial_quality_value = _test_aged_brie.Quality;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(20, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value + 1, self_managing_items[0].Quality);
        }

        [Test]
        public void Once_the_sell_by_date_has_passed_aged_brie_quality_goes_up_by_two_each_day()
        {
            int initial_quality_value = _test_aged_brie.Quality;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(-2, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value + 2, self_managing_items[0].Quality);
        }

        [Test]
        public void Once_the_sell_by_date_has_passed_aged_brie_quality_will_not_go_above_50()
        {
            int initial_quality_value = 50;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(-2, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality <= 50);
        }

        [Test]
        public void The_quality_of_regular_items_never_goes_above_50()
        {
            int initial_quality_value = 50;
            IList<IItem> self_managing_items = new List<IItem> { new RegularItem("+5 Dexterity Vest", 10, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality <= 50);
        }

        [Test]
        public void The_quality_of_backstage_pass_items_never_goes_above_50()
        {
            int initial_quality_value = 50;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem(" to a TAFKAL80ETC concert", 10, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality <= 50);
        }

        [Test]
        public void The_quality_of_aged_brie_items_never_goes_above_50()
        {
            int initial_quality_value = 50;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(10, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality <= 50);
        }

        [TestCase(10)]
        [TestCase(-2)]
        public void The_quality_of_a_regular_item_is_never_negative(int sellin)
        {
            int initial_quality_value = 0;
            IList<IItem> self_managing_items = new List<IItem> { new RegularItem("Elixir of the Mongoose", sellin, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality >= 0);
        }

        [TestCase(10)]
        [TestCase(-2)]
        public void The_quality_of_a_backstage_pass_item_is_never_negative(int sellin)
        {
            int initial_quality_value = 0;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem(" to a Jungle Boys concert", sellin, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality >= 0);
        }

        [TestCase(10)]
        [TestCase(-2)]
        public void The_quality_of_an_aged_brie_item_is_never_negative(int sellin)
        {
            int initial_quality_value = 0;
            IList<IItem> self_managing_items = new List<IItem> { new AgedBrieItem(sellin, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality >= 0);
        }

        [TestCase(10)]
        [TestCase(-2)]
        public void The_quality_of_a_legendary_item_is_never_negative(int sellin)
        {
            int initial_quality_value = 0;
            IList<IItem> self_managing_items = new List<IItem> { new LegendaryItem(sellin, initial_quality_value) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.IsTrue(self_managing_items[0].Quality >= 0);
        }

        [Test]
        public void Once_a_sell_by_date_is_passed_the_quality_of_regular_items_decreases_by_two_per_day()
        {
            const int InitialQualityValue = 10;
            const int PastSellByDate = 0;
            IList<IItem> self_managing_items = new List<IItem> { new RegularItem("Elixir of the Mongoose", PastSellByDate, InitialQualityValue) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(InitialQualityValue - 2, self_managing_items[0].Quality);
        }

        [TestCase(50)]
        [TestCase(30)]
        [TestCase(11)]
        public void After_daily_update_Quality_value_for_backstage_pass_goes_up_by_one_if_more_than_ten_days_to_go(int sellin)
        {
            const int InitialQualityValue = 10;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem("to Prince", sellin, InitialQualityValue) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(InitialQualityValue + 1, self_managing_items[0].Quality);
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(8)]
        [TestCase(7)]
        [TestCase(6)]
        public void Quality_of_backstage_pass_increases_by_two_each_day_between_ten_days_and_six_days_before_concert_date(int sellin)
        {
            const int InitialQualityValue = 10;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem("to Madonna", sellin, InitialQualityValue) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(InitialQualityValue + 2, self_managing_items[0].Quality);
        }

        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void Quality_of_backstage_pass_increases_by_three_each_day_five_days_or_less_before_concert_date(int sellin)
        {
            const int InitialQualityValue = 10;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem("to the Alabama 3", sellin, InitialQualityValue) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(InitialQualityValue + 3, self_managing_items[0].Quality);
        }

        [Test]
        public void Quality_of_backstage_pass_drops_to_zero_after_concert_date()
        {
            const int InitialQualityValue = 10;
            const int PastConcertDate = 0;
            IList<IItem> self_managing_items = new List<IItem> { new BackstagePassItem("to Fontaines DC", PastConcertDate, InitialQualityValue) };
            GildedRose app = new GildedRose(self_managing_items);
            app.UpdateQuality();
            Assert.AreEqual(0, self_managing_items[0].Quality);
        }
    }
}
