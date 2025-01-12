namespace Community.PowerToys.Run.Plugin.Raindrop
{
#pragma warning disable IDE1006

    public class SearchResult<T>
    {
        public required bool result { get; set; }

        public required List<T> items { get; set; }
    }

    public class Bookmark
    {
        public int _id { get; set; }

        public string? excerpt { get; set; }

        public string? note { get; set; }

        public string? type { get; set; }

        public string? cover { get; set; }

        public List<string>? tags { get; set; }

        public bool? removed { get; set; }

        public string? title { get; set; }

        public string? link { get; set; }

        public string? created { get; set; }

        public string? lastUpdate { get; set; }

        public bool? important { get; set; }

        public string? domain { get; set; }

        public int? sort { get; set; }

        public int? collectionId { get; set; }
    }
}
