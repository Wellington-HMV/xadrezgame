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
        public override bool[,] MovesPossible()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colums];
            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMoveFor(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}

