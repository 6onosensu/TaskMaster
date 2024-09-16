﻿namespace TaskMaster;
public partial class TicTacToe : ContentPage
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
    bool isGame = false;
    bool isPlayerBot = false;

    Grid board;
    Label mainLbl, gameLbl, resultLbl, lbl;
    Button start_game_btn;
    RadioButton r_btn_players, r_btn_player_computer;


    string xMove = "Player X, your move:";
    string oMove = "Player O, your move:";

    List<int> playerX = new List<int>();
    List<int> playerO = new List<int>();
    string currentPlayer;
    string x = "X";
    string o = "O";
    Label[,] labels = new Label[3, 3];


    Button[,] buttons = new Button[3, 3];
    public TicTacToe(int k)
    {
        InitializeComponent();

        mainLbl = new Label
        {
            Text = "Tic-Tac-Toe",
            TextColor = Colors.Red,
            FontSize = 30,
        };
        gameLbl = new Label
        {
            Text = "Let's play!",
            TextColor = Colors.Black,
            FontSize = 24,
        };

        r_btn_players = new RadioButton
        {
            IsVisible = true,
            Content = "Player vs Player",
            Value = "players",
            IsChecked = true,
        };
        r_btn_player_computer = new RadioButton
        {
            Content = "Player vs Computer",
            Value = "computer",
            IsVisible = true,
        };

        start_game_btn = new Button
        {
            Text = "Start Game",
            TextColor = Colors.White,
            BackgroundColor = Colors.Red,
            FontSize = 26,
            FontAttributes = FontAttributes.Bold,
            CornerRadius = 3,
            WidthRequest = 100,
            HeightRequest = 40,
            IsVisible = true,
        };
        start_game_btn.Clicked += start_game_clicked;

        board = new Grid();
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

        board.IsVisible = false;

        Content = new StackLayout
        {
            Children =
            {
                mainLbl,
                gameLbl,
                r_btn_players,
                r_btn_player_computer,
                start_game_btn,
                board,
                resultLbl,
            }
        };
    }

    public void start_game_clicked(object? sender, EventArgs e)
    {
        isPlayerBot = r_btn_player_computer.IsChecked == true;
        currentPlayer = x;
        playerX.Clear();
        playerO.Clear();
        gameLbl.Text = xMove;
        gameOn();
    }

    public void gameOn() 
    { 
        isGame = true;
        r_btn_players.IsVisible = false;
        r_btn_player_computer.IsVisible = false;
        start_game_btn.IsVisible = false;
        board.IsVisible = true;
    }

    public void gameOff() 
    { 
        isGame = false;
        r_btn_players.IsVisible = true;
        r_btn_player_computer.IsVisible = true;
        start_game_btn.IsVisible = true;
        board.IsVisible = false;
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

            if (CheckWinner(playerX))
            {
                resultLbl.Text = "Player X wins!";
                resultLbl.IsVisible = true;
                gameOff();
                return;
            }
        }
        else
        {
            playerO.Add(zIndex);
            label.Text = o;
            label.BackgroundColor = Colors.LightPink;

            if (CheckWinner(playerO))
            {
                resultLbl.Text = "Player O wins!";
                resultLbl.IsVisible = true;
                gameOff();
                return;
            }
        }

        if (IsBoardFull())
        {
            resultLbl.Text = "It's a draw!";
            resultLbl.IsVisible = true;
            gameOff();
            return;
        }
    }
    public void MakeComputerMove()
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
                        resultLbl.Text = "Computer wins!";
                        resultLbl.IsVisible = true;
                        gameOff();
                        return;
                    }

                    if (IsBoardFull())
                    {
                        resultLbl.Text = "It's a draw!";
                        resultLbl.IsVisible = true;
                        gameOff();
                        return;
                    }

                    currentPlayer = x;
                    gameLbl.Text = "Player X, your move:";
                    break;
                }
            }
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
}