namespace TaskMaster
{
    public partial class TicTacToe : ContentPage
    {
        Random rand = new Random();

        bool isGame = false;
        bool isPlayerBot = false;

        Grid board;
        Label mainLbl, gameLbl;
        Button letsPlay;

        List<int> playerX = new List<int>();
        List<int> playerO = new List<int>();

        string xMove = "Player X, your move:";
        string oMove = "Player O, your move:";
        string currentPlayer;
        string x = "X";
        string o = "O";

        public TicTacToe(int k)
        {

            mainLbl = new Label
            {
                Text = "Tic-Tac-Toe",
                TextColor = Colors.Black,
                FontSize = 24,
            };

            gameLbl = new Label
            {
                Text = "Who is first?",
                TextColor = Colors.Black,
                FontSize = 20,
                IsVisible = false,
            };

            letsPlay = new Button
            {
                Text = "Let's Play!",
                TextColor = Colors.White,
                BackgroundColor = Colors.Black,
                FontSize = 20,
                CornerRadius = 3,
                WidthRequest = 100,
                HeightRequest = 40,
                IsVisible = true,
            };
            letsPlay.Clicked += LetsPlay_Clicked;

            board = new Grid();
            for (int i = 0; i < 3; i++)
            {
                board.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                board.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            board.IsVisible = false;

        }

        private async void LetsPlay_Clicked(object? sender, EventArgs e)
        {
            gameOn();
        }

        public void updateGameLabel()
        {
            //gameLbl.Text = 
        }

        public void gameOn() 
        { 
            isGame = true; 
            letsPlay.IsVisible = false;
            gameLbl.IsVisible = true;
            board.IsVisible = true;
        }

        public void gameOff() 
        { 
            isGame = false;
            letsPlay.IsVisible = true;
            gameLbl.IsVisible = false;
            board.IsVisible = false;
        }
    }
}