using System;
using tabuleiro;

namespace Xadrez
{
    class Horse : Piece
    {
        public Horse(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "H";

        }
    }
}

