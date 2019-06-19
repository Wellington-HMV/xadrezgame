using System;
using tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Lines { get; set; }
        public int Colums { get; set; }
        private Piece[,] Pieces;

        public Tabuleiro(int lines, int colums)
        {
            Lines = lines;
            Colums = colums;
            Pieces = new Piece[Lines, Colums];
        }
        public Piece Piece(int lines,int colums)
        {
            return Pieces[lines, colums];
        }
        public void InsertPiece(Piece p,Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
    }
}
