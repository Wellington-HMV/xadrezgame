using System;
using tabuleiro;

namespace Xadrez
{
    class Lady : Piece
    {
        public Lady(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "L";

        }
        public override bool[,] MovesPossible()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colums];
            Position pos = new Position(0, 0);
            //up

            return mat;
        }
    }
}

