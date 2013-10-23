using System;

namespace Matrix
{
    public class ValidationUnit
    {
        static void Main()
        {
            Matrix<int> firstMatrix = new Matrix<int>(5, 5);
            Matrix<int> secondMatrix = new Matrix<int>(5, 5);
            Console.WriteLine(firstMatrix.Cols);

            firstMatrix[0, 0] = 40;
            secondMatrix[0, 0] = 4;
            Console.WriteLine(firstMatrix+secondMatrix);
            Console.WriteLine();
            
            Console.WriteLine(firstMatrix - secondMatrix);
            Console.WriteLine(firstMatrix * secondMatrix);

            firstMatrix = firstMatrix + secondMatrix;
            secondMatrix = firstMatrix * secondMatrix;

            Console.WriteLine(secondMatrix - firstMatrix);
        }
    }
}
