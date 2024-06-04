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
            var letterToIndexMap = new Dictionary<string, int>
            {
                { "A", 0 },
                { "B", 1 },
                { "C", 2 },
                { "D", 3 },
                { "E", 4 },
                { "F", 5 },
                { "G", 6 },
                { "H", 7 },
                { "I", 8 },
                { "J", 9 }
            };

            while (true)
            {
                Console.WriteLine("Napisz literę pola:");
                string lettlerShip = Console.ReadLine().ToUpper();

                if (letterToIndexMap.TryGetValue(lettlerShip, out int index))
                {
                    return index;
                }
            }
        }

        public char setDirection()
        {
            Console.WriteLine("Podaj kierunek w który statek ma się ustawić");
            Console.WriteLine("V - Pionowo");
            Console.WriteLine("H - Poziom");
            string Direction = Console.ReadLine().ToUpper();
            switch (Direction)
            {
                case "V":
                    return 'V';
                case "H":
                default:
                    return 'H';
            }
        }

    }
}
