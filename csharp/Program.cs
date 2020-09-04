using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            //Use_items();
            Use_self_managaing_items();
        }

        private static void Use_items()
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = $"{ItemNames.BackstagePasses} to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new Item {Name = $"{ItemNames.BackstagePasses} to a Bob Marley concert", SellIn = 10, Quality = 49},
                new Item {Name = $"{ItemNames.BackstagePasses} to a Jungle Boys concert", SellIn = 5, Quality = 49},
                // this conjured item does not work properly yet
                new Item {Name = ItemNames.Conjured, SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }

        private static void Use_self_managaing_items()
        {
            IList<IItem> self_managing_items = new List<IItem>
            {
                new RegularItem ("+5 Dexterity Vest", 10, 20),
                new AgedBrieItem (2, 0),
                new RegularItem ("Elixir of the Mongoose", 5, 7),
                new LegendaryItem (0, 80),
                new LegendaryItem (-1, 80),
                new BackstagePassItem (" to a TAFKAL80ETC concert", 15, 20),
                new BackstagePassItem (" to a Bob Marley concert", 10, 49),
                new BackstagePassItem (" to a Jungle Boys concert", 5, 49),
                // this conjured item does not work properly yet
                new RegularItem (ItemNames.Conjured, 3, 6)
            };

            var app = new GildedRose(self_managing_items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < self_managing_items.Count; j++)
                {
                    System.Console.WriteLine(self_managing_items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
