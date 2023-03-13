﻿using MathNet.Numerics.LinearAlgebra;
int[,] ints = new int[4, 4];
int[,] ints1 = new int[4, 4];
List<int> t1 = new List<int>();
List<int> t2 = new List<int>();
List<int> t3 = new List<int>();

Console.WriteLine("Enter i | j");
int[,] matrix = new int[,] { { 1, 2 }, { 1, 12 }, { 1, 16 }, { 1, 17 }, { 2, 11 }, { 2, 14 }, { 3, 6 }, { 4, 19 }, { 5, 7 }, { 6, 14 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 18 }, { 12, 8 }, { 12, 19 }, { 13, 3 }, { 13, 11 }, { 13, 9 }, { 13, 15 }, { 14, 7 }, { 15, 19 }, { 16, 9 }, { 16, 10 }, { 17, 18 }, { 18, 0 }, { 19, 0 }, { 13, 4 }, { 13, 5 } };
//for (int i = 0; i < 28; i++)
//{
//    for (int j = 0; j < 2; j++)
//    {

//        matrix[i, j] = int.Parse(Console.ReadLine());
//    }
//}
Console.WriteLine("i | j");
for (int i = 0; i < 30; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.Write($"{matrix[i, j]}  ");
    }
    Console.WriteLine();
}
static List<int> T1(int[,] matrix)
{
    List<int> t1 = new List<int>();
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        int count = 0;
        int num = matrix[i, 0];
        for (int j = 0; j < matrix.GetLongLength(0); j++)
        {
            if (num == matrix[j, 1])
                count++;
        }
        if(count == 0 && !t1.Contains(num))
            t1.Add(num);
    }
    return t1;
}
static List<int> T2(int[,] matrix)
{
    List<int> t2 = new List<int>();
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        if (matrix[i, 1] == 0)
            continue;
        int count = 0;
        int num = matrix[i, 0];
        for (int j = 0; j < matrix.GetLongLength(0); j++)
        {
            if (num == matrix[j, 1])
                count++;
        }
        if (count >=1 && !t2.Contains(num))
            t2.Add(num);
    }
    return t2;
}
static List<int> T3(int[,] matrix)
{
    List<int> t3 = new List<int>();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int num = matrix[i, 0];
        if (matrix[i, 1] == 0)
        {
            t3.Add(num);
        }
    }
    return t3;
}
static int T4(double[,] matrix)
{
    int t4 = 0;
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        double sum = 0;

        for (int j = 0; j < matrix.GetLongLength(0); j++)
        {
            sum += matrix[j, i];
        }
        if (sum == 0)
            t4++;
    }
    return t4;
}
t1 = T1(matrix);
Console.WriteLine("t1 ");
for (int i = 0; i < t1.Count; i++)
{
    Console.WriteLine(t1[i]);
}
t2 = T2(matrix);
Console.WriteLine("t2 ");
for (int i = 0; i < t2.Count; i++)
{
    Console.WriteLine(t2[i]);
}
Console.WriteLine("t3");
t3 = T3(matrix);
for (int i = 0; i < t3.Count; i++)
{
    Console.WriteLine(t3[i]);
}
Console.WriteLine($"t1 = {t1.Count}");
Console.WriteLine($"t2 = {t2.Count}");
Console.WriteLine($"t3 = {t3.Count}");

double[,] matrix1 = new double[30, 30];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    if (matrix[i, 1] == 0)
        continue;
    matrix1[matrix[i, 0] - 1, matrix[i, 1] - 1] = 1;
}

Console.WriteLine();
Matrix<double> matrix2 = null;
int count = 1;
int q = 1;
double[,] A = matrix1;
do
{
    double[,] B = matrix1;
    PrintMatrix(A);
    int t4 = T4(A);
    Console.WriteLine($"t4({q})={t4}");
    int t7 = t4 - count;
    Console.WriteLine($"t7({q}) = {t7}");
    Console.WriteLine($"k_mo = {(double)t7/t4}");
    q++;
    matrix2 = Multiply(A, B);
    A = matrix2.ToArray();
    count++;
}
while (!ifMatrixEqualZero(matrix2));
Console.WriteLine($"A = {count - 1}");

static bool ifMatrixEqualZero(Matrix<double> matrix)
{
    for (int i = 0; i < matrix.RowCount; i++)
    {
        for (int j = 0; j < matrix.ColumnCount; j++)
        {
            if (matrix[i, j] != 0)
                return false;
        }
    }
    return true;
}
static Matrix<double> Multiply(double[,] matrix1, double[,] matrix2)
{
    Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(matrix1);
    Matrix<double> matrix3 = Matrix<double>.Build.DenseOfArray(matrix2);

    return matrix.Multiply(matrix3);
}

static void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLongLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

