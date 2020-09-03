namespace csharp
{
    public class LegendaryItem : IItem
    {
        private Item _item;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public LegendaryItem(int sell_in, int quality)
        {
            _item = new Item
            {
                Name = ItemNames.Sulfuras,
                SellIn = sell_in,
                Quality = quality
            };
        }

        public LegendaryItem(Item item)
        {
            _item = item;
        }

        public void Adjust_daily_quality_value()
        {
        }

        public void Adjust_number_of_days_until_sell_by_date()
        {
        }

        public void Adjust_quality_after_sell_by_date_has_passed()
        {
        }
    }
}