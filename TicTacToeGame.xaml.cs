using System.Xml.Serialization;

namespace TaskMaster;
public partial class TicTacToeGame : ContentPage
{
    public readonly int[][] combinations = new int[][]
    {
        new int[] { 0, 1, 2 }, // top row
        new int[] { 3, 4, 5 }, // middle row
        new int[] { 6, 7, 8 }, // bottom row
        new int[] { 0, 3, 6 }, // left column
        new int[] { 1, 4, 7 }, // middle column
        new int[] { 2, 5, 8 }, // right column
        new int[] { 0, 4, 8 }, // top-left to bottom-right
        new int[] { 2, 4, 6 }  // top-right to bottom-left
    };

    Grid board;
    Label lbl, gameLbl, mainLbl;
    Button start_game_btn;
    RadioButton r_btn_players, r_btn_computer;

    List<int> playerX = new List<int>();
    List<int> playerO = new List<int>();
    bool isGame = false;
    string x = "X";
    string o = "O";
    string currentPlayer;
    string lblNextPlayer = "";

    Label[,] labels = new Label[3, 3];
    public TicTacToeGame(int k)
    {
        mainLbl = new Label
        {
            Padding = 3,
            Text = "Tic-Tac-Toe",
            TextColor = Colors.Blue,
            FontSize = 30,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
        };
        gameLbl = new Label
        {
            Padding = 3,
            Text = "Let's play!",
            TextColor = Colors.Black,
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        r_btn_players = new RadioButton
        {
            IsVisible = true,
            Content = "Player vs Player",
            Value = "players",
            IsChecked = true,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        r_btn_computer = new RadioButton
        {
            Content = "Player vs Computer",
            Value = "computer",
            IsVisible = true,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };

        start_game_btn = new Button
        {
            Text = "Start Game",
            TextColor = Colors.White,
            BackgroundColor = Colors.Blue,
            FontSize = 26,
            FontAttributes = FontAttributes.Bold,
            CornerRadius = 3,
            WidthRequest = 140,
            HeightRequest = 70,
            IsVisible = true,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End
        };
        start_game_btn.Clicked += start_game_clicked;

        Content = new StackLayout
        {
            Children =
            {
                mainLbl,
                gameLbl,
                r_btn_players,
                r_btn_computer,
                start_game_btn,
            }
        };
    }
    void UpdateNextPlayerLbl()
    {
        lblNextPlayer = $"Player {currentPlayer}, your move:";
    }

    void DrawBoard()
    {
        board = new Grid
        {
            BackgroundColor = Colors.LightGray,
            Padding = 3,
            
        };
        for (int i = 0; i < 3; i++)
        {
            board.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            board.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                lbl = new Label
                {
                    Text = "",
                    FontSize = 40,
                    BackgroundColor = Colors.LightGray,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };

                var tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += OnGridTapped;
                lbl.GestureRecognizers.Add(tapGesture);

                board.Add(lbl, col, row);
                labels[row, col] = lbl;
            }
        }

        Content = new StackLayout
        {
            Children =
            {
                board,
            }
        };
    }


    public void start_game_clicked(object? sender, EventArgs e)
    {
        currentPlayer = x;
        UpdateNextPlayerLbl();
        playerX.Clear();
        playerO.Clear();
        DrawBoard();
        gameLbl.Text = lblNextPlayer;
        gameOn();
    }

    public void gameOn()
    {
        isGame = true;
        r_btn_players.IsVisible = false;
        r_btn_computer.IsVisible = false;
        start_game_btn.IsVisible = false;
    }

    public void gameOff()
    {
        isGame = false;
        r_btn_players.IsVisible = true;
        r_btn_computer.IsVisible = true;
        start_game_btn.IsVisible = true;
    }
    public void OnGridTapped(object sender, EventArgs e)
    {
        Label label = sender as Label;
        if (label == null)
        {
            return;
        }
        int zIndex = label.ZIndex;

        if (currentPlayer == x)
        {
            playerX.Add(zIndex);
            label.Text = x;
            label.BackgroundColor = Colors.LightBlue;
            currentPlayer = o;

            if (CheckWinner(playerX))
            {
                TheWinner(x);
            }
        }
        else
        {
            playerO.Add(zIndex);
            label.Text = o;
            label.BackgroundColor = Colors.LightPink;
            currentPlayer = x;

            if (CheckWinner(playerO))
            {
                TheWinner(o);
            }
        }

        if (IsBoardFull())
        {
            ItIsDraw();
        }
    }
    public bool CheckWinner(List<int> playerMoves)
    {
        foreach (var comb in combinations)
        {
            if (playerMoves.Contains(comb[0]) && playerMoves.Contains(comb[1]) && playerMoves.Contains(comb[2]))
            {
                return true;
            }
        }
        return false;
    }
    public bool IsBoardFull()
    {
        return playerX.Count + playerO.Count == 9;
    }
    private async void ItIsDraw()
    {
        await DisplayAlert("It is a draw!", "Try again.", "OK");
        gameOff();
    }

    private void TheWinner(string player)
    {
        DisplayAlert($"Congratulations, {player}!", "You win!!!", "OK");
        gameOff();
    }
}

/*public void MakeComputerMove()
{
    var availablePositions = Enumerable.Range(0, 9).Except(playerX).Except(playerO).ToList();
    if (availablePositions.Count > 0)
    {
        int position = availablePositions.First();
        foreach (var label in labels)
        {
            if (label.ZIndex == position)
            {
                playerO.Add(position);
                label.Text = o;
                label.BackgroundColor = Colors.LightPink;

                if (CheckWinner(playerO))
                {
                    TheWinner(o);
                }

                if (IsBoardFull())
                {
                    ItIsDraw();
                }

                currentPlayer = x;
                gameLbl.Text = lblNextPlayer;
                break;
            }
        }
    }
}*/