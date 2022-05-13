using Microsoft.Maui.Controls.StyleSheets;

namespace Stylesheets;

public partial class StyledPage : ContentPage
{
    public StyledPage()
    {
        InitializeComponent();
    }

    public StyledPage(string id)
    {
        InitializeComponent();

        var filename = $"sheet{id}.css";
        var img = id == "1" ? "zx81" : id == "2" ? "spectrum" : "ql";

        Task.Run(async () =>
        {
            var sheet = await LoadMauiAsset(filename);
            using (var reader = new StringReader(sheet))
            {
                Resources.Add(StyleSheet.FromReader(reader));
            }
        });

        imgPic.Source = img;
    }

    async Task<string> LoadMauiAsset(string filename)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filename);
        using var reader = new StreamReader(stream);

        var contents = reader.ReadToEnd();
        return contents;
    }
}