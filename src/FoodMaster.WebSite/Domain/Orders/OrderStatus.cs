namespace FoodMaster.WebSite.Domain.Orders
{
    public enum OrderStatus : int
    {
        /*
        [Description("Awaiting Review")]
        AwaitingReview,
        */
        Processing,
        Ready
    }
}