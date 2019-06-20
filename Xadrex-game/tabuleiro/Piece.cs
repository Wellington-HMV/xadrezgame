using System;
using tabuleiro;
using System.Text;

namespace tabuleiro
{
    class Piece
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
            QntMoves ++;
        }
    }
}
