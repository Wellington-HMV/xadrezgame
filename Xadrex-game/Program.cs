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
                ChessGame play = new ChessGame();

                while (!play.Finish)
                {
                    Console.Clear();
                    Screen.PrintTabuleiro(play.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.WritePositionXadrez().ToPosition();
                    Console.Write("Origem: ");
                    Position destin = Screen.WritePositionXadrez().ToPosition();

                    play.ExecuteMov(origin, destin);
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
