namespace TaskMaster;


public partial class Valgusfoor : ContentPage 
{
    BoxView redLight, yellowLight, greenLight;
    bool trafficLight = false;
    List<BoxView> lights = new List<BoxView>() { redLight, yellowLight, greenLight };
    public Valgusfoor(int k)
    {
        Title = "Valgusfoor";

        for (int i = 0; i < 3; i++) {
            redLight = new BoxView
            {
                Color = Colors.Red,
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
            };
            yellowLight = new BoxView
            {
                Color = Colors.Yellow,
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
            };
            greenLight = new BoxView
            {
                Color = Colors.Green,
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
            };
        };
        Content = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Spacing = 10,
            WidthRequest = 120,
            HeightRequest = 320,
            BackgroundColor = Colors.Black,
            Children = { redLight, yellowLight, greenLight },
        };

        Button on_btn = new Button
        {
            Text = "ON",
        };
        Button off_btn = new Button
        {
            Text = "Off",
        };
    }
}