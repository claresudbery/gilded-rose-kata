using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        readonly IList<IItem> _self_managing_items = new List<IItem>();

        public GildedRose(IList<IItem> self_managing_items)
        {
            _self_managing_items = self_managing_items;
        }

        public void UpdateQuality()
        {
            for (var item_index = 0; item_index < _self_managing_items.Count; item_index++)
            {
                Update_daily_quality_value(item_index);

                Update_number_of_days_until_sell_by_date(item_index);

                Update_quality_if_sell_by_date_has_passed(item_index);
            }
        }

        private void Update_daily_quality_value(int item_index)
        {
            _self_managing_items[item_index].Update_daily_quality_value();
        }

        private void Update_number_of_days_until_sell_by_date(int item_index)
        {
            _self_managing_items[item_index].Update_number_of_days_until_sell_by_date();
        }

        private void Update_quality_if_sell_by_date_has_passed(int item_index)
        {
            if (_self_managing_items[item_index].SellIn < 0)
            {
                _self_managing_items[item_index].Update_quality_after_sell_by_date_has_passed();
            }
        }
    }
}
