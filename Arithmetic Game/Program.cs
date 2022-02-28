using System;

namespace Arithmetic_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            const String wrong = "回答错误";
            Console.WriteLine("欢迎来到三则运算小游戏，请根据题目输入正确的值并得分！");
            int score = 0;
            for (int i = 0; i <= 4; i++)
            {
                Random random = new Random();
                int a = random.Next(-100, 101);
                int b = random.Next(-100, 101);
                String bStr = (b >= 0) ? b + "" : String.Format("({0})", b);
                int method = random.Next(0, 3);
                char methodChar = (method == 2) ? '*' : ((method == 1) ? '+' : '-');
                int result = (method == 2) ? a * b : ((method == 1) ? a + b : a - b);
                Console.WriteLine("第 {0} 题，{1}{2}{3}=", i + 1, a, methodChar, bStr);
                try{
                    int act = int.Parse(Console.ReadLine());
                    if(act == result)
                    {
                        Console.WriteLine("恭喜你回答正确！加 1 分。");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine(wrong);
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(wrong);
                }
            }
            Console.WriteLine("回答完毕！最终得分为：{0} 分", score);
            Console.ReadKey();
        }


    }
}
