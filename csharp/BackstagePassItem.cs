namespace csharp
{
    public class BackstagePassItem : IItem
    {
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

        public void Adjust_quality_if_sell_by_date_has_passed()
        {
            if (_item.SellIn < 0)
            {
                _item.Quality = 0;
            }
        }
    }
}