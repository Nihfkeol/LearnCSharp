using System;

namespace Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            //定义初始变量
            int Line = 9;
            int Column = 4;
            string Y = "【有票】";
            string M = "【已售】";
            string[,] strArr = new string[Line,Column];
            int i,j;
            //定义初始数组
            for (i = 0; i < Line; i++)
            {
                for (j = 0; j < Column; j++)
                {
                    strArr[i, j] = Y;
                }
            }

            Console.Title = "简单客车售票系统";
            string s;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\t简单客车售票系统\n");
                for (i = 0; i < Line; i++)
                {
                    for (j = 0; j < Column; j++)
                    {
                        //已售的票，显示为红色
                        if(strArr[i, j] == M)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(strArr[i, j] + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("请输入座位行号和列号（1,2）购票\t输入q退出");
                s = Console.ReadLine();
                if (s == "q")
                {
                    break;
                }
                string[] ss = s.Split(",");
                //防止输入错误格式
                if (ss.Length == 2)
                {
                    int l = int.Parse(ss[0]);
                    int c = Convert.ToInt32(ss[1]);
                    //防止下标越界
                    if(l <= Line && c <= Column)
                    {
                        strArr[l - 1, c - 1] = M;
                    }
                    else
                    {
                        Console.WriteLine("输入错误回车继续");
                        Console.Read();
                    }
                }
                else
                {
                    Console.WriteLine("输入错误回车继续");
                    Console.Read();
                }
            }

        }
    }
}
