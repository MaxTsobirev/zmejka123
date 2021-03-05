using System;
using System.Collections.Generic;
using System.Text;

namespace zmejka
{
    public class Start
    {
        public ConsoleKeyInfo key;
        public Start()
        {
        }
        int valik = 0;
        public int choice()
        {

            Console.SetCursorPosition(0, 5);
            Console.WriteLine("------------------");
            Console.WriteLine(" Start game - S\n Stop game - Q");
            Console.WriteLine("------------------");
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.S)
            {
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("------------------");
                Console.WriteLine(" Large map - L\n Small map - S");
                Console.WriteLine("------------------");
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.L)
                {
                    valik = 151;
                }
                else
                {
                    valik = 101;
                }
            }
            else if (key.Key == ConsoleKey.Q)
            {
                valik = 2;
            }
            return valik;
        }

        public void Game_stop()
        {
            Console.Clear();
            Console.WriteLine("--------------");
            Console.WriteLine("              ");
            Console.WriteLine("     ()_()    ");
            Console.WriteLine("    ( o_- )   ");
            Console.WriteLine("     ()o()    ");
            Console.WriteLine("     ()_()    ");
            Console.Beep();

            Environment.Exit(1);


        }
    }
}