using System.ComponentModel;

namespace FoodMaster.WebSite.Domain
{
    public enum OrderStatus : int
    {
        [Description("Awaiting Review")]
        AwaitingReview,
        Processing,
        Ready
    }
}