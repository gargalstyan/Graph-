double[,] matrix = new double[,] { { 1, 2, 4 }, { 1, 12, 2 }, { 1, 16, 3 }, { 1, 17, 2 }, { 2, 11, 1 }, { 2, 14, 5 }, { 3, 6, 7 }, { 4, 19, 5 }, { 5, 7, 5 }, { 6, 14, 2 }, { 7, 19, 6 }, { 8, 19, 2 }, { 9, 19, 6 }, { 10, 19, 1 }, { 11, 18, 7 }, { 12, 8, 5 }, { 12, 19, 3 }, { 13, 3, 6 }, { 13, 11, 7 }, { 13, 9, 6 }, { 13, 15, 2 }, { 14, 7, 4 }, { 15, 19, 9 }, { 16, 9, 4 }, { 16, 10, 5 }, { 17, 18, 4 }, { 18, 19, 11 }, { 13, 4, 7 }, { 13, 5, 8 }, { 9, 19, 5 }, { 1, 13, 3 } };
//double[,] matrix = new double[,] { { 1, 2, 5 }, { 1, 3, 6 }, { 2, 3, 7 }, { 2, 4, 1 }, { 3, 5, 8 }, { 4, 5, 8 }, { 4, 6, 8 }, { 5, 6, 2 } };
List<double> way = new List<double>();
Console.WriteLine("Gagatneri tiv@");
int n = int.Parse(Console.ReadLine());
Console.WriteLine(GetMinWay(matrix));
way.ForEach(Console.WriteLine);
double GetMinWay(double[,] matrix)
{
    double num = T1(matrix);
    way.Add(num);
    double waylength = 0;
    do
    {
        double currentWayLength = MinWay(num, matrix);
        waylength += currentWayLength;
        num = NextWay(currentWayLength, matrix, num);
        way.Add(num);

    }
    while (num != n);
    return waylength;
}
double MinWay(double num, double[,] matrix)
{
    List<double> minWays = new List<double>();

    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        double sum = 0;
        if (matrix[i, 0] == num)
        {
            sum += matrix[i, 2];
            minWays.Add(sum);
        }
    }
    return minWays.Min();
}

double NextWay(double length, double[,] matrix, double num)
{
    List<double> nextWays = new List<double>();
    double nextWay = 0;
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        if (matrix[i, 0] == num && matrix[i, 2] == length && !way.Contains(matrix[i, 1]))
        {
            nextWay = matrix[i, 1];
            nextWays.Add(nextWay);

        }
    }
    if (nextWays.Count > 1)
    {
        double way2 = MinWay(nextWays[0], matrix);
        nextWay = nextWays[0];
        for (int i = 1; i < nextWays.Count; i++)
        {
            double currentWay = MinWay(nextWays[i], matrix);
            if (way2  > currentWay)
            {
                way2 = currentWay;
                nextWay = nextWays[i];
            }
        }
    }
    return nextWay;
}

double T1(double[,] matrix)
{

    double t1 = 0;
    for (int i = 0; i < matrix.GetLongLength(0); i++)
    {
        int count = 0;
        double num = matrix[i, 0];
        for (int j = 0; j < matrix.GetLongLength(0); j++)
        {
            if (num == matrix[j, 1])
                count++;
        }
        if (count == 0)
        {
            t1 = matrix[i, 0];
            break;
        }

    }
    return t1;
}