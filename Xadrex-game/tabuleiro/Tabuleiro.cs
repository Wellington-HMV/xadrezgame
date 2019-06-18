using System;
using tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Lines { get; set; }
        public int Colums { get; set; }
        private Piece[,] pieces;

        public Tabuleiro(int lines, int colums)
        {
            Lines = lines;
            Colums = colums;
            pieces = new Piece[Lines, Colums];
        }
    }
}
