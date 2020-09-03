namespace csharp
{
    public class BackstagePassItem : IItem
    {
        private const int FirstConcertQualityThreshold = 10;
        private const int SecondConcertQualityThreshold = 5;
        private const int MaxQuality = 50;

        private Item _item;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public BackstagePassItem(int sell_in, int quality)
        {
            _item = new Item
            {
                Name = ItemNames.BackstagePasses, 
                SellIn = sell_in, 
                Quality = quality
            };
        }

        public BackstagePassItem(Item item)
        {
            _item = item;
        }

        public void Adjust_daily_quality_value()
        {
            Increment_quality();
            Add_extra_quality_if_concert_date_is_near();
        }

        public void Adjust_number_of_days_until_sell_by_date()
        {
            Decrement_SellIn();
        }

        public void Adjust_quality_after_sell_by_date_has_passed()
        {
            _item.Quality = 0;
        }

        private void Add_extra_quality_if_concert_date_is_near()
        {
            if (_item.SellIn <= FirstConcertQualityThreshold)
            {
                Increment_quality();
            }

            if (_item.SellIn <= SecondConcertQualityThreshold)
            {
                Increment_quality();
            }
        }

        private void Decrement_SellIn()
        {
            _item.SellIn = _item.SellIn - 1;
        }

        private void Increment_quality()
        {
            if (_item.Quality < MaxQuality)
            {
                _item.Quality = _item.Quality + 1;
            }
        }
    }
}