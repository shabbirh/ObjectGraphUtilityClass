namespace ObjectGraphMergeUtilityClass.Interfaces
{
    public interface IMergable<T>
    {
        T MergeWith(T target);

        T MergeWithRules(T target);
    }
}
