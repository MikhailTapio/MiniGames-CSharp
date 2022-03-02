using System;
using System.Diagnostics;

namespace Arithmetic_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            const String invalidCount = "输入不规范，题量设定为默认值 5。";
            const String wrong = "回答错误";
            Console.WriteLine("欢迎来到三则运算小游戏，请根据题目输入正确的值并得分！");
            Console.WriteLine("按任意键开始选择游戏模式。");
            Console.ReadKey();
            int mode = 0;
            Console.WriteLine("请输入数字以选择游戏模式：");
            Console.WriteLine("0：加法模式");
            Console.WriteLine("1：减法模式");
            Console.WriteLine("2：乘法模式");
            Console.WriteLine("3：三则运算混合模式");
            try
            {
                mode = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("输入有误，默认为加法模式。");
            }
            String modeName = "加法";
            switch (mode)
            {
                case 0: 
                    modeName = "加法"; break;
                case 1:
                    modeName = "减法"; break;
                case 2:
                    modeName = "乘法"; break;
                case 3:
                    modeName = "三则运算混合"; break;
            }
            int range = 100;
            Console.WriteLine("请输入数字以选定操作数的范围：");
            Console.WriteLine("0：10 以内");
            Console.WriteLine("1：10 - 100");
            Console.WriteLine("2：100 - 1000");
            Console.WriteLine("3：1000 - 10000");
            try
            {
                int m = int.Parse(Console.ReadLine());
                switch (m)
                {
                    case 0:
                        range = 10; break;
                    case 1:
                        break;
                    case 2:
                        range = 1000; break;
                    case 3:
                        range = 10000; break;
                }
            }
            catch
            {
                Console.WriteLine("输入有误，默认为 10 ~ 100。");
            }
            bool negative = false;
            Console.WriteLine("允许负数出现吗？输入 y 则允许。");
            try
            {
                negative = Console.ReadLine() == "y" || Console.ReadLine() == "Y";
            }
            catch
            {
                Console.WriteLine("输入有误，默认为不允许负数。");
            }
            int totalCount = 4;
            Console.WriteLine("请输入本次游戏的题量。");
            try
            {
                int got = int.Parse(Console.ReadLine()) - 1;
                if(got >= 1)
                {
                    totalCount = got;
                }
                else
                {
                    Console.WriteLine(invalidCount);
                }
            }
            catch
            {
                Console.WriteLine(invalidCount);
            }
            Console.WriteLine("按任意键开始{0}游戏。", modeName);
            Console.ReadKey();
            int score = 0;
            long totalTime = 0;
            int wrongCount = 0;
            int method = (mode == 3) ? 0 : mode;
            for (int i = 0; i <= totalCount; i++)
            {
                Random random = new Random();
                int a = (negative) ? random.Next(-range, range + 1) : random.Next(range / 10, range + 1);
                int b = (negative) ? random.Next(-range, range + 1) : random.Next(range / 10, range + 1);
                String bStr = (b >= 0) ? b + "" : String.Format("({0})", b);
                if (mode == 3)
                {
                    method = random.Next(0, 3);
                }
                char methodChar = (method == 2) ? '*' : ((method == 0) ? '+' : '-');
                int result = (method == 2) ? a * b : ((method == 0) ? a + b : a - b);
                Console.WriteLine("第 {0} 题，{1}{2}{3}=", i + 1, a, methodChar, bStr);
                try{
                    long startTime = DateTime.Now.Ticks;
                    int act = int.Parse(Console.ReadLine());
                    if(act == result)
                    {
                        long time = DateTime.Now.Ticks - startTime;
                        int add = Math.Max(2, 10 - (int)time / 30000000);
                        Console.WriteLine("恭喜你回答正确！耗时 {0} 毫秒，加 {1} 分。", time / 10000, add);
                        score+= add;
                        totalTime += time;
                    }
                    else
                    {
                        Console.WriteLine(wrong);
                        wrongCount++;
                    }
                }catch
                {
                    Console.WriteLine(wrong);
                    wrongCount++;
                }
            }
            int correctCount = totalCount + 1 - wrongCount;
            Console.WriteLine("{0}（操作数最大为 {1}，{2}含负数）游戏已完成！最终得分为：{3} 分，一共作答 {4} 题，答对 {5} 题，答对的每道题平均耗时 {6} 毫秒", modeName, range, (negative)? "" : "不", score, totalCount + 1, correctCount, totalTime / correctCount / 10000);
            Console.WriteLine("按任意键退出游戏。");
            Console.ReadKey();
        }


    }
}
