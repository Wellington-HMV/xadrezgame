using System.Collections.Generic;
using tabuleiro;
using Xadrez;

namespace Xadrez
{
    class ChessGame
    {
        public Tabuleiro tab { get; private set; }
        public int Turn { get; private set; }
        public Color PlayerActual { get; private set; }
        public bool Finish { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool Xeque { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }
        public ChessGame()
        {
            tab = new Tabuleiro(8, 8);
            Turn = 1;
            PlayerActual = Color.White;
            Finish = false;
            Xeque = false;
            VulnerableEnPassant = null;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InsertPieces();
        }
        public Piece ExecuteMov(Position origin, Position destin)                  //executa o movimento
        {
            Piece p = tab.RemovePiece(origin);
            p.IncrementQntMoves();
            Piece capturedPiece = tab.RemovePiece(destin);
            tab.InsertPiece(p, destin);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            //#Jogada especial roque pequeno
            if (p is King && destin.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinT = new Position(origin.Line, origin.Column + 1);
                Piece T = tab.RemovePiece(originT);
                T.IncrementQntMoves();
                tab.InsertPiece(T, destinT);
            }
            //#Jogada especial roque grande
            if (p is King && destin.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinT = new Position(origin.Line, origin.Column - 1);
                Piece T = tab.RemovePiece(originT);
                T.IncrementQntMoves();
                tab.InsertPiece(T, destinT);
            }
            //#jogada especial enpassant
            if (p is Pawn)
            {
                if (origin.Column != destin.Column && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destin.Line + 1, destin.Column);
                    }
                    else
                    {
                        posP = new Position(destin.Line - 1, destin.Column);
                    }
                    capturedPiece = tab.RemovePiece(posP);
                    captured.Add(capturedPiece);
                }
            }
            return capturedPiece;
        }
        public void UndoMove(Position origin, Position destin, Piece pieceCaptured)  //desfaz o movimento
        {
            Piece p = tab.RemovePiece(destin);
            p.DecrementQntMoves();
            if (pieceCaptured != null)
            {
                tab.InsertPiece(pieceCaptured, origin);
                captured.Remove(pieceCaptured);
            }
            tab.InsertPiece(p, origin);
            //#Jogada especial roque pequeno
            if (p is King && destin.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinT = new Position(origin.Line, origin.Column + 1);
                Piece T = tab.RemovePiece(destinT);
                T.DecrementQntMoves();
                tab.InsertPiece(T, originT);
            }
            //#Jogada especial roque grande
            if (p is King && destin.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinT = new Position(origin.Line, origin.Column - 1);
                Piece T = tab.RemovePiece(destinT);
                T.DecrementQntMoves();
                tab.InsertPiece(T, originT);
            }
            //#jogada especial enpassant
            if(p is Pawn)
            {
                if(origin.Column!= destin.Column && pieceCaptured == VulnerableEnPassant)
                {
                    Piece pawn = tab.RemovePiece(destin);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destin.Column);
                    }
                    else
                    {
                        posP = new Position(4, destin.Column);
                    }
                    tab.InsertPiece(pawn, posP);
                }
            }
        }
        public void RealizePlayed(Position origin, Position destin)
        {
            Piece capturedPiece = ExecuteMov(origin, destin);
            if (XequeStay(PlayerActual))                                            //testa se está em Xeque
            {
                UndoMove(origin, destin, capturedPiece);
                throw new TabuleiroException("You don't stay XEQUE!");
            }
            Piece p = tab.piece(destin);
            //#jogada especial promocao
            if(p.Color == Color.White && destin.Line == 0 || p.Color == Color.Black && destin.Line == 7)
            {
                p = tab.RemovePiece(destin);
                pieces.Remove(p);
                Piece lady = new Lady(tab, p.Color);
                tab.InsertPiece(lady, destin);
                pieces.Add(lady);
            }
            //verifica se esta em xeque
            if (XequeStay(Adversary(PlayerActual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false; ;
            }
            if (XequeKillTest(Adversary(PlayerActual)))
            {
                Finish = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
            //#Jogada especial en passant
            if (p is Pawn && destin.Line == origin.Line - 2 || destin.Line == origin.Line + 2)
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }
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
        public void ValidDestinPosition(Position origin, Position destin)
        {
            if (!tab.piece(origin).CanMoveFor(destin))
            {
                throw new TabuleiroException("Destin position invalid!");
            }
        }
        private void ChangePlayer()
        {
            if (PlayerActual == Color.White)
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
                if (x.Color == color)
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
        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.Black;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece x in InGamePieces(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool XequeStay(Color color) // teste para ver se o rei esta em xeque
        {
            Piece k = King(color);
            if (k == null)
            {
                throw new TabuleiroException("Not have king in game!");
            }
            foreach (Piece x in InGamePieces(Adversary(color)))
            {
                bool[,] mat = x.MovesPossible();
                if (mat[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool XequeKillTest(Color color) //checando se esta em xeque mate
        {
            if (!XequeStay(color))
            {
                return false;
            }
            foreach (Piece x in InGamePieces(color))
            {
                bool[,] mat = x.MovesPossible();
                for (int i = 0; i < tab.Lines; i++)
                {
                    for (int j = 0; j < tab.Colums; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destin = new Position(i, j);
                            Piece capturedPiece = ExecuteMov(origin, destin);
                            bool testXeque = XequeStay(color);
                            UndoMove(origin, destin, capturedPiece);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void InsertNewPiece(char line, int column, Piece piece)
        {
            tab.InsertPiece(piece, new PositionXadrez(line, column).ToPosition());
            pieces.Add(piece);
        }
        private void InsertPieces()
        {
            InsertNewPiece('a', 1, new Tower(tab, Color.White));
            InsertNewPiece('b', 1, new Horse(tab, Color.White));
            InsertNewPiece('c', 1, new Bishop(tab, Color.White));
            InsertNewPiece('d', 1, new Lady(tab, Color.White));
            InsertNewPiece('e', 1, new King(tab, Color.White, this));
            InsertNewPiece('f', 1, new Bishop(tab, Color.White));
            InsertNewPiece('g', 1, new Horse(tab, Color.White));
            InsertNewPiece('h', 1, new Tower(tab, Color.White));
            InsertNewPiece('a', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('b', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('c', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('d', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('e', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('f', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('g', 2, new Pawn(tab, Color.White, this));
            InsertNewPiece('h', 2, new Pawn(tab, Color.White, this));

            InsertNewPiece('a', 8, new Tower(tab, Color.Black));
            InsertNewPiece('b', 8, new Horse(tab, Color.Black));
            InsertNewPiece('c', 8, new Bishop(tab, Color.Black));
            InsertNewPiece('d', 8, new Lady(tab, Color.Black));
            InsertNewPiece('e', 8, new King(tab, Color.Black, this));
            InsertNewPiece('f', 8, new Bishop(tab, Color.Black));
            InsertNewPiece('g', 8, new Horse(tab, Color.Black));
            InsertNewPiece('h', 8, new Tower(tab, Color.Black));
            InsertNewPiece('a', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('b', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('c', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('d', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('e', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('f', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('g', 7, new Pawn(tab, Color.Black, this));
            InsertNewPiece('h', 7, new Pawn(tab, Color.Black, this));
        }
    }
}
