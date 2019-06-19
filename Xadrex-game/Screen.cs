using System;
using tabuleiro;

namespace Xadrex_game
{
    class Screen
    {
        public static void PrintTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Lines; i++)
            {
                for (int j = 0; j < tab.Lines; j++)
                {
                    if (tab.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}


