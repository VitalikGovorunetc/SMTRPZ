using System;
using System.Collections.Generic;
using System.Threading;

namespace TRPZ_Lab
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Train train = new Train();
            train.Passangers.AddRange(
                new List<Passangers>()
                {
                    new Passangers {Name = "Пассажир 1"},
                    new Passangers {Name = "Пассажир 2"},
                    new Passangers {Name = "Пассажир 3"},
                    new Passangers {Name = "Пассажир 4"},
                    new Passangers {Name = "Пассажир 5"},
                    new Passangers {Name = "Пассажир 6"}
                }
            );

            int number = 1;
            while (true)
            {
                if (train.Running)
                {
                    Console.WriteLine("Двигается");
                }
                else
                {
                    Console.WriteLine("Стоит");
                }
                Console.WriteLine($"Остановок: {train.Ostanovka}");
                Console.WriteLine($"Скорость: {train.Speed}");
                Console.WriteLine($"Пассажиров: {train.Passangers.Count}");
                Console.WriteLine();
                if (train.Running)
                {
                    if (number == 1)
                    {
                        Console.WriteLine("Остановить"); 

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Остановить");
                    }

                    if (number == 2)
                    {
                        Console.WriteLine("Убавить скорость");

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Убавить скорость");
                    }

                    if (number == 3)
                    {
                        Console.WriteLine("Увеличить скорость");

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Увеличить скорость");
                    }

                }
                else
                {
                    if (number == 1)
                    {
                        Console.WriteLine("+Пассажиров");
                    }
                    else
                    {
                        Console.WriteLine("+Пассажиров");
                    }

                    if (number == 2)
                    {
                        Console.WriteLine("-Пассажиров");
                    }
                    else
                    {
                        Console.WriteLine("-Пассажиров");
                    }

                    if (number == 3)
                    {
                        Console.WriteLine("Start/Stop");
                    }
                    else
                    {
                        Console.WriteLine("Start/Stop");
                    }
                }

                var key = Console.ReadKey();
                Console.Clear();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (number < 3)
                    {
                        number++;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (number > 1)
                    {
                        number--;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    try
                    {
                        if (train.Running)
                        {
                            switch (number)
                            {
                                case 1:
                                    train.Stop();
                                    break;
                                case 2:
                                    Console.WriteLine("Убавить скорость: ");
                                    var speeddown = Convert.ToInt32(Console.ReadLine());
                                    train.SpeedDown(speeddown);
                                    break;
                                case 3:
                                    Console.WriteLine("Увеличить скорость: ");
                                    var speedup= Convert.ToInt32(Console.ReadLine());
                                    train.SpeedUp(speedup);
                                    break;
                            }
                        }
                        else
                        {
                            switch (number)
                            {
                                case 1:
                                    Console.WriteLine("Добавить пассажиров ?: ");
                                    var add = Convert.ToInt32(Console.ReadLine());
                                    train.Addpass(add);
                                    break;
                                case 2:
                                    Console.WriteLine("Удалить пассажиров ?: ");
                                    var remove = Convert.ToInt32(Console.ReadLine());
                                    train.Removepass(remove);
                                    break;
                                case 3:
                                    train.Run();
                                    break;
                            }
                        }

                        Console.Clear();
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(5000);
                    }
                }
            }
        }
    }
}
