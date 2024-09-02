namespace TaskMaster;
public partial class Valgusfoor : ContentPage 
{
    bool trafficLight = false;
    List<BoxView> lights;
    public Valgusfoor(int k)
    {
        Title = "Valgusfoor";
        lights = new List<BoxView>(3);
        for (int i = 0; i < 3; i++) {
            lights.Add(new BoxView
            {
                Color = Colors.Gray,
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
            });
        };

        BoxView redLight = lights[0];
        BoxView yellowLight = lights[1];
        BoxView greenLight = lights[2];

        StackLayout lightStack = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Spacing = 10,
            WidthRequest = 120,
            HeightRequest = 320,
            BackgroundColor = Colors.Black,
            Children = { redLight, yellowLight, greenLight },
        };

        if (trafficLight == true) 
        { 

        };

        Button on_btn = new Button
        {
            Text = "ON",
        };
        on_btn.Clicked += on_btn_clicked;

        Button off_btn = new Button
        {
            Text = "OFF",
        };

        off_btn.Clicked += Off_btn_Clicked;
    }

    private void Off_btn_Clicked(object? sender, EventArgs e)
    {
        trafficLight = false;
    }

    private async void on_btn_clicked(object? sender, EventArgs e)
    {
        trafficLight = true;
    }
}