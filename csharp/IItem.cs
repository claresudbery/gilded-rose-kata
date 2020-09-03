namespace csharp
{
    public interface IItem
    {
        int Quality { get; }
        int SellIn { get; }
        void Adjust_quality_if_sell_by_date_has_passed();
    };
}