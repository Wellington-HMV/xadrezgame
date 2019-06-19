﻿using System;
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
    }
}
