using System.Windows.Controls;
using Community.PowerToys.Run.Plugin.Raindrop.Properties;
using Microsoft.PowerToys.Settings.UI.Library;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Raindrop
{
	public partial class Main : ISettingProvider
	{
		public string? AccessToken { get; private set; }

		public IEnumerable<PluginAdditionalOption> AdditionalOptions => [
			new()
			{
				Key = nameof(AccessToken),
				DisplayLabel = Resources.AccessTokenDisplayLabel,
				DisplayDescription = Resources.AccessTokenDescription,
				PluginOptionType = PluginAdditionalOption.AdditionalOptionType.Textbox,
				TextValue = ""
			}
		];

		public Control CreateSettingPanel() => throw new NotImplementedException();

		public void UpdateSettings(PowerLauncherPluginSettings settings)
		{
			AccessToken = GetSetting(settings, nameof(AccessToken))?.TextValue ?? GetDefaultOption(nameof(AccessToken)).TextValue;
		}

		private PluginAdditionalOption? GetSetting(PowerLauncherPluginSettings settings, string key)
		{
			return settings.AdditionalOptions.FirstOrDefault(x => x.Key == nameof(key));
		}

		private PluginAdditionalOption GetDefaultOption(string key)
		{
			return ((ISettingProvider)this).AdditionalOptions.First(x => x.Key == key);
		}
	}
}
