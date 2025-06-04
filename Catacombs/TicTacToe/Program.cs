
namespace TicTacToe; 
class Program {
    static void Main(string[] args) {
        Console.Title = "Tic-Tac-Toe";
        Game game = new Game();
        game.Start();
    }
}

class Game {
    private Board board;
    private Player playerX;
    private Player playerO;
    private Player currentPlayer;

    public Game() {
        board = new Board();
        playerX = new Player('X');
        playerO = new Player('O');
        currentPlayer = playerX;
    }

    public void Start() {
        while (!CheckGameOver()) {
            board.Display();
            currentPlayer.MakeMove(board);
            Console.Clear();
            SwitchPlayer();
        }
    }

    private void SwitchPlayer() {
        if (currentPlayer == playerX) {
            currentPlayer = playerO;
        } else {
            currentPlayer = playerX;
        }
    }

    private bool CheckGameOver() {
        if (board.CheckWin('X') || board.CheckWin('O')) {
            board.Display();
            if (currentPlayer == playerX) {
                Console.WriteLine("Player O wins!");
            } else {
                Console.WriteLine("Player X wins!");
            }
            return true;
        } else {
            if (board.IsFull()) {
                board.Display();
                Console.WriteLine("It's a draw!");
                return true;
            }
        }
        return false;
    }
}

class Board {
    private char[,] grid;

    public Board() {
        grid = new char[3, 3];

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                grid[row, col] = ' ';


    }

    public void Display() {
        for (int row = 0; row < 3; row++) {
            for (int col = 0; col < 3; col++) {
                Console.Write(" " + grid[row, col]);
                if (col < 2)
                    Console.Write(" |");
            }
            Console.WriteLine();
            if (row < 2)
                Console.WriteLine("---+---+---");
        }
    }

    public bool PlaceMark(int row, int col, char mark) {
        if (row >= 0 && row < 3 && col >= 0 && col < 3 && grid[row, col] == ' ') {
            grid[row, col] = mark;
            return true;
        }
        return false;
    }

    public bool CheckWin(char mark) {
        if (grid[0, 0] == mark && grid[0, 1] == mark && grid[0, 2] == mark)
            return true;
        if (grid[1, 0] == mark && grid[1, 1] == mark && grid[1, 2] == mark)
            return true;
        if (grid[2, 0] == mark && grid[2, 1] == mark && grid[2, 2] == mark)
            return true;

        if (grid[0, 0] == mark && grid[1, 0] == mark && grid[2, 0] == mark)
            return true;
        if (grid[0, 1] == mark && grid[1, 1] == mark && grid[2, 1] == mark)
            return true;
        if (grid[0, 2] == mark && grid[1, 2] == mark && grid[2, 2] == mark)
            return true;

        if (grid[0, 0] == mark && grid[1, 1] == mark && grid[2, 2] == mark)
            return true;
        if (grid[2, 0] == mark && grid[1, 1] == mark && grid[0, 2] == mark)
            return true;

        return false;
    }

    public bool IsFull() { 
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++ )
                if (grid[row, col] == ' ')
                    return false;
        return true;
    }
}

class Player {
    private char mark;

    public Player(char mark) {
        this.mark = mark;
    }

    public void MakeMove(Board board) {

        while (true) {
            Console.WriteLine($"Player {mark}, pick a square (use numpad):");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();

            Console.WriteLine($"You pressed: {key}"); // Debug output

            bool validMove = key switch {
                ConsoleKey.D7 => board.PlaceMark(0, 0, mark),
                ConsoleKey.D8 => board.PlaceMark(0, 1, mark),
                ConsoleKey.D9 => board.PlaceMark(0, 2, mark),
                ConsoleKey.D4 => board.PlaceMark(1, 0, mark),
                ConsoleKey.D5 => board.PlaceMark(1, 1, mark),
                ConsoleKey.D6 => board.PlaceMark(1, 2, mark),
                ConsoleKey.D1 => board.PlaceMark(2, 0, mark),
                ConsoleKey.D2 => board.PlaceMark(2, 1, mark),
                ConsoleKey.D3 => board.PlaceMark(2, 2, mark),
                _ => false
            };

            if (validMove) {
                break; // Exit the loop if the move is valid
            } else {
                Console.WriteLine("Invalid move! Square is already taken or out of bounds. Try again.");
            }
        }
    }
}

