using System.Text;

namespace tictactoe_csharp
{
    public class Game
    {
        private const int NO_WINNER_MOVE = -1;
        private const int CANNOT_MOVE = -1;
        private Board board;

        public Game(string s)
        {
            board = new Board(s);
        }
        public Game(StringBuilder s, int position, char player)
        {
            board = new Board(s.ToString());
            board.SetPlayer(position, player);
        }

        public int Move(char player)
        {
            int pos = CANNOT_MOVE;
            if (HasWinningMove(player, out pos))
            {
                return pos;
            }
            return FindDefaultMove();
        }

        public Game Play(int pos, char player)
        {
            return new Game(board.data, pos, player);
        }

        public char Winner()
        {
            foreach (var pos in new int[] { 0, 3, 6 })
            {
                if (IsRowSamePlayer(pos))
                    return board.GetPosPlayer(pos);
            }
            return Board.EMPTY_CELL;
        }
        private bool IsEmpty(int pos)
        {
            return board.IsEmpty(pos);
        }
        private bool IsRowSamePlayer(int pos)
        {
            return board.IsRowSamePlayer(pos);
        }

        private bool HasWinningMove(char player, out int pos)
        {
            pos = FindWinnerMove(player);
            if (pos != NO_WINNER_MOVE)
            {
                return true;
            }
            return false;
        }
        private int FindWinnerMove(char player)
        {
            for (int i = 0; i < 9; i++)
            {
                if (IsEmpty(i))
                {
                    var game = Play(i, player);
                    if (game.Winner() == player)
                    {
                        return i;
                    }
                }
            }
            return NO_WINNER_MOVE;
        }
        private int FindDefaultMove()
        {
            for (int i = 0; i < 9; i++)
            {
                if (IsEmpty(i))
                {
                    return i;
                }
            }
            return CANNOT_MOVE;
        }
    }
}
