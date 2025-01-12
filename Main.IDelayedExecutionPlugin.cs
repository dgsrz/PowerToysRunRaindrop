using System.Windows.Media.Imaging;
using Wox.Infrastructure;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Raindrop
{
    public partial class Main : IDelayedExecutionPlugin
    {
        private RaindropClient? _client;

        public List<Result> Query(Query query, bool delayedExecution)
        {
            var results = new List<Result>();

            if (_client == null)
            {
                _client = new RaindropClient(AccessToken);
            }
            if (string.IsNullOrEmpty(query.Search))
            {
                return results;
            }

            var searchResult = _client.Request(query.Search);

            if (searchResult == null)
            {
                return results;
            }
            foreach (var bookmark in searchResult.items)
            {
                results.Add(new Result()
                {
                    Title = bookmark.title,
                    SubTitle = bookmark.link,
                    Icon = () => new BitmapImage(new Uri($"https://www.google.com/s2/favicons?sz=32&domain_url={bookmark.link}")),
                    ContextData = new ContextData()
                    {
                        Url = bookmark.link
                    },
                    Action = _ =>
                    {
                        Helper.OpenInShell(bookmark.link);
                        return true;
                    }
                });
            }
            return results;
        }
    }
}
