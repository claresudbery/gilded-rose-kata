using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTests
    {
        Item _test_ordinary_item_01 = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
        Item _test_aged_brie = new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
        Item _test_ordinary_item_02 = new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
        Item _test_sulfuras_01 = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        Item _test_sulfuras_02 = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80};
        Item _test_backstage_01 = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20};
        Item _test_backstage_02 = new Item {Name = "Backstage passes to a Bob Marley concert", SellIn = 10, Quality = 49};
        Item _test_backstage_03 = new Item {Name = "Backstage passes to a Jungle Boys concert", SellIn = 5, Quality = 49};
        // this conjured item does not work properly yet
        Item _test_conjured_01 = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

        [Test]
        public void After_daily_update_item_name_is_not_altered()
        {
            const String ItemName = "I am a hole, and I live in a mole.";
            IList<Item> items = new List<Item> { new Item { Name = ItemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(ItemName, items[0].Name);
        }

        [Test]
        public void After_daily_update_SellIn_value_for_ordinary_item_goes_down_by_one()
        {
            int initial_sellin_value_01 = _test_ordinary_item_01.SellIn;
            int initial_sellin_value_02 = _test_ordinary_item_02.SellIn;
            IList<Item> items = new List<Item> { _test_ordinary_item_01, _test_ordinary_item_02 };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(initial_sellin_value_01 - 1, items[0].SellIn);
            Assert.AreEqual(initial_sellin_value_02 - 1, items[1].SellIn);
        }
    }
}
