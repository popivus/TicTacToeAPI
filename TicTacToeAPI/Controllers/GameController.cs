using Microsoft.AspNetCore.Mvc;
using TicTacToeAPI.Context;
using TicTacToeAPI.Models;
using System.Linq;

namespace TicTacToeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly TicTacToeContext _context;

        public GameController(TicTacToeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Game>> StartGame()
        {
            Game newGame = new Game();
            _context.Game.Add(newGame);
            await _context.SaveChangesAsync();

            return newGame;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Game>> MakeMove(Move move, int id)
        {
            var currentGame = await _context.Game.FindAsync(id);

            if (currentGame == null)
                return NotFound();

            if (currentGame.Winner == 'X' || currentGame.Winner == 'O')
                return currentGame;

            if (currentGame.Board[move.CellNumber] != '-')
                return currentGame;

            char[] board = currentGame.Board.ToCharArray();
            board[move.CellNumber] = currentGame.CurrentPlayer;
            currentGame.Board = new string(board);

            currentGame.ChangePlayer();
            currentGame.CheckWinner();

            _context.Game.Update(currentGame);
            await _context.SaveChangesAsync();

            return currentGame;
        }
    }
}