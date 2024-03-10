using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Ship
    {
        public int setFigure()
        {
            int parsedNumber;
            while (true)
            {
                Console.WriteLine("Napisz cyfre pola:");
                string figureShip = Console.ReadLine();
                if (int.TryParse(figureShip, out parsedNumber) && parsedNumber > 0 && parsedNumber < 11)
                {
                    return parsedNumber - 1;
                }
            }
        }

        public int setLettler()
        {
            string lettlerShip;
            while (true)
            {
                Console.WriteLine("Napisz litere pola:");
                lettlerShip = Console.ReadLine().ToUpper();

                switch (lettlerShip)
                {
                    case "A":
                        return 0;
                    case "B":
                        return 1;
                    case "C":
                        return 2;
                    case "D":
                        return 3;
                    case "E":
                        return 4;
                    case "F":
                        return 5;
                    case "G":
                        return 6;
                    case "H":
                        return 7;
                    case "I":
                        return 8;
                    case "J":
                        return 9;
                }
            }
        }

        public char setDirection()
        {
            Console.WriteLine("Podaj kierunek w który statek ma sie ustawić");
            Console.WriteLine("P - Pionowo");
            Console.WriteLine("O - Poziom");
            string Direction = Console.ReadLine().ToUpper();
            if (Direction == "P")
            {
                return 'V'; //vertical
            }
            else
            {
                return 'H'; //horizontal
            }
        }

    }
}
