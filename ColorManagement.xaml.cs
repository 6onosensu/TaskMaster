using Microsoft.Maui.Layouts;
using System.Runtime.Intrinsics.Arm;

namespace TaskMaster
{
    public partial class ColorManagement : ContentPage
    {
        Label lbl;
        BoxView box;
        Slider redSlider, greenSlider, blueSlider;
        Stepper st_opacity, st_corner;
        Label opacityLbl, cornerLbl, opacityValueLbl, cornerValueLbl;
        AbsoluteLayout abs;
        public ColorManagement(int k)
        {
            lbl = new Label
            {
                Text = "Color Management",
                FontSize = 20,
                TextColor = Colors.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            box = new BoxView
            {
                Color = Color.FromRgba(0, 150, 150, 255),
                WidthRequest = 300,
                HeightRequest = 300,
                Opacity = 1.0,
                CornerRadius = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromRgba(0,0,0,0),
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 123,
                MinimumTrackColor = Colors.Red,
                MaximumTrackColor = Colors.Gray,
                ThumbColor = Colors.Red,
                HorizontalOptions = LayoutOptions.FillAndExpand,
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
                HorizontalOptions = LayoutOptions.FillAndExpand,
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
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            blueSlider.ValueChanged += OnValueChanger;

            opacityLbl = new Label
            {
                Text = "Opacity",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
            };

            opacityValueLbl = new Label
            {
                Text = "1.00",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
            };

            st_opacity = new Stepper
            {
                Minimum = 0,
                Maximum = 1,
                Increment = 0.1,
                Value = 1,
            };
            st_opacity.ValueChanged += OnValueChanger;

            cornerLbl = new Label
            {
                Text = "Corner Radius",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
            };

            cornerValueLbl = new Label
            {
                Text = "20",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
            };

            st_corner = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 5,
                Value = 20,
            };
            st_corner.ValueChanged += OnValueChanger;

            abs = new AbsoluteLayout
            {
                Children = 
                { 
                    lbl, box, redSlider, greenSlider, blueSlider,
                    opacityLbl, st_opacity, opacityValueLbl, 
                    cornerLbl, st_corner, cornerValueLbl 
                },
            };

            AbsoluteLayout.SetLayoutBounds(box, new Rect(10, 70, 380, 300));
            AbsoluteLayout.SetLayoutBounds(lbl, new Rect(0.5, 0.25, 300, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(redSlider, new Rect(10, 380, 380, 30));
            AbsoluteLayout.SetLayoutBounds(greenSlider, new Rect(10, 420, 380, 30));
            AbsoluteLayout.SetLayoutBounds(blueSlider, new Rect(10, 460, 380, 30));

            AbsoluteLayout.SetLayoutBounds(opacityLbl, new Rect(10, 500, 200, 30));
            AbsoluteLayout.SetLayoutBounds(st_opacity, new Rect(220, 500, 150, 50));
            AbsoluteLayout.SetLayoutBounds(opacityValueLbl, new Rect(10, 530, 200, 30));

            AbsoluteLayout.SetLayoutBounds(cornerLbl, new Rect(10, 560, 200, 30));
            AbsoluteLayout.SetLayoutBounds(st_corner, new Rect(220, 560, 150, 50));
            AbsoluteLayout.SetLayoutBounds(cornerValueLbl, new Rect(10, 590, 200, 30));

            Content = abs;

            UpdateLabelColor();
        }

        void OnValueChanger(object sender, ValueChangedEventArgs e)
        {
            Convert.ToInt32(e.NewValue);

            if (sender == redSlider || sender == greenSlider || sender == blueSlider)
            {
                box.Color = Color.FromRgb(
                                        (int)redSlider.Value,
                                        (int)greenSlider.Value,
                                        (int)blueSlider.Value);
                UpdateLabelColor();
            }
            else if (sender == st_opacity)
            {
                box.Opacity = e.NewValue;
                opacityValueLbl.Text = e.NewValue.ToString("F2");
            }
            else if (sender == st_corner)
            {
                box.CornerRadius = (float)e.NewValue;
                cornerValueLbl.Text = e.NewValue.ToString();
            }
        }

        void UpdateLabelColor()
        {
            Color boxColor = box.Color;

            double red = boxColor.Red;
            double green = boxColor.Green;
            double blue = boxColor.Blue;

            double luminance = (0.299 * red) + (0.587 * green) + (0.114 * blue);

            if (luminance > 0.5)
            {
                lbl.TextColor = Colors.Black;
            }
            else
            {
                lbl.TextColor = Colors.AntiqueWhite;
            }

        }
    }
}