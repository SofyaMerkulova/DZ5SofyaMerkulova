using System;
using System.Security.Cryptography;

namespace Tumakov_lab6
{
    internal class Program
    {
        static void TaskThird()
        {
            /*Упражнение 6.3 Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур. Полученный массив средних температур отсортировать по
            возрастанию.*/
            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = new int[12, 30];
            Random randMonth = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int days = 0; days < 30; days++)
                {
                    temperature[i, days] = randMonth.Next(-25, +35);
                }
            }
            double[] temp = AvergeTemperature(temperature);
            Array.Sort(temp);
            Console.WriteLine($"Средняя температура для каждого месяца: ");
            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine($"Номер месяца:{ i+1 }: {temp[i]:F0} градусов");
            }
        }
        static double[] AvergeTemperature (int[,] temperature)
        {
            double [] result = new double[12];
            int answer = 0;
            for (int i = 0; i < 12; i++)
            { 
                for (int days = 0; days < 30; days++)
                {
                    answer += temperature[i, days];
                }
                result[i] = answer/30.0;
            }
            return result;
        }
        static void Print(int[,] matrix)
        {
            /*Упражнение 6.2 Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).*/
            Console.WriteLine (" ");
            Console.WriteLine("Упражнение 6.2");
            int columns = matrix.GetLength(1);
            int lines = matrix.GetLength(0);
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine(matrix[i, j]);
                }
            }
        }
        static int[,] Multiplication(int[,] matrixFirst, int[,] matrixSecond)
        {
            int linesFirst = matrixFirst.GetLength(0);
            int columnsFirst = matrixFirst.GetLength(1);
            int columnsSecond = matrixSecond.GetLength(1);
            int linesSecond = matrixSecond.GetLength(0);
            int[,] result = new int[linesFirst, columnsSecond];
            for (int i = 0; i < linesFirst; i++)
            {
                for (int j = 0; j < columnsSecond; j++)
                {
                    result[i, j] = 0;
                    for (int n = 0; n < columnsFirst; n++)
                    {
                        result[i, j] += matrixFirst[i, n] * matrixSecond[n, j];
                    }
                }
            }
            return result;
        }
        static void TaskSecond()
        {
            int[,] matrixFirst = {
            { 9, 8, 8 },
            { 4, 5, 9 }
        };
            int[,] matrixSecond = {
            {9, 7},
            {4, 5},
            {3, 2}
        };
            int[,] resultMatrix = Multiplication(matrixFirst, matrixSecond);
            Console.WriteLine("Результат умножения: ");
            Print(resultMatrix);
        }
        static void Main(string[] args)
        {
                TaskThird();
                TaskSecond();
        }
    }
}


    
