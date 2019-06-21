using System;
using tabuleiro;

namespace Xadrez
{
    class King : Piece
    {
        private ChessGame Play;
        public King(Tabuleiro tab, Color color, ChessGame play) : base(tab, color)
        {
            Play = play;
        }
        public override string ToString()
        {
            return "K";
        }
        private bool CanMove(Position pos)
        {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != this.Color;
        }
        private bool TowerTestForRoque(Position pos)
        {
            Piece p = Tab.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QntMoves == 0;
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
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //rigth
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //se
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
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
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //lefth
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //so
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //#jogada especial
            if (QntMoves == 0 && !Play.Xeque)
            {
                //#jogada especial roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (TowerTestForRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Tab.piece(p1)==null && Tab.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                //#jogada especial roque grande
                Position posT2 = new Position(Position.Line, Position.Column -4);
                if (TowerTestForRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Tab.piece(p1) == null && Tab.piece(p2) == null&& Tab.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}

