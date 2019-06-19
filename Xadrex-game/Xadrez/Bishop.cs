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
    }
}

