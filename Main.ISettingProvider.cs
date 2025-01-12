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
				PluginOptionType = PluginAdditionalOption.AdditionalOptionType.Textbox
			}
		];

		public Control CreateSettingPanel() => throw new NotImplementedException();

		public void UpdateSettings(PowerLauncherPluginSettings settings)
		{
			AccessToken = settings.AdditionalOptions.SingleOrDefault(x => x.Key == nameof(AccessToken))?.TextValue ?? "";
		}
	}
}
