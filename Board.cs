using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    internal class Board
    {
        public string[,] board = { { "A1 ", "B1 ", "C1 ", "D1 ", "E1 ", "F1 ", "G1 ", "H1 ", "I1 ", "J1 " }, { "A2 ", "B2 ", "C2 ", "D2 ", "E2 ", "F2 ", "G2 ", "H2 ", "I2 ", "J2 " }, { "A3 ", "B3 ", "C3 ", "D3 ", "E3 ", "F3 ", "G3 ", "H3 ", "I3 ", "J3 " }, { "A4 ", "B4 ", "C4 ", "D4 ", "E4 ", "F4 ", "G4 ", "H4 ", "I4 ", "J4 " }, { "A5 ", "B5 ", "C5 ", "D5 ", "E5 ", "F5 ", "G5 ", "H5 ", "I5 ", "J5 " }, { "A6 ", "B6 ", "C6 ", "D6 ", "E6 ", "F6 ", "G6 ", "H6 ", "I6 ", "J6 " }, { "A7 ", "B7 ", "C7 ", "D7 ", "E7 ", "F7 ", "G7 ", "H7 ", "I7 ", "J7 " }, { "A8 ", "B8 ", "C8 ", "D8 ", "E8 ", "F8 ", "G8 ", "H8 ", "I8 ", "J8 " }, { "A9 ", "B9 ", "C9 ", "D9 ", "E9 ", "F9 ", "G9 ", "H9 ", "I9 ", "J9 " }, { "A10", "B10", "C10", "D10", "E10", "F10", "G10", "H10", "I10", "J10" } };

        public void displayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    System.Console.Write($"{board[i, j]}");
                    if (j < board.GetLength(1) - 1)
                    {
                        System.Console.Write(" | ");
                    }
                }
                System.Console.WriteLine();
                System.Console.WriteLine("-----------------------------------------------------------");
            }
        }

        public void settingShip(int horizontal, int vertical, int placesShip, char direction)
        {
            if (direction == 'H')
            {
                if (placesShip == 1)
                {
                    board[vertical, horizontal] = "V  ";
                }
                else if (placesShip == 2)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical, horizontal + 1] = "V  ";
                }
                else if (placesShip == 3)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical, horizontal + 1] = "V  ";
                    board[vertical, horizontal + 2] = "V  ";
                }
                else if (placesShip == 4)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical, horizontal + 1] = "V  ";
                    board[vertical, horizontal + 2] = "V  ";
                    board[vertical, horizontal + 3] = "V  ";
                }
            }
            else
            {
                if (placesShip == 1)
                {
                    board[vertical, horizontal] = "V  ";
                }
                else if (placesShip == 2)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical + 1, horizontal] = "V  ";
                }
                else if (placesShip == 3)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical + 1, horizontal] = "V  ";
                    board[vertical + 2, horizontal] = "V  ";
                }
                else if (placesShip == 4)
                {
                    board[vertical, horizontal] = "V  ";
                    board[vertical + 1, horizontal] = "V  ";
                    board[vertical + 2, horizontal] = "V  ";
                    board[vertical + 3, horizontal] = "V  ";
                }
            }


        }

        public Boolean isShip(int vertical, int horizontal)
        {
            if (board[vertical, horizontal] == "V  ")
            {
                return true;
            }

            return false;
        }

        public void hitShip(int vertical, int horizontal)
        {
            board[vertical, horizontal] = "X  ";
        }

        public void missShip(int vertical, int horizontal)
        {
            board[vertical, horizontal] = "O  ";
        }

        public Boolean checkWin()
        {
            Boolean exit = false;
            Boolean win = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == "V  ")
                    {
                        return false;
                    }

                }
            }
            return true;

        }

        public Boolean isTouch(int row, int col, int size, char direction)
        {
            int k = 0;
            if (direction == 'H') //horizontal
            {
                if (row + size - 1 > 9)
                {
                    Console.WriteLine("Statek nie może się załamywać. Ustaw go jeszcze raz.");
                    return true;
                }
                switch (size)
                {
                    case 1:
                        k = 1;
                        break;
                    case 2:
                        k = 0;
                        break;
                    case 3:
                        k = -1;
                        break;
                    case 4:
                        k = -2;
                        break;
                }
                for (int i = -1; i < size + k; i++)
                {
                    for (
                        int j = -1; j < 1 + size; j++)
                    {
                        if (row + j > -1 && row + j < 10 && col + i > -1 && col + i < 10 && board[col + i, row + j] == "V  ")
                        {
                            Console.WriteLine("Statki nie mogą się stykać. Ustaw statek jeszcze raz");
                            return true;
                        }
                    }

                }
            }
            else if (direction == 'V') //vertical
            {
                if (col + size - 1 > 9)
                {
                    Console.WriteLine("Statek nie może się załamywać. Ustaw go jeszcze raz.");
                    return true;
                }
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < size + 1; j++)
                    {
                        if (row + i > -1 && row + i < 10 && col + j > -1 && col + j < 10 && board[col + j, row + i] == "V  ")
                        {
                            Console.WriteLine("Statki nie mogą się stykać. Ustaw statek jeszcze raz");
                            return true;
                        }
                    }

                }
            }



            return false;
        }

        public Boolean wasSpotOn(int vertical, int horizontal)
        {
            if (board[vertical, horizontal] == "X  " || board[vertical, horizontal] == "O  ")
            {
                Console.WriteLine();
                Console.WriteLine("Strzelałeś już w to miejsce. Wybierz inne.");
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
