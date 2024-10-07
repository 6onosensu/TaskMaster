namespace TaskMaster;

public partial class CarouselPage : ContentPage
{
	public CarouselPage(int k)
	{
		IndicatorView indicatorView = new IndicatorView
		{
			SelectedIndicatorColor = Color.FromRgba(20, 150, 250, 100),
			HorizontalOptions = LayoutOptions.Center,
			IndicatorColor = Colors.Transparent,
			Margin = new Thickness(10),
			//IndicatorsShape = IndicatorShape.Square,
			//IndicatorSize = 20
			IndicatorTemplate = new DataTemplate(() =>
			{
				Label label = new Label
				{
					Text = "\uf30c",
					FontSize = 30,
					TextColor = Colors.Blue,
				};
				return label;
			})
		};

		CarouselView carouselView = new CarouselView
		{
			VerticalOptions = LayoutOptions.Center,
			ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal),
			IndicatorView = indicatorView,
		};

		carouselView.ItemsSource = new List<Item>
		{
			new Item {Name = "Item1", Description = "Description1", Quantity = 1, Image = "dotnet_bot.svg"},
            new Item {Name = "Item2", Description = "Description2", Quantity = 2, Image = "dotnet_bot.svg"},
            new Item {Name = "Item3", Description = "Description3", Quantity = 3, Image = "dotnet_bot.svg"},
            new Item {Name = "Item4", Description = "Description4", Quantity = 4, Image = "dotnet_bot.svg"},
        };

		carouselView.ItemTemplate = new DataTemplate(() =>
		{
			Label header = new Label
			{
				FontAttributes = FontAttributes.Bold,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = 22,
			};
			header.SetBinding(Label.TextProperty, "Name");
			Image img = new Image
			{
				WidthRequest = 150,
				HeightRequest = 150,
			};
			img.SetBinding(Image.SourceProperty, "Image");
			Label descriptionItem = new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
			};
			descriptionItem.SetBinding(Label.TextProperty, "Description");
			Slider quant = new Slider
			{
				Minimum = 0,
				Maximum = 100,
			};
			quant.SetBinding(Slider.ValueProperty, "Quantity");
			VerticalStackLayout vsl = new VerticalStackLayout() { header, img, descriptionItem, quant };

			Frame frame = new Frame
			{
				WidthRequest = 250,
				HeightRequest = 300,
			};
			frame.Content = vsl;
			return frame;
		});

		Content = new VerticalStackLayout() { carouselView, indicatorView };
	}
}