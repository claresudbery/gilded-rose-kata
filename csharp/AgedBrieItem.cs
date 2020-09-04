namespace csharp
{
    public class AgedBrieItem : IItem
    {
        private Item _item;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public AgedBrieItem(int sell_in, int quality)
        {
            _item = new Item
            {
                Name = ItemNames.AgedBrie,
                SellIn = sell_in,
                Quality = quality
            };
        }

        public AgedBrieItem(Item item)
        {
            _item = item;
        }

        public void Adjust_daily_quality_value()
        {
            _item.Increment_quality();
        }

        public void Adjust_number_of_days_until_sell_by_date()
        {
            _item.Decrement_sellIn();
        }

        public void Adjust_quality_after_sell_by_date_has_passed()
        {
            _item.Increment_quality();
        }
    }
}