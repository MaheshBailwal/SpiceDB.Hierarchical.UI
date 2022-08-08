namespace SpiceDB.Core.Types
{
    public struct ResultList<T>
    {
        public List<T> Data { get; set; }
    }

    public enum CacheFreshness
    {
        AnyFreshness,
        AtLeastAsFreshAs,
        MustRefresh
    }
}
