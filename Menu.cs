using Microsoft.Maui.Controls;

namespace TaskMaster;

internal class Menu : ContentPage
{
    List<ContentPage> pages = new List<ContentPage>() { new MainPage(), new Valgusfoor(0) };
    List<string> txt = new List<string> { "Home", "Valgusfoor" };
    public Menu() 
    {
        for (int i = 0; i < pages.Count; i++)
        {
            Button btn = new Button
            {
                Text = txt[i],
                BackgroundColor = Color.FromRgb(20, 100, 200),
                TextColor = Color.FromRgb(10, 20, 15),
                FontFamily = "Hey Comic",
                BorderWidth = 10,
                ZIndex = i
            };
            btn.Clicked += Btn_Clicked;
            Content = new StackLayout
            {
                Padding = 20,
                Children = { btn }
            };
        }


    }
    private async void Btn_Clicked(object? sender, EventArgs e)
    {
        Button button = (Button)sender;
        await Navigation.PushAsync(pages[button.ZIndex]);
    }
}


