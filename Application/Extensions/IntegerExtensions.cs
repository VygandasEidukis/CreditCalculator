namespace Application.Extensions;
public static class IntegerExtensions
{
    public static bool InRange(this int value, int? from, int? to)
    {
        if (from.HasValue && value < from.Value)
        {
            return false;
        }

        if (to.HasValue && value > to.Value)
        {
            return false;
        }

        return true;
    }
}
