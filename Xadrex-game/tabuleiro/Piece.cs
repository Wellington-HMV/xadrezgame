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

        public Piece(Position position, Color color, Tabuleiro tab)
        {
            Position = position;
            Color = color;
            Tab = tab;
            QntMoves = 0;
        }
    }
}
