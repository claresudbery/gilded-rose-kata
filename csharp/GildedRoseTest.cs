using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void After_daily_update_item_name_is_not_altered()
        {
            const String ItemName = "I am a hole, and I live in a mole.";
            IList<Item> Items = new List<Item> { new Item { Name = ItemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(ItemName, Items[0].Name);
        }
    }
}
