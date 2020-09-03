using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const int FirstConcertQualityThreshold = 10;
        private const int SecondConcertQualityThreshold = 5;
        private const int MaxQuality = 50;

        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var item_index = 0; item_index < _items.Count; item_index++)
            {
                Adjust_daily_quality_value(item_index);

                Adjust_number_of_days_until_sell_by_date(item_index);

                Adjust_quality_if_sell_by_date_has_passed(item_index);
            }
        }

        private void Adjust_daily_quality_value(int item_index)
        {
            if (Item_quality_decreases_with_age(item_index))
            {
                Decrement_quality(item_index);
            }
            else
            {
                Increment_quality(item_index);
                Add_extra_quality_if_concert_date_is_near(item_index);
            }
        }

        private void Adjust_number_of_days_until_sell_by_date(int item_index)
        {
            if (Item_is_not_legendary(item_index))
            {
                Decrement_SellIn(item_index);
            }
        }

        private void Adjust_quality_if_sell_by_date_has_passed(int item_index)
        {
            if (_items[item_index].SellIn < 0)
            {
                if (Item_is_aged_brie(item_index))
                {
                    Increment_quality(item_index);
                }
                else
                {
                    if (Item_is_backstage_pass(item_index))
                    {
                        Drop_quality_to_zero(item_index);
                    }
                    else
                    {
                        Decrement_quality(item_index);
                    }
                }
            }
        }

        private void Add_extra_quality_if_concert_date_is_near(int item_index)
        {
            if (Item_is_backstage_pass(item_index))
            {
                if (_items[item_index].SellIn <= FirstConcertQualityThreshold)
                {
                    Increment_quality(item_index);
                }

                if (_items[item_index].SellIn <= SecondConcertQualityThreshold)
                {
                    Increment_quality(item_index);
                }
            }
        }

        private void Decrement_SellIn(int item_index)
        {
            _items[item_index].SellIn = _items[item_index].SellIn - 1;
        }

        private void Increment_quality(int item_index)
        {
            if (_items[item_index].Quality < MaxQuality)
            {
                _items[item_index].Quality = _items[item_index].Quality + 1;
            }
        }

        private void Decrement_quality(int item_index)
        {
            if (_items[item_index].Quality > 0 && Item_is_not_legendary(item_index))
            {
                _items[item_index].Quality = _items[item_index].Quality - 1;
            }
        }

        private void Drop_quality_to_zero(int item_index)
        {
            _items[item_index].Quality = 0;
        }

        private bool Item_quality_decreases_with_age(int item_index)
        {
            return Item_is_not_aged_brie(item_index) 
                   && Item_is_not_backstage_pass(item_index);
        }

        private bool Item_is_aged_brie(int item_index)
        {
            return _items[item_index].Name == ItemNames.AgedBrie;
        }

        private bool Item_is_not_aged_brie(int item_index)
        {
            return !Item_is_aged_brie(item_index);
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
