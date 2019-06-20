using System;
using tabuleiro;
using Xadrez;

namespace Xadrez
{
    class Tower : Piece
    {
        public Tower(Tabuleiro tab, Color color) : base(tab, color) { }
        public override string ToString()
        {
            return "T";

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
            while(Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Tab.piece(pos)!= null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }
            //dawn
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column+1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column +=1;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
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

