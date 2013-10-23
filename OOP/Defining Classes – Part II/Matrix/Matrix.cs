//Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
//Implement an indexer this[row, col] to access the inner matrix cells.
//Implement the operators + and - (addition and subtraction of matrices 
//of the same size) and * for matrix multiplication. Throw an exception when
//the operation cannot be performed. 

//Implement the true operator (check for non-zero elements).


using System;
using System.Text;

public class Matrix<T> where T : IComparable, new()
{
    //field
    public readonly int Cols;
    public readonly int Rows;
    private readonly T[,] matrix;

    //constructor
    public Matrix(int cols, int rows) 
    {
        this.Cols = cols;
        this.Rows = rows;
        this.matrix = new T[cols, rows];
    }

    //indexer
    public T this[int row, int col]
    {
        get
        {
            if (row < 0 || col < 0 || row >= this.Rows || col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Out of the matrix!");
            }
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }

    //override methods
    public static Matrix<T> operator + (Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Cols; j++)
                {
                    dynamic containerOne = firstMatrix[i, j];
                    dynamic containerTwo = secondMatrix[i, j];
                    resultMatrix[i, j] = containerOne + containerTwo;
                }
            }
        }
        else
        {
            throw new ArgumentException("For summary matrixes, they must be equal!");
        }

        return resultMatrix;
    }

    public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);
        if (firstMatrix.Cols == secondMatrix.Cols && firstMatrix.Rows == secondMatrix.Rows)
        {
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Cols; j++)
                {
                    dynamic containerOne = firstMatrix[i, j];
                    dynamic containerTwo = secondMatrix[i, j];
                    resultMatrix[i, j] = containerOne - containerTwo;
                }
            }
        }
        else
        {
            throw new ArgumentException("For substraction matrixes, they must be equal!");
        }

        return resultMatrix;
    }

    public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
    {
        Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);            
        if (firstMatrix.Rows == secondMatrix.Cols)
        {
            for (int i = 0; i < resultMatrix.Rows; i++)
            {
                for (int j = 0; j < resultMatrix.Cols; j++)
                {
                    for (int k = 0; k < resultMatrix.Cols; k++)
                    {
                        dynamic containerOne = firstMatrix[i, j];
                        dynamic containerTwo = secondMatrix[i, j];
                        resultMatrix[i, j] = containerOne * containerTwo;
                    }
                }
            }
        }
        else
        {
            throw new ArithmeticException(
     "Can not multiply, rows of first matrix aren't equal to the columns of the second");       
        }

        return resultMatrix;
    }

    public static bool operator true(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                if (matrix[i, j].CompareTo(new T()) == 0)
                {
                    //zero element
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                if (matrix[i, j].CompareTo(new T()) == 0)
                {
                    //zero element
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        
        for (int i = 0; i < this.Rows; i++)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                str.AppendFormat("{0,5}", this[i, j]);
            }

            str.AppendLine();
        }

        return str.ToString();
    }
}

