﻿using System;
using tabuleiro;

namespace Xadrex_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            Screen.PrintTabuleiro(tab);
        }
    }
}
