using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    public abstract class Matrix<T> where T : struct, IComparable<T> 
    {
        protected T[][] numbers;

        public event ElementChangedEventHandler ElementChanged;

        public delegate void ElementChangedEventHandler(object sender, ElementEventArgs e);
        protected Matrix(T[][] _numbers, Type type)
        {
            if(_numbers == null)
                throw new ArgumentNullException(nameof(_numbers));

            if (GetTypeMatrix(_numbers) == type && IsSqMatrix(_numbers))
                numbers = _numbers;
            else
            throw new Exception("Invalid parameter for this type" + nameof(_numbers));
        }

        public void SetElement(int i, int j, T element)
        {
            if (i != j && GetTypeMatrix(numbers) == typeof(DiagonalMatrix<T>))
                throw new InvalidOperationException();
            if (GetTypeMatrix(numbers) == typeof(SimmetricMatrix<T>))
                numbers[j][i] = element;
            numbers[i][j] = element;
                OnElementChanged(i,j);
        }

        public T GetElement(int i, int j) => numbers[i][j];

        public int GetSize() => numbers.Length;
        
        public Type GetTypeMatrix(T[][] inputs)
        {
            if (IsDiagonalMatrix(inputs))
                return typeof (DiagonalMatrix<T>);

            if (IsSimmetricMatrix(inputs))
                return typeof(SimmetricMatrix<T>);

            if (IsSqMatrix(inputs))
                return typeof(SquareMatrix<T>);

            return null;
        }

        private bool IsSimmetricMatrix(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                for (int j = 0; j < i; j++)

                    if ( inputs[i][j].CompareTo(inputs[j][i]) != 0)
                        return false;

            return true;
        }

        private bool IsDiagonalMatrix(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                for (int j = 0; j < inputs[i].Length; j++)

                    if (i != j && inputs[i][j].CompareTo(default(T)) != 0)
                        return false;

            return true;
        }

        private bool IsSqMatrix(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                if (inputs[i].Length != inputs.Length)
                    return false;
            return true;
        }

        private void OnElementChanged(int i , int j)
        {
            ElementChanged?.Invoke(this, new ElementEventArgs(i,j));
        }
    }

    public class ElementEventArgs : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }
        public ElementEventArgs(int _i, int _j)
        {
            i = _i;
            j = _j;
        }
    }
}
