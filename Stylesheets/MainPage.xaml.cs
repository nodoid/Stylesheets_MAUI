namespace Stylesheets;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    [Obsolete]
    void Handle_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        
        Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new StyledPage(btn.ClassId)));
    }
}
