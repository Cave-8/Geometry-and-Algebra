using System;

namespace Classificazione_coniche
{
    class Program
    {
        static void Main(string[] args)
        {
            int x2, y2, xy, x, y, c;
            Console.WriteLine("Programma per classificazione conica\n");
            Console.WriteLine("Inserire termine X^2, Y^2, XY, X, Y e C");
            x2 = Int32.Parse(Console.ReadLine());
            y2 = Int32.Parse(Console.ReadLine());
            xy = Int32.Parse(Console.ReadLine());
            x = Int32.Parse(Console.ReadLine());
            y = Int32.Parse(Console.ReadLine());
            c = Int32.Parse(Console.ReadLine());

            Conica eq = new Conica(x2, y2, xy, x, y, c);
            Conica.PlotEquation(eq);
            Conica.Classification(eq);
        }
    }

    class Conica
    {
        int x2 { get; set; }
        int y2 { get; set; }
        int xy { get; set; }
        int x { get; set; }
        int y { get; set; }
        int c { get; set; }
        int[,] A = new int[2, 2]; //Matrix A
        int[,] B = new int[1, 2]; //Matrix B
        int[,] C = new int[3, 3]; //Matrix C
        int I1, I2, I3;

        public Conica (int a2, int b2, int ab, int a, int b, int C) //Constructor
        {
            x2 = a;
            y2 = b;
            xy = ab;
            x = a;
            y = b;
            c = C;
        }

        public static void MFilling (Conica con)    //Filling of 3 matrices
        {
            con.A[0, 0] = con.x2;
            con.A[0, 1] = con.xy;
            con.A[1, 0] = con.xy;
            con.A[1, 1] = con.y2;

            con.B[0, 0] = con.x;
            con.B[0, 1] = con.y;

            con.C[0, 0] = con.A[0, 0];
            con.C[0, 1] = con.A[0, 1];
            con.C[1, 0] = con.A[1, 0];
            con.C[1, 1] = con.A[1, 1];
            con.C[0, 2] = con.B[0, 0];
            con.C[1, 2] = con.B[0, 1];
            con.C[2, 0] = con.B[0, 0];
            con.C[2, 1] = con.B[0, 1];
            con.C[2, 2] = con.c;
        }

        public static void Invariants (Conica con)  //Invariants calculation
        {
            int i;

            con.I1 = con.A[0, 0] + con.A[1, 1];
            con.I2 = con.A[0, 0] * con.A[1, 1] - (2 * con.A[0, 1]);
            for (i = 0; i < 3; i++)
                con.I3 += (con.C[0, i] * (con.C[1, (i + 1) % 3] * con.C[2, (i + 2) % 3] - con.C[1, (i + 2) % 3] * con.C[2, (i + 1) % 3]));
        }

        public static void Classification (Conica con)
        {
            MFilling(con);
            Invariants(con);
            if (con.I3 != 0)
            {
                if (con.I2 > 0)
                {
                    if (con.I1 * con.I3 < 0)
                        Console.WriteLine("La conica è un ellisse con punti reali\n");
                    else if (con.I1 * con.I3 > 0)
                        Console.WriteLine("La conica è un ellisse privo di punti reali\n");
                }
                else
                {
                    if (con.I2 < 0)
                        Console.WriteLine("La conica è un'iperbole\n");
                    else if (con.I2 == 0)
                        Console.WriteLine("La conica è una parabola\n");
                }
            }
            else
            {
                if (con.I2 > 0)
                    Console.WriteLine("La conica è degenere ed è una coppia di rette incidenti con un unico punto reale\n");
                else
                {
                    if (con.I2 == 0)
                        Console.WriteLine("La conica è degenere ed è una coppia di rette parallele o retta doppia\n");
                    else 
                        Console.WriteLine("La conica è degenere ed è una coppia di rette incidenti con infiniti punti reale\n");
                }
            }
        }

        public static void PlotEquation (Conica con)
        {
            Console.WriteLine($"L'equazione è {con.x2}X^2 + {con.y2}Y^2 + {con.xy}XY + {con.x}X + {con.y}Y + {con.c} = 0\n");
        }
    }
}
