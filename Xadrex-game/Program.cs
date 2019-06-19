using System;
using tabuleiro;
using Xadrez;

namespace Xadrex_game
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionXadrez position = new PositionXadrez('c', 7);
            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());
        }
    }
}
