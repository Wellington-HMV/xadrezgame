using System;
using tabuleiro;
using Xadrez;

namespace Xadrex_game
{
    class Screen
    {
        public static void PrintTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colums; j++)
                {
                    PrintPiece(tab.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n  a b c d e f g h");
        }
        public static void PrintTabuleiro(Tabuleiro tab, bool[,] positionsValid)
        {
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundAltered = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colums; j++)
                {
                    if (positionsValid[i, j])
                    {
                        Console.BackgroundColor = backgroundAltered;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOriginal;
                    }
                    PrintPiece(tab.Piece(i, j));
                    Console.BackgroundColor = backgroundOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n  a b c d e f g h");
            Console.BackgroundColor = backgroundOriginal;
        }
        public static PositionXadrez WritePositionXadrez()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionXadrez(column, line);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}


