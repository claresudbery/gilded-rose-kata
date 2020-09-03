namespace csharp
{
    internal class RegularItem : IItem
    {
        private const int MaxQuality = 50;

        private Item _item;
        public int Quality => _item.Quality;
        public int SellIn => _item.SellIn;

        public RegularItem(Item item)
        {
            _item = item;
        }

        public void Adjust_quality_if_sell_by_date_has_passed()
        {
            if (_item.SellIn < 0)
            {
                if (Item_is_aged_brie())
                {
                    Increment_quality();
                }
                else
                {
                    if (Item_is_backstage_pass())
                    {
                        Drop_quality_to_zero();
                    }
                    else
                    {
                        Decrement_quality();
                    }
                }
            }
        }

        private bool Item_is_aged_brie()
        {
            return _item.Name == ItemNames.AgedBrie;
        }

        private void Increment_quality()
        {
            if (_item.Quality < MaxQuality)
            {
                _item.Quality = _item.Quality + 1;
            }
        }

        private bool Item_is_backstage_pass()
        {
            return _item.Name.Contains(ItemNames.BackstagePasses);
        }

        private void Drop_quality_to_zero()
        {
            _item.Quality = 0;
        }

        private void Decrement_quality()
        {
            if (_item.Quality > 0 && Item_is_not_legendary())
            {
                _item.Quality = _item.Quality - 1;
            }
        }

        private bool Item_is_not_legendary()
        {
            return _item.Name != ItemNames.Sulfuras;
        }
    }
}