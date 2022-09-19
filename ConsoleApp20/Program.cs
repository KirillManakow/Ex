using System;

namespace Exam
{
    class program
    {
        public struct Tubes
        {
            public string name;
            public int length;
            public double diameter, thickness;
            public bool isDefective, isReinforced;
            public bool checkLength, checkDiameter, checkThickness;
            public double weight;
        }

        static void Main(string[] args)
        {
            Tubes[] tube = ReadData.Read(@"C:\Users\User\source\repos\ConsoleApp20\ConsoleApp20\DataFiles\data.txt");
            double[] diameters = new double[] { 20.000, 25.000, 32.000, 40.000, 50.000, 63.000 };
            for (int i = 0; i < tube.Length; i++)
            {
                if (!(3960 <= tube[i].length && tube[i].length <= 4040))
                {
                    tube[i].isDefective = true;
                    tube[i].checkLength = true;
                }
            }

            double startRange, endRange;
            for (int i = 0; i < tube.Length; i++)
            {
                bool check = true;
                if (!tube[i].isDefective)
                {
                    for (int j = 0; j < diameters.Length; j++)
                    {
                        startRange = diameters[j] - (diameters[j] / 100.0);
                        endRange = diameters[j] + (diameters[j] / 100.0);
                        if (!(startRange <= tube[i].diameter && tube[i].diameter <= endRange))
                        {
                            check = false;
                        }
                        else
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        tube[i].isDefective = true;
                        tube[i].checkDiameter = true;
                    }
                }
            }

            for (int i = 0; i < tube.Length; i++)
            {
                if (!tube[i].isDefective)
                {
                    switch (tube[i].name)
                    {
                        case "PN10":
                            startRange = tube[i].diameter / 100.0 * 10.0;
                            endRange = tube[i].diameter / 100.0 * 11.0;

                            if (!(Math.Round(startRange, 3) <= Math.Round(tube[i].thickness, 3) && Math.Round(tube[i].thickness, 3) <= Math.Round(endRange, 3)))
                            {
                                tube[i].isDefective = true;
                                tube[i].checkThickness = true;
                            }
                            break;
                        case "PN16":
                            startRange = tube[i].diameter / 100.0 * 13.5;
                            endRange = tube[i].diameter / 100.0 * 14.0;

                            if (!(Math.Round(startRange, 3) <= Math.Round(tube[i].thickness, 3) && Math.Round(tube[i].thickness, 3) <= Math.Round(endRange, 3)))
                            {
                                tube[i].isDefective = true;
                                tube[i].checkThickness = true;
                            }
                            break;
                        case "PN20":
                            startRange = tube[i].diameter / 100.0 * 16.5;
                            endRange = tube[i].diameter / 100.0 * 17.0;

                            if (!(Math.Round(startRange, 3) <= Math.Round(tube[i].thickness, 3) && Math.Round(tube[i].thickness, 3) <= Math.Round(endRange, 3)))
                            {
                                tube[i].isDefective = true;
                                tube[i].checkThickness = true;
                            }
                            break;
                        case "PN25":
                            startRange = tube[i].diameter / 100.0 * 16.5;
                            endRange = tube[i].diameter / 100.0 * 17.0;

                            if (!(Math.Round(startRange, 3) <= Math.Round(tube[i].thickness, 3) && Math.Round(tube[i].thickness, 3) <= Math.Round(endRange, 3)))
                            {
                                tube[i].isDefective = true;
                                tube[i].checkThickness = true;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine($"PN10 - {getPercent(tube, "PN10")}");
            Console.WriteLine($"PN16 - {getPercent(tube, "PN16")}");
            Console.WriteLine($"PN20 - {getPercent(tube, "PN20")}");
            Console.WriteLine($"PN25 - {getPercent(tube, "PN25")}");

            double p = 0;

            for (int i = 0; i < tube.Length; i++)
            {
                if (tube[i].isReinforced)
                {
                    p = 1240;
                }
                else
                {
                    p = 910;
                }
                tube[i].weight = p * tube[i].thickness * Math.PI * (tube[i].diameter - tube[i].thickness);
            }

            double totalWeight = 0, totalDef = 0, totalNotDef = 0;
            for (int i = 0; i < tube.Length; i++)
            {
                totalWeight += tube[i].weight;
                if (tube[i].isDefective)
                {
                    totalDef += tube[i].weight;
                }
                else
                {
                    totalNotDef += tube[i].weight;
                }
            }

            for (int i = 0; i < tube.Length; i++)
            {
                if (!tube[i].isDefective)
                {
                    Console.WriteLine($"{i + 1} - подходит ({tube[i].name}, {tube[i].length}, {tube[i].diameter}, {tube[i].thickness})");
                }
                else
                {
                    Console.WriteLine($"{i + 1} - не подходит ({tube[i].name}, {tube[i].length}, {tube[i].diameter}, {tube[i].thickness})");
                }
            }
        }

        static double getPercent(Tubes[] tube, string name)
        {
            int countDef = 0, countNotDef = 0;

            for (int i = 0; i < tube.Length; i++)
            {
                if (tube[i].name.Equals(name))
                {
                    if (tube[i].isDefective)
                    {
                        countDef++;
                    }
                    else
                    {
                        countNotDef++;
                    }
                }
            }
            return (countDef * 100) / (countDef + countNotDef);
        }
    }
}