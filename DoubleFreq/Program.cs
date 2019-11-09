using System;
using System.Collections.Generic;
using System.IO;

namespace DoubleFreq
{
    class Program
    {
        static void Main(string[] args)
        {
            string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

            List<Alph> Alph = new List<Alph>();

                for (int c = 0; c < alph.Length; c++)
                    for (int j = 0; j < alph.Length; j++)
                        Alph.Add(new Alph(alph[c].ToString() + alph[j].ToString(), 0));

            string path = @"D:\GERASKIN\DoubleFreq\text.txt";
            string InputText = "";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    InputText = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int counter = 0;
            for (int j = 0; j < InputText.Length; j += 2)
                for (int i = 0; i < Alph.Count; i++)
                    if (InputText[j].ToString().ToLower() + InputText[j + 1].ToString().ToLower() == Alph[i].AlphChar) 
                    {
                        Alph[i].count++;
                        counter++;
                    }

            for (int i = 0; i < Alph.Count; i++)
            {
                Alph[i].count /= counter;
                Alph[i].count = Math.Round(Alph[i].count, 2);
            }


            foreach (var item in Alph)
                Console.WriteLine(item.AlphChar + " " + item.count);

            Console.ReadKey();
        }
    }
}
