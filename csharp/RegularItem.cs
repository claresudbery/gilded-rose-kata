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
            Decrement_quality();
        }

        public void Adjust_number_of_days_until_sell_by_date()
        {
            Decrement_SellIn();
        }

        public void Adjust_quality_if_sell_by_date_has_passed()
        {
            if (_item.SellIn < 0)
            {
                Decrement_quality();
            }
        }

        private void Decrement_SellIn()
        {
            _item.SellIn = _item.SellIn - 1;
        }

        private void Decrement_quality()
        {
            if (_item.Quality > 0)
            {
                _item.Quality = _item.Quality - 1;
            }
        }
    }
}