using System;

namespace Task1
{
    public class DiagonalMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public DiagonalMatrix(T[][] _numbers) : base(_numbers, typeof(DiagonalMatrix<T>))
        {
        } 
    }

    public class SquareMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SquareMatrix(T[][] _numbers) : base(_numbers, typeof(SquareMatrix<T>))
        {
        }
    }

    public class SimmetricMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SimmetricMatrix(T[][] _numbers) : base(_numbers, typeof(SimmetricMatrix<T>))
        {
        }
    }


}
