using System;
using System.Collections.Generic;

namespace homework
{
    class Program
    {
        static int Frequency = 0;
        static int Duration = 100;
        static bool AddSound = false;
        static bool VoidSound = false;
        static List<int> ListSound = new List<int>();

        static List<int[]> Frequencys = new List<int[]> {
            new int[] { 65, 69, 73, 77, 82, 87, 92, 98, 103, 110, 116, 123 },
            new int[] { 130, 138, 146, 155, 164, 174, 185, 196, 207, 220, 233, 246 },
            new int[] { 261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 493 },
        };

        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Переключение между октавами - F1, F2, F3");
            Console.WriteLine("Чтобы записать мега хит нажмите - F4 (чтобы перестать записывать нажмите F4)");
            Console.WriteLine("Откава: {0} Скорость: {1}\n", Frequency, Duration);

            if (AddSound) Console.WriteLine("Идёт запись музыки!!!");
            else if (ListSound.Count != 0) Console.WriteLine("Есть записанный музон нажмите - F5 (чтобы послушать)");

            Console.Write("Нажмите на клавишу: ");
            Buttons(Console.ReadKey());
        }
        static void Buttons(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.F1) Frequency = 0;
            else if (key.Key == ConsoleKey.F2) Frequency = 1;
            else if (key.Key == ConsoleKey.F3) Frequency = 2;
            else if (key.Key == ConsoleKey.F4) SoudListActive();
            else if (key.Key == ConsoleKey.F5) PlaySoudList();

            if (!VoidSound) PlaySoud(key.Key);
        }
        static void SoudListActive()
        {
            if (!AddSound) ListSound = new List<int>();
            AddSound = !AddSound;
        }
        static void PlaySoudList()
        {
            VoidSound = true;
            Console.WriteLine("...");
            for (int i = 0; i < ListSound.Count; i++) Console.Beep(ListSound[i], Duration);
            VoidSound = false;
            Menu();
        }
        static void PlaySoud(ConsoleKey key)
        {
            int value = -1;
            if (key == ConsoleKey.Q) value = Frequencys[Frequency][0];
            else if (key == ConsoleKey.W) value = Frequencys[Frequency][1];
            else if (key == ConsoleKey.E) value = Frequencys[Frequency][2];
            else if (key == ConsoleKey.R) value = Frequencys[Frequency][3];
            else if (key == ConsoleKey.T) value = Frequencys[Frequency][4];
            else if (key == ConsoleKey.Y) value = Frequencys[Frequency][5];
            else if (key == ConsoleKey.U) value = Frequencys[Frequency][6];
            else if (key == ConsoleKey.I) value = Frequencys[Frequency][7];
            else if (key == ConsoleKey.O) value = Frequencys[Frequency][8];
            else if (key == ConsoleKey.P) value = Frequencys[Frequency][9];
            else if (key == ConsoleKey.A) value = Frequencys[Frequency][10];
            else if (key == ConsoleKey.S) value = Frequencys[Frequency][11];
            if (value != -1)
            {
                Console.Beep(value, Duration);
                if (AddSound) ListSound.Add(value);
            }
            Menu();
        }
    }
}