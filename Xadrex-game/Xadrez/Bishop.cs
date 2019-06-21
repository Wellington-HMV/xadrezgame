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
        public override bool[,] MovesPossible()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colums];
            Position pos = new Position(0, 0);
            //up
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }
            //dawn
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            return mat;
        }
    }
}

