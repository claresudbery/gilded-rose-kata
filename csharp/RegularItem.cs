namespace csharp
{
    internal class RegularItem : IItem
    {
        private Item _item;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public RegularItem(Item item)
        {
            _item = item;
        }

        public void Adjust_daily_quality_value()
        {
            _item.Decrement_quality();
        }

        public void Adjust_number_of_days_until_sell_by_date()
        {
            _item.Decrement_sellIn();
        }

        public void Adjust_quality_after_sell_by_date_has_passed()
        {
            _item.Decrement_quality();
        }
    }
}