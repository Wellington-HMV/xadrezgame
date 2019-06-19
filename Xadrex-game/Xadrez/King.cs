using System;
using tabuleiro;

namespace Xadrez
{
    class King : Piece
    {
        public King(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "K";

        }
    }
}

