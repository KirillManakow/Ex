using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class ReadData
    {
        static public program.Tubes[] Read(string path)
        {
            program.Tubes[] arr = new program.Tubes[0];
            if (!File.Exists(path))
            {
                Console.WriteLine("Файла не существует!");
                Environment.Exit(0);
            }
            var lines = File.ReadAllLines(path);
            int i = 0;
            foreach (var line in lines)
            {
                Array.Resize(ref arr, arr.Length + 1);
                string[] parts = line.Split(";");
                arr[i].name = parts[0];
                arr[i].length = Convert.ToInt32(parts[1]);
                arr[i].diameter = Convert.ToDouble(parts[2]);
                arr[i].thickness = Convert.ToDouble(parts[3]);

                if (String.IsNullOrEmpty(parts[4]))
                {
                    arr[i].isReinforced = false;
                }
                else
                {
                    arr[i].isReinforced = true;
                }
                arr[i].isDefective = false;
                arr[i].checkLength = false;
                arr[i].checkDiameter = false;
                arr[i].checkThickness = false;
                i++;
            }
            return arr;
        }
    }
}
