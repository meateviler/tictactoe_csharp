using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe_csharp
{
    public class Board
    {
        public const char EMPTY_CELL = '-';
        public Board(string s)
        {
            data = new StringBuilder(s);
        }

        public Board()
        {
            data = new StringBuilder();
        }

        public StringBuilder data
        {
            get;
            set;
        }

        public void SetPlayer(int position, char player)
        {
            data[position] = player;
        }

        public bool IsRowSamePlayer(int pos)
        {
            return data[pos] != EMPTY_CELL && data[pos] == data[pos+1] && data[pos+1] == data[pos+2];
        }
        public char GetPosPlayer(int pos)
        {
            return data[pos];
        }
        public bool IsEmpty(int pos)
        {
            return data[pos] == EMPTY_CELL;
        }
    }
}
