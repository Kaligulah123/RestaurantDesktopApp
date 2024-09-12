using CommunityToolkit.Maui.Views;

namespace RestaurantDesktopApp.Controls;

public partial class HelpPopup : Popup
{
    public const string Email = "XXX@hotmail.com";

    public const string Phone = "123456789";
    public HelpPopup()
	{
		InitializeComponent();
	}

    private async void CloseLabel_Tapped(object sender, TappedEventArgs e) => await this.CloseAsync();

    private async void CopyEmail_Tapped(object sender, TappedEventArgs e)
    {
        await Clipboard.Default.SetTextAsync(Email);

        copyEmailLabel.Text = "Copiado!";

        await Task.Delay(1500);

        copyEmailLabel.Text = "Copiar";
    }

    private async void CopyPhone_Tapped(object sender, TappedEventArgs e)
    {
        await Clipboard.Default.SetTextAsync(Phone);

        copyPhoneLabel.Text = "Copiado!";

        await Task.Delay(1500);

        copyPhoneLabel.Text = "Copiar";
    }

    //private void OpenWeb(object sender, TappedEventArgs e)
    //{
    //	Launcher.Default.OpenAsync("https://www.google.es/");
    //}


}