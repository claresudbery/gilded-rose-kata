using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var item_index = 0; item_index < _items.Count; item_index++)
            {
                if (Item_quality_decreases_with_age(item_index) && Item_is_not_legendary(item_index))
                {
                    if (_items[item_index].Quality > 0)
                    {
                        Decrement_quality(item_index);
                    }
                }
                else
                {
                    if (_items[item_index].Quality < 50)
                    {
                        Increment_quality(item_index);

                        if (Item_is_backstage_pass(item_index))
                        {
                            if (_items[item_index].SellIn < 11)
                            {
                                if (_items[item_index].Quality < 50)
                                {
                                    Increment_quality(item_index);
                                }
                            }

                            if (_items[item_index].SellIn < 6)
                            {
                                if (_items[item_index].Quality < 50)
                                {
                                    Increment_quality(item_index);
                                }
                            }
                        }
                    }
                }

                if (Item_is_not_legendary(item_index))
                {
                    Decrement_SellIn(item_index);
                }

                if (_items[item_index].SellIn < 0)
                {
                    if (Item_is_not_aged_brie(item_index))
                    {
                        if (Item_is_not_backstage_pass(item_index))
                        {
                            if (_items[item_index].Quality > 0 && Item_is_not_legendary(item_index))
                            {
                                Decrement_quality(item_index);
                            }
                        }
                        else
                        {
                            _items[item_index].Quality = 0;
                        }
                    }
                    else
                    {
                        if (_items[item_index].Quality < 50)
                        {
                            Increment_quality(item_index);
                        }
                    }
                }
            }
        }

        private void Decrement_SellIn(int item_index)
        {
            _items[item_index].SellIn = _items[item_index].SellIn - 1;
        }

        private void Increment_quality(int item_index)
        {
            _items[item_index].Quality = _items[item_index].Quality + 1;
        }

        private void Decrement_quality(int item_index)
        {
            _items[item_index].Quality = _items[item_index].Quality - 1;
        }

        private bool Item_quality_decreases_with_age(int item_index)
        {
            return Item_is_not_aged_brie(item_index) 
                   && Item_is_not_backstage_pass(item_index);
        }

        private bool Item_is_not_aged_brie(int item_index)
        {
            return _items[item_index].Name != ItemNames.AgedBrie;
        }

        private bool Item_is_backstage_pass(int item_index)
        {
            return _items[item_index].Name.Contains(ItemNames.BackstagePasses);
        }

        private bool Item_is_not_backstage_pass(int item_index)
        {
            return !Item_is_backstage_pass(item_index);
        }

        private bool Item_is_not_legendary(int item_index)
        {
            return _items[item_index].Name != ItemNames.Sulfuras;
        }
    }
}
