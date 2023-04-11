using MathNet.Numerics.LinearAlgebra;

List<int> t1 = new List<int>();
List<int> t2 = new List<int>();
List<double> t3 = new List<double>();
int r = 0;
double k_mo_mij = 0;
Console.WriteLine("Nermucel gagatneri tiv@");
int n = int.Parse(Console.ReadLine());

//int[,] matrix = new int[,] { { 1, 2 }, { 1, 12 }, { 1, 16 }, { 1, 17 }, { 2, 11 }, { 2, 14 }, { 3, 6 }, { 4, 19 }, { 5, 7 }, { 6, 14 }, { 7, 0 }, { 8, 0 }, { 9, 0 }, { 10, 0 }, { 11, 18 }, { 12, 8 }, { 12, 19 }, { 13, 3 }, { 13, 11 }, { 13, 9 }, { 13, 15 }, { 14, 7 }, { 15, 19 }, { 16, 9 }, { 16, 10 }, { 17, 18 }, { 18, 0 }, { 19, 0 }, { 13, 4 }, { 13, 5 }, { 9, 19 } };
int[,] matrix = new int[,] { { 1, 9 }, { 2, 5 }, { 2, 4 }, { 3, 6 }, { 3, 8 }, { 3, 13 }, { 4, 7 }, { 4, 14 }, { 6, 10 }, { 7, 10 }, { 8, 16 }, { 9, 0 }, { 10, 0 }, { 11, 15 }, { 11, 12 }, { 12, 14 }, { 13, 17 }, { 14, 9 }, { 15, 8 }, { 15, 18 }, { 16, 0 }, { 17, 0 }, { 18, 16 }, { 5, 6 } };
double[,] matrix1 = AMatrix(matrix, n, out r);

static void CMatrix(double[,] matrix)
{
    Console.WriteLine("Enter i | j");
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLongLength(1); j++)
        {

            matrix[i, j] = int.Parse(Console.ReadLine());
        }
    }
}

Console.WriteLine("i | j");
for (int i = 0; i < matrix.GetLongLength(0); i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.Write($"{matrix[i, j]}  ");
    }
    Console.WriteLine();
}

static int T6(int[,] matrix, List<double> ints)
{
    int count = 0;
    for (int j = 0; j < matrix.GetLongLength(0); j++)
    {
        if (ints.Contains(matrix[j, 0]) && matrix[j, 1] != 0)
        {
            count++;
        }
    }
    return count;
}
static int T5(double[,] matrix, List<int> t2)
{
    int count = 0;
    for (int i = 0; i < t2.Count; i++)
    {
        int x = t2[i] - 1;
        for (int j = i + 1; j < t2.Count; j++)
        {
            int y = t2[j] - 1;
            if (matrix[x, y] == 1)
            {
                count++;
            }
            if (matrix[y, x] == 1)
            {
                count++;
            }
        }
    }
    return count;
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
        if (count == 0 && !t1.Contains(num))
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
        if (count >= 1 && !t2.Contains(num))
            t2.Add(num);
    }
    return t2;
}
static List<double> T3(int[,] matrix)
{
    List<double> t3 = new List<double>();
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
double[,] AMatrix(int[,] matrix, int n, out int r)
{
    r = 0;
    double[,] matrix2 = new double[n, n];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, 1] != 0)
        {
            r++;
        }
        if (matrix[i, 1] == 0)
            continue;
        matrix2[matrix[i, 0] - 1, matrix[i, 1] - 1] = 1;
    }
    return matrix2;
}

Console.WriteLine();
Matrix<double> matrix2 = null;
Matrix<double> sumMatrix = null;
int count = 1;
int q = 1;
double[,] sumM = new double[n, n];
double[,] A = matrix1;
do
{
    sumM = SumMatrix(sumM, A).ToArray();
    double[,] B = matrix1;
    PrintMatrix(A);
    int t4 = T4(A);
    Console.WriteLine($"t4({q})={t4}");
    int t7 = t4 - count;
    Console.WriteLine($"t7({q}) = {t7}");
    Console.WriteLine($"k_mo = {(double)t7 / t4}");
    k_mo_mij += (double)t7 / t4;
    q++;
    matrix2 = Multiply(A, B);

    A = matrix2.ToArray();
    count++;
}
while (!ifMatrixEqualZero(matrix2) && CheckDiagonal(A));
Console.WriteLine($"karg A = {count - 1}");
int t6 = T6(matrix, t3);
int t5 = T5(matrix1, t2);
Console.WriteLine($"t5={t5}");
Console.WriteLine($"t6 = {t6}");
Console.WriteLine($"K(krk) = {(double)2 * t6 / (t3.Count * (t3.Count - 1))}");
Console.WriteLine($"K(n_nk)={(double)t5 / r}");
Console.WriteLine($"K(m) ={(double)t2.Count / n}");
Console.WriteLine($"k_mo_mij={k_mo_mij / (count - 1)}");

Console.WriteLine("Sum of all Matix");
for (int i = 0; i < matrix1.GetLongLength(0); i++)
{
    for (int j = 0; j < matrix1.GetLongLength(0); j++)
    {
        Console.Write($"{sumM[i, j]} ");
    }
    Console.WriteLine();
}
static bool CheckDiagonal(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, i] == 1)
            return false;

    }
    return true;

}

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
static Matrix<double> SumMatrix(double[,] matrix1, double[,] matrix2)
{
    Matrix<double> matrix = Matrix<double>.Build.DenseOfArray(matrix1);
    Matrix<double> matrix3 = Matrix<double>.Build.DenseOfArray(matrix2);

    return matrix.Add(matrix3);
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

