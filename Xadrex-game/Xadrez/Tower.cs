using System;
using tabuleiro;

namespace Xadrez
{
    class Tower : Piece
    {
        public Tower(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "T";

        }
    }
}

