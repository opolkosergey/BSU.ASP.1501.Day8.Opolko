using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class MatrixSummator
    {
        public static Matrix<T> SumWith<T>(this Matrix<T> matrix, Matrix<T> other) where T : struct, IComparable<T>
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (matrix.GetType() != other.GetType() || matrix.Size() != other.Size())
                throw new InvalidOperationException();

            var n = matrix.Size();
            T[][] newMatrixValues = new T[n][];
            for (int i = 0; i < n; i++)
                newMatrixValues[i] = new T[n];

            try
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        newMatrixValues[i][j] = (dynamic)matrix[i, j] + other[i, j];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MatrixFactory.GetMatrix(newMatrixValues, matrix.GetType());
        }

        public static T[][] Copy<T>(this T[][] array)
        {
            int n = array.Length;
            T[][] copy = new T[n][];
            for (int i = 0; i < n; i++)
                copy[i] = new T[n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    copy[i][j] = array[i][j];
            return copy;
        }
    }
}
