using System;
using tabuleiro;

namespace Xadrez
{
    class Bishop : Piece
    {
        public Bishop(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "B";

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

