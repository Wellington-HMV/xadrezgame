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
        private bool CanMove(Position pos)
        {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] MovesPossible()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colums];
            Position pos = new Position(0, 0);
            //up
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //ne
            pos.DefineValues(Position.Line - 1, Position.Column+1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column+1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //se
            pos.DefineValues(Position.Line + 1, Position.Column+1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //dawn
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //so
            pos.DefineValues(Position.Line + 1, Position.Column-1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //lefth
            pos.DefineValues(Position.Line, Position.Column-1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //so
            pos.DefineValues(Position.Line - 1, Position.Column-1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}

