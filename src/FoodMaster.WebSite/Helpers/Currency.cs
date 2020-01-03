using System.Globalization;

namespace FoodMaster.WebSite.Helpers
{
    public static class Currency
    {
        public static string AsRubles(decimal value) => value.ToString("C", CultureInfo.GetCultureInfo("ru-ru"));
    }
}
