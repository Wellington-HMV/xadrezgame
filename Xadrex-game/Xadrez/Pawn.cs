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
    }
}

