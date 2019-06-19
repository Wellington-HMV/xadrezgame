using System;
using tabuleiro;
using Xadrez;

namespace Xadrex_game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.InsertPiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.InsertPiece(new Tower(tab, Color.White), new Position(1, 3));
                tab.InsertPiece(new King(tab, Color.Black), new Position(2, 4));

                Screen.PrintTabuleiro(tab);
            }
            catch (TabuleiroException e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
