using Xamarin.Forms;
using PowerBI.Api.Client;
using PowerBI.Api.Client.Configuration;

namespace XamarinPowerShop
{
	/// <summary>
	/// App.
	/// </summary>
	public class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="XamarinPowerShop.App"/> class.
		/// </summary>
		public App()
		{
			PowerBIClient.Initialize(
				new Api 
				{
					Url = "https://api.powerbi.com/beta/myorg/datasets"
				}, 
					new OAuth 
				{ 
					Authority = "https://login.windows.net/common/oauth2/authorize",
					Resource = "https://analysis.windows.net/powerbi/api",
					Client = "MyClientId",
					User = "MyUser",
					Password ="MyPassword"
				}
			);
			// The root page of your application
			MainPage = new RootPage();
		}
	}
}

