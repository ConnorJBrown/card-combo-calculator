namespace CardComboCalculator.Core;

public static class CollectionExtras
{
    public static bool ContainsAllItems<T>(this IEnumerable<T> a, IEnumerable<T> b)
    {
        return !b.Except(a).Any();
    }
}