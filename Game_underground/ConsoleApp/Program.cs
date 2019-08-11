using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicsLib;
using DataBase;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to game ~Underground~");
            Console.WriteLine("Выбор персонажа:");
            Console.WriteLine(" 1 - Человек-маг / 2 - Гном-воин / 3 - Эльф-разведчик");
            Game g = ChoiceCharacters();

            int[] characters = character;
            List<Walk> moves = new List<Walk>();
            Console.WriteLine(" o - отдых / s - спуск / f - быстрый спуск / a - особое действие");

            Random r = new Random();
            int rnd = r.Next(2);

            int x1 = -1;
            int x2 = -1;
            while (x1 < 20 && x2 < 20)
            {
                if (rnd % 2 == 0)
                {
                    Status s1 = g.getStatus(g.Player1);
                    Console.Write(" Player 1 (Выносл: " + s1.Endurance + " / lvl: " + s1.Location + ") >>> ");
                    string go1 = Console.ReadLine();
                    moves.Add(new Walk(rnd, go1));
                    x1 = Go(g, go1, g.Player1);
                    rnd++;
                }
                else
                {
                    Status s2 = g.getStatus(g.Player2);
                    Console.Write(" Player 2 (Выносл: " + s2.Endurance + " / lvl: " + s2.Location + ") >>> ");
                    string go2 = Console.ReadLine();
                    moves.Add(new Walk(rnd, go2));
                    x2 = Go(g, go2, g.Player2);
                    rnd++;
                }
            }
            Console.WriteLine("Game over!");
            if (x1 > x2)
                Console.WriteLine("Player 1 Win!");
            else
                Console.WriteLine("Player 2 Win!");

            Console.WriteLine("Try connect to database...");
            Console.WriteLine("Please wait...");

            OneGame record = new OneGame { ListMove = moves, Characters = characters };
            try
            {
                using (GameContext db = new GameContext())
                {
                    db.Games.Add(record);
                    db.SaveChanges();

                    var games = db.Games.ToList();
                    OneGame lastGame = games[games.Count - 1];

                    Console.Write("Воспроизвести игру (yes/no): ");
                    string answ = Console.ReadLine();
                    if (answ == "yes")
                    {
                        Console.WriteLine("Запись игры:");
                        PlayRecordGame(lastGame);

                    }
                }
            }
            catch
            {
                Console.WriteLine("Connection error.");
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        public static int[] character = new int[2];
        public static Game ChoiceCharacters()
        {
            int p1 = 0, p2 = 0;
            while (p1 == p2)
            {
                Console.Write("player1 >> ");
                int.TryParse(Console.ReadLine(), out p1);
                character[0] = p1;
                Console.Write("player2 >> ");
                int.TryParse(Console.ReadLine(), out p2);
                character[1] = p2;
                if (p1 < 1 || p1 > 3 || p2 < 1 || p2 > 3)
                {
                    p1 = 0;
                    p2 = 0;
                    continue;
                }
            }
            Game g = new Game(p1, p2);
            return g;
        }

        public static int Go(Game g, string doing, object player)
        {
            Status s = new Status();
            switch (doing)
            {
                case "o":
                    {
                        s = g.Relax(player);
                        break;
                    }
                case "s":
                    {
                        s = g.Descent(player);
                        break;
                    }
                case "f":
                    {
                        s = g.FastDescent(player);
                        break;
                    }
                case "a":
                    {
                        s = g.SpecialAction(player);
                        break;
                    }
                default:
                    {
                        s = g.Relax(player);
                        break;
                    }
            }
            g.Stay(player);
            int endurance = s.Endurance;
            int loc = s.Location;
            Console.WriteLine(" lvl: " + loc + "  $  Выносливость: " + endurance);
            return loc;
        }

        public static void PlayRecordGame(OneGame record)
        {
            Game g = new Game(record.Characters[0], record.Characters[1]);

            Console.WriteLine(" o - отдых / s - спуск / f - быстрый спуск / a - особое действие");

            int x1 = -1;
            int x2 = -1;
            foreach (Walk c in record.ListMove)
            {
                if (c.Step % 2 == 0)
                {
                    Status s1 = g.getStatus(g.Player1);
                    Console.Write(" Player 1 (Выносл: " + s1.Endurance + " / lvl: " + s1.Location + ") >>> ");
                    Console.WriteLine(c.Commmand);
                    x1 = Go(g, c.Commmand, g.Player1);
                }
                else
                {
                    Status s2 = g.getStatus(g.Player2);
                    Console.Write(" Player 1 (Выносл: " + s2.Endurance + " / lvl: " + s2.Location + ") >>> ");
                    Console.WriteLine(c.Commmand);
                    x2 = Go(g, c.Commmand, g.Player2);
                }
            }

            Console.WriteLine("Game over!");
            if (x1 > x2)
                Console.WriteLine("Player 1 Win!");
            else
                Console.WriteLine("Player 2 Win!");
            Console.WriteLine("Игра была воспроизведена.");
        }




    }
}
