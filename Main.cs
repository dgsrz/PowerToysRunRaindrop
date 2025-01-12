using System.Windows;
using Community.PowerToys.Run.Plugin.Raindrop.Properties;
using ManagedCommon;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Raindrop
{
    /// <summary>
    /// Main class of this plugin that implement all used interfaces.
    /// </summary>
    public partial class Main : IPlugin
    {
        public static string PluginID => "6BDCAE7968C048FFBC5CE900C459A909";

        public string Name => Resources.PluginName;
        public string Description => Resources.PluginDescription;

        private PluginInitContext? Context { get; set; }
        private string? IconPath { get; set; }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            return results;
        }

        public void Init(PluginInitContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(Context.API.GetCurrentTheme());
        }

        private void UpdateIconPath(Theme theme) => IconPath = theme == Theme.Light || theme == Theme.HighContrastWhite ? Context?.CurrentPluginMetadata.IcoPathLight : Context?.CurrentPluginMetadata.IcoPathDark;

        private void OnThemeChanged(Theme currentTheme, Theme newTheme) => UpdateIconPath(newTheme);
    }
}
