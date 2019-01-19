using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public static class Functions
    {
        static List<string> Dates = new List<string>();

        public static void Generate(DateTime From, DateTime To)
        {
            for (int y = From.Year; y <= To.Year; y++)
            {
                for (int m = 1; m <= 12; m++)
                {
                    int days;
                    if (m == 2)
                        days = 28;
                    else if (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12)
                        days = 31;
                    else
                        days = 30;

                    for (int d = 1; d <= days; d++)
                    {
                        Dates.Add($"{d.ToString("D2")}.{m.ToString("D2")}.{y}");
                    }
                }
            }

            int IdFrom, IdTo;
            IdFrom = 0;
            IdTo = 0;

            for (int i = 0; i < Dates.Count; i++)
            {
                if (From.ToString("dd.MM.yyyy") == Dates[i])
                    IdFrom = i;
                else if (To.ToString("dd.MM.yyyy") == Dates[i])
                    IdTo = i;
            }

            for (int i = 0; i < Dates.Count; i++)
            {
                if (i < IdFrom || i > IdTo)
                {
                    Dates.Remove(Dates[i]);
                    i--;
                    IdFrom--;
                    IdTo--;
                }
            }
        }

        public static void Export(string Path)
        {
            FileStream fs = new FileStream($"{Path}\\Datelist.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (string Date in Dates)
            {
                sw.WriteLine(Date);
            }

            sw.Close();
        }
    }
}
