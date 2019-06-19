﻿using System;
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
        public Piece piece(Position pos)
        {
            return Pieces[pos.Column, pos.Line];
        }
        public Piece Piece(int lines, int colums)
        {
            return Pieces[lines, colums];
        }
        public bool PieceExist(Position pos)
        {
            ValidPositionException(pos);
            return piece(pos) != null;
        }
        public void InsertPiece(Piece p, Position pos)
        {
            if (PieceExist(pos))
            {
                throw new TabuleiroException("There is already a piece in this position");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Colums)
            {
                return false;
            }
            return true;
        }
        public void ValidPositionException(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new TabuleiroException("Invalid Position!");
            }
        }
    }
}
