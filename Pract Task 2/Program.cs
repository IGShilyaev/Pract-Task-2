using System;
using System.IO;

namespace Pract_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mainArr = ReadFile();
            int res = MinStrikes(mainArr);

            FileStream fs = new FileStream("OUTPUT.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(res);
            sw.Close();
            fs.Close();
        }

        static int MinStrikes(int[] arr)
        {
            if (arr[0] == 0 && arr[1] == 0) { return 0; }
            else if (arr[0] != 0 && arr[1] == 0 && arr[0] % 2 > 0) { return -1; }
            else if (arr[0] != 0 && arr[1] == 0 && arr[0] % 2 == 0) { return arr[0] / 2; }
            else if (arr[0] == 0 && arr[1] != 0)
            {
                int temp = 0;
                while (arr[1] % 2 > 0 || arr[1] % 4 > 0) { temp++; arr[1]++; }
                temp += arr[1] / 2;
                arr[0] = arr[1] / 2;
                temp += arr[0] / 2;
                return temp;
            }
            else if (arr[0] % 2 > 0)
            {
                int temp = 0;
                while (arr[1] % 2 > 0 || arr[1] % 4 == 0) { temp++; arr[1]++; }
                temp += arr[1] / 2;
                arr[0] += arr[1] / 2;
                temp += arr[0] / 2;
                return temp;
            }
            else if (arr[0] % 2 == 0)
            {
                int temp = 0;
                while (arr[1] % 2 > 0 || arr[1] % 4 > 0) { temp++; arr[1]++; }
                temp += arr[1] / 2;
                arr[0] += arr[1] / 2;
                temp += arr[0] / 2;
                return temp;
            }
            else return -1;
        }

        static int[] ReadFile()
        {
            FileStream fs = new FileStream("INPUT.TXT", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string[] arr = sr.ReadLine().Split(' ');
            int[] temp = new int[2];
            temp[0] = int.Parse(arr[0]);
            temp[1] = int.Parse(arr[1]);
            sr.Close();
            fs.Close();
            return temp;
        }

    }
}
