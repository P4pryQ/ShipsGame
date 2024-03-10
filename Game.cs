using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{

    internal class Game(int player1Win, int player2Win)
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Board boardPlayer1 = new Board();
        Board boardPlayer2 = new Board();
        Board boardPlayer1Opponent = new Board();
        Board boardPlayer2Opponent = new Board();
        Ship Ship = new Ship();
        int playerMove = 1;
        Boolean isHit = false;
        int player1Wins = player1Win;
        int player2Wins = player2Win;

        public void startGame()
        {
            Instruction();
            player1.ready(1, false);
            SetShip(player1, boardPlayer1, 1);
            SetShip(player1, boardPlayer1, 2);
            SetShip(player1, boardPlayer1, 3);
            SetShip(player1, boardPlayer1, 4);
            playerMove = 2;
            player2.ready(2, false);
            SetShip(player2, boardPlayer2, 1);
            SetShip(player2, boardPlayer2, 2);
            SetShip(player2, boardPlayer2, 3);
            SetShip(player2, boardPlayer2, 4);
            while (true)
            {
                playerMove = 1;
                do
                {
                    TurnPlayer(player1, boardPlayer2, boardPlayer1, boardPlayer1Opponent);
                } while (isHit);
                playerMove = 2;
                do
                {
                    TurnPlayer(player2, boardPlayer1, boardPlayer2, boardPlayer2Opponent);
                } while (isHit);


            }

        }

        public void Instruction()
        {
            Console.Clear();
            Console.WriteLine("INSTRUKCJA GRY W STATKI");
            Console.WriteLine();
            Console.WriteLine("Ustawiasz:");
            Console.WriteLine("4 jedno masztowce");
            Console.WriteLine("3 dwu masztowce");
            Console.WriteLine("2 trzy masztowce");
            Console.WriteLine("1 cztero masztowiec");
            Console.WriteLine();
            Console.WriteLine("Stawiając kilkumasztowca wybierasz pole pierwszego masztu, reszta masztów stawia:");
            Console.WriteLine("jeśli wybrano kierunek poziomy to po jego prawej stronie,");
            Console.WriteLine("jeśli wybrano kierunek pionowy to na dół.");
            Console.WriteLine();
            Console.WriteLine("Jeśli gracz nie wybrał kierunku statku lub wybrał błędnie stawia on się automatycznie poziomo");
            Console.WriteLine("Po każdym ruchu gracza, program czeka aż zawodnicy zmienią się miejscami.");
            Console.WriteLine("Jeśli twój strzał będzie trafiony dostajesz w nagrodę jeszcze jeden.");
            Console.WriteLine();
            Console.WriteLine("LEGENDA:");
            Console.WriteLine("O - pudło");
            Console.WriteLine("X - trafiony");
            Console.WriteLine("V - statek");
            Console.WriteLine();
            Console.WriteLine("Aby uruchomić grę kliknij dowolny przycisk");

            Console.ReadKey();
            Console.Clear();
        }

        public void TurnPlayer(Player player, Board boardOpponent, Board myBoard, Board myBoardOpponent)
        {
            int horizontal, vertical;
            player.ready(playerMove, isHit);

            Console.WriteLine("TWOJA PLANSZA:");
            Console.WriteLine();
            myBoard.displayBoard();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PLANSZA TWOJEGO PRZECIWNIKA:");
            Console.WriteLine();
            myBoardOpponent.displayBoard();

            do
            {
                Console.WriteLine("Podaj pole w które chcesz uderzyć");
                horizontal = Ship.setLettler();
                vertical = Ship.setFigure();
            } while (boardOpponent.wasSpotOn(vertical, horizontal));



            if (boardOpponent.isShip(vertical, horizontal))
            {
                boardOpponent.hitShip(vertical, horizontal);
                myBoardOpponent.hitShip(vertical, horizontal);
                isHit = true;
            }
            else
            {
                boardOpponent.missShip(vertical, horizontal);
                myBoardOpponent.missShip(vertical, horizontal);
                isHit = false;
            }

            if (boardOpponent.checkWin())
            {
                if (playerMove == 1)
                {
                    player1Wins++;
                }
                else if (playerMove == 2)
                {
                    player2Wins++;
                }
                player.endGame(playerMove, player1Wins, player2Wins);
            }

            Console.Clear();
        }

        public void SetShip(Player player, Board board, int placesShip)
        {
            int qtyShip = 0;
            string qtyMast = "";

            switch (placesShip)
            {
                case 1:
                    qtyShip = 4;
                    qtyMast = "JEDNO";
                    break;
                case 2:
                    qtyShip = 3;
                    qtyMast = "DWU";
                    break;
                case 3:
                    qtyShip = 2;
                    qtyMast = "TRZY";
                    break;
                case 4:
                    qtyShip = 1;
                    qtyMast = "CZTERO";
                    break;
            }

            for (int i = 0; i < qtyShip; i++)
            {
                int vertical, horizontal;
                char direction = 'H';
                board.displayBoard();
                Console.WriteLine($"Wybierz, gdzie chcesz ustawić {qtyMast} masztowca");
                do
                {
                    horizontal = Ship.setLettler();
                    vertical = Ship.setFigure();
                    if (placesShip != 1)
                    {
                        direction = Ship.setDirection();
                    }

                } while (board.isTouch(horizontal, vertical, placesShip, direction));
                board.settingShip(horizontal, vertical, placesShip, direction);
                Console.Clear();
            }
        }
    }
}