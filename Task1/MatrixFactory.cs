using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class MatrixFactory
    {
        public static Matrix<T> GetMatrix<T>(T[][] values, Type type) where T : struct, IComparable<T>
        {
            if(type == typeof(DiagonalMatrix<T>))
                return new DiagonalMatrix<T>(values);
            if (type == typeof(SimmetricMatrix<T>))
                return new SimmetricMatrix<T>(values);
            return new SquareMatrix<T>(values);
        } 
    }
}
