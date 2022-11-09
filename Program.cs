


Console.WriteLine(" Welcome to Tic Tac Toe");
Console.WriteLine(" The game is two player with player 1 being X and Player 2 being O");
Console.WriteLine("The tile locations are based on the numpad");
Console.WriteLine($" 7 | 8 | 9 ");
Console.WriteLine("---+---+---");
Console.WriteLine($" 4 | 5 | 6 ");
Console.WriteLine("---+---+---");
Console.WriteLine($" 1 | 2 | 3 ");

Console.WriteLine("\nSelect numbers from the example above for a tile \n");

Console.WriteLine("Press any key to continue: ");
Console.ReadKey();

Console.Clear();

TicTacToeGame game = new();

game.Start();


public class TicTacToeGame
{
    Board board = new Board ();
    Player player1 = new(Token.X);
    Player player2 = new(Token.O);
    int round = 1;


    public void Start()
    {
        Player currentPlayer = player1;
        ShowBoard();
        while (round < 10)
        {
            
            if (WinCheck(Token.X) == true )
            {
                Console.WriteLine($" {Token.X} has won!");
                return;
            }

            if (WinCheck(Token.O) == true)
            {
                Console.WriteLine($" {Token.O} has won!");
                return;
            }

            PickTile (currentPlayer);

            ShowBoard();

           

            currentPlayer = currentPlayer ==  player1? player2 : player1;
            round++;
        }
        Console.WriteLine("\nThe game has ended in a draw!");
        ShowBoard();
    }

    public Token PickTile(Player currentPlayer)
    {
        while(true)
        {
            Console.Write($"Player {currentPlayer.Symbol} what tile do you want to play in? ");
            int choice = int.Parse(Console.ReadLine());
            bool validChoice = ValidChoice(choice);
            if (validChoice == true)
            {
                return choice switch
                {
                    7 => board.SetCellAt(0, 0, currentPlayer.Symbol),
                    8 => board.SetCellAt(0, 1, currentPlayer.Symbol),
                    9 => board.SetCellAt(0, 2, currentPlayer.Symbol),
                    4 => board.SetCellAt(1, 0, currentPlayer.Symbol),
                    5 => board.SetCellAt(1, 1, currentPlayer.Symbol),
                    6 => board.SetCellAt(1, 2, currentPlayer.Symbol),
                    1 => board.SetCellAt(2, 0, currentPlayer.Symbol),
                    2 => board.SetCellAt(2, 1, currentPlayer.Symbol),
                    3 => board.SetCellAt(2, 2, currentPlayer.Symbol),
                };
            }
            else
            {
                Console.WriteLine("Tile placement was invalid please try again");
            }
            

        }
    }

    public bool WinCheck(Token value)
    {
        //top row win check 
        if (board.GetCellAt(0, 0) == value && board.GetCellAt(0, 1) == value && board.GetCellAt(0, 2) == value) return true; // row top
        if (board.GetCellAt(1, 0) == value && board.GetCellAt(1, 1) ==  value && board.GetCellAt(1, 2) == value) return true; // row middle
        if (board.GetCellAt(2, 0) == value && (board.GetCellAt(2, 1) ==  value && (board.GetCellAt(2, 2) == value))) return true; // row bottom 
        //diagnal win check
        if (board.GetCellAt(0, 0) == value && board.GetCellAt(1, 1) == value && board.GetCellAt(2, 2) == value) return true; // diagnal right
        if (board.GetCellAt(0, 2) == value && board.GetCellAt(1, 1) == value && board.GetCellAt(2, 0) == value) return true; // diagnal right
        // column win check
        if (board.GetCellAt(0, 0) == value && board.GetCellAt(1, 0) == value && board.GetCellAt(2, 0) == value) return true; // left column
        if (board.GetCellAt(0, 1) == value && board.GetCellAt(1, 1) == value && board.GetCellAt(2, 1) == value) return true; // middle column
        if (board.GetCellAt(0, 2) == value && board.GetCellAt(1, 2) == value && board.GetCellAt(2, 2) == value) return true; // right column

        return false;

    }

    public bool ValidChoice(int choice)
    {
        if (choice == 7 && board.GetCellAt(0, 0) == Token.Empty) return true;
        if (choice == 8 && board.GetCellAt(0, 1) == Token.Empty) return true;
        if (choice == 9 && board.GetCellAt(0, 2) == Token.Empty) return true;
        if (choice == 4 && board.GetCellAt(1, 0) == Token.Empty) return true;
        if (choice == 5 && board.GetCellAt(1, 1) == Token.Empty) return true;
        if (choice == 6 && board.GetCellAt(1, 2) == Token.Empty) return true;
        if (choice == 1 && board.GetCellAt(2, 0) == Token.Empty) return true;
        if (choice == 2 && board.GetCellAt(2, 1) == Token.Empty) return true;
        if (choice == 3 && board.GetCellAt(2, 2) == Token.Empty) return true;
        else
        {
            return false;
        }

    }

        public void ShowBoard()
        {
            Console.WriteLine($" {SwitchCharacter(board.GetCellAt(0, 0))} | {SwitchCharacter(board.GetCellAt(0, 1))} | {SwitchCharacter(board.GetCellAt(0, 2))}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {SwitchCharacter(board.GetCellAt(1, 0))} | {SwitchCharacter(board.GetCellAt(1, 1))} | {SwitchCharacter(board.GetCellAt(1, 2))}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {SwitchCharacter(board.GetCellAt(2, 0))} | {SwitchCharacter(board.GetCellAt(2, 1))} | {SwitchCharacter(board.GetCellAt(2, 2))}");
        }
        private char SwitchCharacter(Token cell) => cell switch { Token.X => 'X', Token.O => 'O', Token.Empty => ' ' };
}


public class Board
    {
        private  Token[,] Cells = new Token[3, 3];
        public Token GetCellAt(int row, int column) => Cells[row, column];

        public Token SetCellAt(int row, int column, Token newValue) => Cells[row, column] = newValue;
    }

public class Player
{
    public Token Symbol { get; }
    public Player (Token symbol)
    {
        Symbol = symbol;
    }
}

public enum Token { Empty, X, O}