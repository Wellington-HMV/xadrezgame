using System;
using tabuleiro;

namespace Xadrez
{
    class Pawn : Piece
    {
        private ChessGame Play;
        public Pawn(Tabuleiro tab, Color color,ChessGame play) : base(tab, color) {
            Play = play;
        }
        public override string ToString()
        {
            return "P";

        }
        private bool ExistEnemy(Position pos)
        {
            Piece p = Tab.piece(pos);
            return p != null && p.Color != Color;
        }
        private bool Spare(Position pos)
        {
            return Tab.piece(pos) == null;
        }
        public override bool[,] MovesPossible()
        {
            bool[,] mat = new bool[Tab.Lines, Tab.Colums];
            Position pos = new Position(0, 0);
            //white color
            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Tab.ValidPosition(pos) && Spare(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos) && QntMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //#jogada especial enpassant
                if(Position.Line == 3)
                {
                    Position lefth = new Position(Position.Line, Position.Column - 1);
                    if (Tab.ValidPosition(lefth) && ExistEnemy(lefth) && Tab.piece(lefth) == Play.VulnerableEnPassant){
                        mat[lefth.Line, lefth.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Tab.ValidPosition(rigth) && ExistEnemy(rigth) && Tab.piece(rigth) == Play.VulnerableEnPassant)
                    {
                        mat[rigth.Line, rigth.Column] = true;
                    }
                }
            }
            //black color
            if (Color == Color.Black)
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Tab.ValidPosition(pos) && Spare(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos) && QntMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                //#jogada especial enpassant
                if (Position.Line == 4)
                {
                    Position lefth = new Position(Position.Line, Position.Column - 1);
                    if (Tab.ValidPosition(lefth) && ExistEnemy(lefth) && Tab.piece(lefth) == Play.VulnerableEnPassant)
                    {
                        mat[lefth.Line, lefth.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Tab.ValidPosition(rigth) && ExistEnemy(rigth) && Tab.piece(rigth) == Play.VulnerableEnPassant)
                    {
                        mat[rigth.Line, rigth.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}

