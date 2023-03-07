using System.ComponentModel.DataAnnotations;

namespace TicTacToeAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public char CurrentPlayer { get; set; }

        public char Winner { get; set; }

        [MaxLength(9)]
        public string Board { get; set; }

        public Game()
        {
            CurrentPlayer = 'X';
            Winner = '-';
            Board = "---------";
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == 'X')
                CurrentPlayer = 'O';
            else
                CurrentPlayer = 'X';
        }

        public void CheckWinner()
        {
            int[][] winPositions = new int[][]
            {
                new int[]{ 0, 1, 2 },
                new int[]{ 3, 4, 5 },
                new int[]{ 6, 7, 8 },
                new int[]{ 0, 3, 6 },
                new int[]{ 1, 4, 7 },
                new int[]{ 2, 5, 8 },
                new int[]{ 0, 4, 8 },
                new int[]{ 2, 4, 6 }
            };

            foreach (var winPosition in winPositions)
            {
                if (Board[winPosition[0]] == 'X' && Board[winPosition[1]] == 'X' && Board[winPosition[2]] == 'X')
                    Winner = 'X';
                else if (Board[winPosition[0]] == 'O' && Board[winPosition[1]] == 'O' && Board[winPosition[2]] == 'O')
                    Winner = 'O';
            }
        }
    }
}
