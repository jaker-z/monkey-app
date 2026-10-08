using CommunityToolkit.Maui.Views;

namespace MonkeyFinder;

public partial class MonkeyAdder : Popup<bool>
{
	public MonkeyAdder()
	{
		InitializeComponent();
	}

	private void OnNoClicked(object sender, EventArgs e)
	{
		CloseAsync(false);
	}

	private void OnYesClicked(object sender, EventArgs e)
	{
		CloseAsync(true);
	}
}