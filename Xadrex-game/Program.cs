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
                    try
                    {
                        Console.Clear();
                        Screen.PrintTabuleiro(play.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + play.Turn);
                        Console.WriteLine("Waiting played : " + play.PlayerActual);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.WritePositionXadrez().ToPosition();
                        play.ValidOriginPosition(origin);

                        bool[,] possiblePositions = play.tab.piece(origin).MovesPossible();

                        Console.Clear();
                        Screen.PrintTabuleiro(play.tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destin: ");
                        Position destin = Screen.WritePositionXadrez().ToPosition();
                        play.ValidDestinPosition(origin, destin);

                        play.RealizePlayed(origin, destin);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
