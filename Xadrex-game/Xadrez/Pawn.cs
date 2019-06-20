using System;
using tabuleiro;

namespace Xadrez
{
    class Pawn : Piece
    {
        public Pawn(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "P";

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

