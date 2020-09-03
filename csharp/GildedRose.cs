using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        readonly IList<IItem> _self_managing_items = new List<IItem>();

        public GildedRose(IList<Item> items)
        {
            _items = items;
            Build_self_managing_items(_items);
        }

        private void Build_self_managing_items(IList<Item> items)
        {
            for (var item_index = 0; item_index < _items.Count; item_index++)
            {
                if (Item_is_backstage_pass(item_index))
                {
                    _self_managing_items.Add(new BackstagePassItem(_items[item_index]));
                }
                else if (Item_is_aged_brie(item_index))
                {
                    _self_managing_items.Add(new RegularItem(_items[item_index]));
                }
                else if (Item_is_legendary(item_index))
                {
                    _self_managing_items.Add(new RegularItem(_items[item_index]));
                }
                else if (Item_is_regular_item(item_index))
                {
                    _self_managing_items.Add(new RegularItem(_items[item_index]));
                }
            }
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
            _self_managing_items[item_index].Adjust_daily_quality_value();
        }

        private void Adjust_number_of_days_until_sell_by_date(int item_index)
        {
            _self_managing_items[item_index].Adjust_number_of_days_until_sell_by_date();
        }

        private void Adjust_quality_if_sell_by_date_has_passed(int item_index)
        {
            _self_managing_items[item_index].Adjust_quality_if_sell_by_date_has_passed();
        }

        private bool Item_is_regular_item(int item_index)
        {
            return Item_is_not_aged_brie(item_index)
                   && Item_is_not_backstage_pass(item_index)
                   && Item_is_not_legendary(item_index);
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

        private bool Item_is_legendary(int item_index)
        {
            return _items[item_index].Name == ItemNames.Sulfuras;
        }

        private bool Item_is_not_legendary(int item_index)
        {
            return !Item_is_legendary(item_index);
        }
    }
}
