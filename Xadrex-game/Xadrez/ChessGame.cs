using System;
using tabuleiro;
using Xadrez;

namespace Xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public bool Finish { get; private set; }
        private int Turn;
        private Color PlayerActual;
        public ChessGame()
        {
            tab = new Tabuleiro(8, 8);
            Turn = 1;
            PlayerActual = Color.White;
            InsertPieces();
            Finish = false;
        }
        public void ExecuteMov(Position origin, Position destin)
        {
            Piece p = tab.RemovePiece(origin);
            p.IncrementQntMoves();
            Piece capturedPiece = tab.RemovePiece(destin);
            tab.InsertPiece(p, destin);
        }
        private void InsertPieces()
        {
            tab.InsertPiece(new Tower(tab, Color.White), new PositionXadrez('a', 8).ToPosition());
               tab.InsertPiece(new King(tab, Color.White), new PositionXadrez('e', 8).ToPosition());
               tab.InsertPiece(new Tower(tab, Color.Black), new PositionXadrez('h', 8).ToPosition());
               tab.InsertPiece(new King(tab, Color.Black), new PositionXadrez('e', 1).ToPosition());
            /*   tab.InsertPiece(new Bishop(tab, Color.White), new PositionXadrez('c', 8).ToPosition());
            tab.InsertPiece(new Horse(tab, Color.Black), new PositionXadrez('b', 8).ToPosition());
               tab.InsertPiece(new Lady(tab, Color.Black), new PositionXadrez('d', 8).ToPosition());
               tab.InsertPiece(new Bishop(tab, Color.Black), new PositionXadrez('f', 8).ToPosition());
               tab.InsertPiece(new Horse(tab, Color.White), new PositionXadrez('g', 8).ToPosition());

               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('a', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('b', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('c', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('d', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('e', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('f', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('g', 7).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('h', 7).ToPosition());

               tab.InsertPiece(new Tower(tab, Color.Black), new PositionXadrez('a', 1).ToPosition());
               tab.InsertPiece(new Horse(tab, Color.White), new PositionXadrez('b', 1).ToPosition());
               tab.InsertPiece(new Bishop(tab, Color.Black), new PositionXadrez('c', 1).ToPosition());
               tab.InsertPiece(new Lady(tab, Color.White), new PositionXadrez('d', 1).ToPosition());
               tab.InsertPiece(new Bishop(tab, Color.White), new PositionXadrez('f', 1).ToPosition());
               tab.InsertPiece(new Horse(tab, Color.Black), new PositionXadrez('g', 1).ToPosition());
               tab.InsertPiece(new Tower(tab, Color.White), new PositionXadrez('h', 1).ToPosition());

               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('a', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('b', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('c', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('d', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('e', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('f', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.White), new PositionXadrez('g', 2).ToPosition());
               tab.InsertPiece(new Pawn(tab, Color.Black), new PositionXadrez('h', 2).ToPosition());*/


        }
    }
}
