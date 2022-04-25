using System.Globalization;

namespace DslPresentation.Extensions;

public static class StringExtensions
{
    public static string InterpolateRow(this string source, DataRow row)
    {
        return source
            .Replace("{stockName}", row.StockName, StringComparison.InvariantCultureIgnoreCase)
            .Replace("{email}", row.Email, StringComparison.InvariantCultureIgnoreCase)
            .Replace("{id}", row.Id.ToString(), StringComparison.InvariantCultureIgnoreCase)
            .Replace("{ip}", row.Ip, StringComparison.InvariantCultureIgnoreCase)
            .Replace("{currency}", row.Currency, StringComparison.InvariantCultureIgnoreCase)
            .Replace("{price}", row.Price.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCultureIgnoreCase);
    }
}