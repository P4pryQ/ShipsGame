using Microsoft.VisualBasic.FileIO;
using Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Player
    {

        public void ready(int player, Boolean isHit)
        {
            if (isHit)
            {
                Console.WriteLine("Gratulacje! Trafiłeś, teraz dostajesz w nagrodę kolejny ruch");
            }
            Console.WriteLine($"Ruch gracza {player}");
            Console.WriteLine("Jeśli jesteś gotowy klinij dowolny przycisk");
            Console.ReadKey();
            Console.Clear();
        }

        public void endGame(int player, int player1Wins, int player2Wins)
        {
            string choose;
            Console.Clear();
            Console.WriteLine($"KONIEC GRY");
            Console.WriteLine($"WYGRANA GRACZA {player}");
            Console.WriteLine();
            Console.WriteLine("WYNIK:");
            Console.WriteLine("Gracz 1: " + player1Wins + " zwycięstwa");
            Console.WriteLine("Gracz 2: " + player2Wins + " zwycięstwa");
            Console.WriteLine();
            Console.WriteLine("Kliknij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            continueOrStop(player, player1Wins, player2Wins);
        }

        public void continueOrStop(int player, int player1Wins, int player2Wins)
        {


            int selectedOption = 1;
            bool accepted = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Zagraj ponownie" + (selectedOption == 1 ? " <-" : ""));
                Console.WriteLine("2. Koniec gry" + (selectedOption == 2 ? " <-" : ""));
                Console.WriteLine();
                Console.WriteLine("Poruszaj się strzałkami góra-dół i zatwierdź klikając ENTER");

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = 2;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    accepted = true;
                }

            } while (!accepted);

            Console.Clear();
            if (selectedOption == 1)
            {
                Game game2 = new Game(player1Wins, player2Wins);
                game2.startGame();
            }
            else if (selectedOption == 2)
            {
                Environment.Exit(1);
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }

}

