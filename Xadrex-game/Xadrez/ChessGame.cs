using System.Collections.Generic;
using tabuleiro;
using Xadrez;

namespace Xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public bool Finish { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerActual { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public ChessGame()
        {
            tab = new Tabuleiro(8, 8);
            Turn = 1;
            PlayerActual = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InsertPieces();
            Finish = false;
        }
        public void ExecuteMov(Position origin, Position destin)
        {
            Piece p = tab.RemovePiece(origin);
            p.IncrementQntMoves();
            Piece capturedPiece = tab.RemovePiece(destin);
            tab.InsertPiece(p, destin);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
        }
        public void RealizePlayed(Position origin, Position destin)
        {
            ExecuteMov(origin, destin);
            Turn++;
            ChangePlayer();
        }
        public void ValidOriginPosition(Position pos)
        {
            if (tab.piece(pos) == null)
            {
                throw new TabuleiroException("Not exist origin piece in position selected!");
            }
            if (PlayerActual != tab.piece(pos).Color)
            {
                throw new TabuleiroException("This piece selected is not yours!");
            }
            if (!tab.piece(pos).PossiblesMovesExist())
            {
                throw new TabuleiroException("Not have possibles moves for piece selected!");
            }
        }
        public void ValidDestinPosition(Position origin,Position destin)
        {
            if (!tab.piece(origin).CanMoveFor(destin))
            {
                throw new TabuleiroException("Destin position invalid!");
            }
        }
        private void ChangePlayer()
        {
            if(PlayerActual == Color.White)
            {
                PlayerActual = Color.Black;
            }
            else
            {
                PlayerActual = Color.White;
            }
        }
        public HashSet<Piece> CapturedsPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedsPieces(color));
            return aux;
        }
        public void InsertNewPiece(char column, int line, Piece piece)
        {
            tab.InsertPiece(piece, new PositionXadrez(column, line).ToPosition());
            pieces.Add(piece);
        }
        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Tower(tab, Color.White));
            InsertNewPiece('c', 2, new Tower(tab, Color.White));
            InsertNewPiece('d', 2, new Tower(tab, Color.White));
            InsertNewPiece('e', 2, new Tower(tab, Color.White));
            InsertNewPiece('e', 1, new Tower(tab, Color.White));
            InsertNewPiece('d', 1, new King(tab, Color.White));

            InsertNewPiece('c', 7, new Tower(tab, Color.Black));
            InsertNewPiece('c', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 7, new Tower(tab, Color.Black));
            InsertNewPiece('e', 8, new Tower(tab, Color.Black));
            InsertNewPiece('d', 8, new King(tab, Color.Black));


        }
    }
}
