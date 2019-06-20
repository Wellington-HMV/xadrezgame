using System;
using tabuleiro;
using System.Text;

namespace tabuleiro
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QntMoves { get;protected set; }
        public Tabuleiro Tab { get; set; }

        public Piece(Tabuleiro tab, Color color)
        {
            Position = null;
            Tab = tab;
            Color = color;
            QntMoves = 0;
        }
        public void IncrementQntMoves()
        {
            QntMoves++;
        }
        public bool PossiblesMovesExist()
        {
            bool[,] mat = MovesPossible();
            for(int i =0; i < Tab.Lines; i++)
            {
                for (int j = 0; j < Tab.Colums; j++)
                {
                if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMoveFor(Position pos)
        {
            return MovesPossible()[pos.Line, pos.Column];
        }
        public abstract bool[,] MovesPossible();
    }
}
