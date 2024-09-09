namespace TaskMaster
{
    public partial class ColorManagement : ContentPage
    {
        Label lbl;
        Frame frame;
        Slider redSlider, greenSlider, blueSlider;
        Stepper st_opacity, st_corner;
        AbsoluteLayout abs;
        public ColorManagement(int k)
        {
            lbl = new Label
            {
                Text = "Color Management",
                TextColor = Color.FromRgb(0, 0, 0),
            };

            frame = new Frame
            {
                BackgroundColor = Color.FromRgb(0, 0, 0),
                WidthRequest = 200,
                HeightRequest = 200,
                Opacity = 0,
                CornerRadius = 0,
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 123,
                MinimumTrackColor = Colors.Red,
                MaximumTrackColor = Colors.Gray,
                ThumbColor = Colors.Red,
            };
            redSlider.ValueChanged += OnValueChanger;

            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 123,
                MinimumTrackColor = Colors.Green,
                MaximumTrackColor = Colors.Gray,
                ThumbColor = Colors.Green,
            };
            greenSlider.ValueChanged += OnValueChanger;

            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 123,
                MinimumTrackColor = Colors.Blue,
                MaximumTrackColor = Colors.Gray,
                ThumbColor = Colors.Blue,
            };
            blueSlider.ValueChanged += OnValueChanger;

            st_opacity = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 5,
                Value = 50,
            };
            st_opacity.ValueChanged += OnValueChanger;

            st_corner = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 5,
                Value = 50,
            };st_corner.ValueChanged += OnValueChanger;

            abs = new AbsoluteLayout
            {
                Children = { lbl, frame, redSlider, greenSlider, blueSlider},
            };

        }

        void OnValueChanger(object sender, ValueChangedEventArgs e)
        {
            Convert.ToInt32(e.NewValue);

            switch (sender)
            {
                case "redSlider":
                    redSlider.MinimumTrackColor = Color.FromRgb((int)e.NewValue, 0, 0);
                    break;
                case "greenSlider":
                    greenSlider.MinimumTrackColor = Color.FromRgb(0, (int)e.NewValue, 0);
                    break;
                case "blueSlider":
                    blueSlider.MinimumTrackColor = Color.FromRgb(0, 0, (int)e.NewValue);
                    break;
                case "st_corner":
                    frame.CornerRadius = (int)e.NewValue;
                    break;
                case "st_opacity":
                    frame.Opacity = (int)e.NewValue;
                    break;
            }

            /*if (sender == redSlider)
            {
                redSlider.MinimumTrackColor = Color.FromRgb(redSlider.Value, 0, 0);
            }
            else if (sender == greenSlider)
            {
                greenSlider.MinimumTrackColor = Color.FromRgb( 0, greenSlider.Value, 0);
            }
            else if (sender == blueSlider) 
            {
                blueSlider.MinimumTrackColor = Color.FromRgb(0, 0, blueSlider.Value);
            }*/
            

            frame.BackgroundColor = Color.FromRgb((int)redSlider.Value,
                                                   (int)greenSlider.Value,
                                                   (int)blueSlider.Value);
        }

    }
}