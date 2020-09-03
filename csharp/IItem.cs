namespace csharp
{
    public interface IItem
    {
        int Quality { get; }
        int SellIn { get; }
        void Adjust_daily_quality_value();
        void Adjust_number_of_days_until_sell_by_date();
        void Adjust_quality_if_sell_by_date_has_passed();
    };
}