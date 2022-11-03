using System;

namespace GameOfLifeEvilRefactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] b = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    b[i, j] = 0;
                }
            }

            b[3, 3] = 1;
            b[3,4] = 1;
            b[3, 5] = 1;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(b[i, j]);
                }
                Console.WriteLine();
            }

            int[,] nb = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    nb[i, j] = 0;
                }
            }

            for (int i = 0; i < 10 - 1; i++)
                for (int j = 0; j < 10 - 1; j++)
                {
                    var n = 0;
                    if (i != 0)
                    {
                        if (b[i - 1, j] == 1) n++;
                        if (j != 0 && b[i - 1, j - 1] == 1) n++;
                        if (j != 10 && b[i - 1, j + 1] == 1) n++;
                    }

                    n = DoThing(j, b, i, n);

                    if (i != 10)
                    {
                        if (j != 10 && b[i + 1, j + 1] == 1) n++;
                        if (b[i + 1, j] == 1) n++;
                    }

                    if (j != 10 && b[i, j + 1] == 1) n++;

                    if (n >= 2 && n <= 3)
                    {
                        if (b[i, j] == 1) nb[i, j] = 1;
                        else
                        {
                            Foo.Bar(n, nb, i, j);
                        }
                    }
                    else nb[i, j] = 0;
                }
                
            b = nb;
            Console.WriteLine();
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(b[i, j]);
                }
                Console.WriteLine();
            }

            nb = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    nb[i, j] = 0;
                }
            }

            for (int i = 0; i < 10 - 1; i++)
                for (int j = 0; j < 10 - 1; j++)
                {
                    var n = 0;
                    if (i != 0)
                    {
                        if (b[i - 1, j] == 1) n++;
                        if (j != 0 && b[i - 1, j - 1] == 1) n++;
                        if (j != 10 && b[i - 1, j + 1] == 1) n++;
                    }

                    if (j != 0)
                    {
                        if (b[i, j - 1] == 1) n++;
                        if (i != 10 && b[i + 1, j - 1] == 1) n++;
                    }

                    if (i != 10)
                    {
                        if (j != 10 && b[i + 1, j + 1] == 1) n++;
                        if (b[i + 1, j] == 1) n++;
                    }

                    if (j != 10 && b[i, j + 1] == 1) n++;

                    if (n >= 2 && n <= 3)
                    {
                        if (b[i, j] == 1) nb[i, j] = 1;
                        else
                        {
                            Foo.Bar2(n, nb, i, j);
                        }
                    }
                    else nb[i, j] = 0;
                }

            b = nb;
            Console.WriteLine();
            Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(b[i, j]);
                }
                Console.WriteLine();
            }

            nb = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    nb[i, j] = 0;
                }
            }

            for (int i = 0; i < 10 - 1; i++)
                for (int j = 0; j < 10 - 1; j++)
                {
                    var n = 0;
                    if (i != 0)
                    {
                        if (b[i - 1, j] == 1) n++;
                        if (j != 0 && b[i - 1, j - 1] == 1) n++;
                        if (j != 10 && b[i - 1, j + 1] == 1) n++;
                    }

                    if (j != 0)
                    {
                        if (b[i, j - 1] == 1) n++;
                        if (i != 10 && b[i + 1, j - 1] == 1) n++;
                    }

                    if (i != 10)
                    {
                        if (j != 10 && b[i + 1, j + 1] == 1) n++;
                        if (b[i + 1, j] == 1) n++;
                    }

                    if (j != 10 && b[i, j + 1] == 1) n++;

                    if (n >= 2 && n <= 3)
                    {
                        if (b[i, j] == 1) nb[i, j] = 1;
                        else
                        {
                            if (n == 3) nb[i, j] = 1;
                            else nb[i, j] = 0;
                        }
                    }
                    else nb[i, j] = 0;
                }

            b = nb;
            Console.WriteLine();
            Console.ReadLine();
        }

        static int DoThing(int j, int[,] b, int i, int n)
        {
            if (j != 0)
            {
                if (b[i, j - 1] == 1) n++;
                if (i != 10 && b[i + 1, j - 1] == 1) n++;
            }

            return n;
        }
    }

    class Foo
    {
        public static void Bar(int n, int[,] nb, int i, int j)
        {
            if (n == 3) nb[i, j] = 1;
            else nb[i, j] = 0;
        }

        public static void Bar2(int n, int[,] nb, int i, int j)
        {
            if (n == 3) nb[i, j] = 1;
            else nb[i, j] = 0;
        }
    }
}
