using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTests
    {
        Item _test_ordinary_item_01 = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
        Item _test_aged_brie = new Item {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0};
        Item _test_ordinary_item_02 = new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
        Item _test_sulfuras_01 = new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80};
        Item _test_sulfuras_02 = new Item {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80};
        Item _test_backstage_01 = new Item {Name = $"{ItemNames.BackstagePasses} to a TAFKAL80ETC concert", SellIn = 15, Quality = 20};
        Item _test_backstage_02 = new Item {Name = $"{ItemNames.BackstagePasses} to a Bob Marley concert", SellIn = 10, Quality = 49};
        Item _test_backstage_03 = new Item {Name = $"{ItemNames.BackstagePasses} to a Jungle Boys concert", SellIn = 5, Quality = 49};
        // this conjured item does not work properly yet
        Item _test_conjured_01 = new Item {Name = ItemNames.Conjured, SellIn = 3, Quality = 6};

        [Test]
        public void After_daily_update_item_name_is_not_altered()
        {
            const String ItemName = "I am a hole, and I live in a mole.";
            IList<Item> items = new List<Item> { new Item { Name = ItemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(ItemName, items[0].Name);
        }

        [TestCase("+5 Dexterity Vest")]
        [TestCase(ItemNames.AgedBrie)]
        [TestCase("Elixir of the Mongoose")]
        [TestCase("Backstage passes to a TAFKAL80ETC concert")]
        [TestCase("Backstage passes to a Bob Marley concert")]
        [TestCase("Backstage passes to a Jungle Boys concert")]
        public void After_daily_update_SellIn_value_for_all_items__except_sulfuras_goes_down_by_one(string item_name)
        {
            int initial_sellin_value = 10;
            IList<Item> items = new List<Item> { new Item { Name = item_name, SellIn = initial_sellin_value, Quality = 20 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value - 1, items[0].SellIn);
        }

        [Test]
        public void After_daily_update_SellIn_value_for_sulfuras_remains_the_same()
        {
            int initial_sellin_value = 10;
            IList<Item> items = new List<Item> { new Item { Name = _test_sulfuras_01.Name, SellIn = initial_sellin_value, Quality = 20 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value, items[0].SellIn);
        }

        [Test]
        public void After_daily_update_Quality_value_for_ordinary_items_goes_down_by_one()
        {
            int initial_quality_value_01 = _test_ordinary_item_01.Quality;
            int initial_quality_value_02 = _test_ordinary_item_02.Quality;
            IList<Item> items = new List<Item> { _test_ordinary_item_01, _test_ordinary_item_02 };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value_01 - 1, items[0].Quality);
            Assert.AreEqual(initial_quality_value_02 - 1, items[1].Quality);
        }

        [Test]
        public void After_daily_update_Quality_value_for_aged_brie_goes_up_by_one()
        {
            int initial_quality_value = _test_aged_brie.Quality;
            IList<Item> items = new List<Item> { _test_aged_brie };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(initial_quality_value + 1, items[0].Quality);
        }
    }
}
