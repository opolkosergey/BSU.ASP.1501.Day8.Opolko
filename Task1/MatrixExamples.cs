using System;

namespace Task1
{
    public class DiagonalMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public DiagonalMatrix(T[][] _numbers)
        {
            if(_numbers == null)
                throw new ArgumentNullException();
            if(!IsInputCorrectly(_numbers))
                throw new Exception("Invalid parameter for this type" + nameof(_numbers));
            numbers = _numbers.Copy();
        }

        public override void SetElement(int i, int j, T element)
        {
            if(i != j)
                throw new InvalidOperationException();
            numbers[i][i] = element;
            OnElementChanged(i,j);
        }

        public override sealed bool IsInputCorrectly(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                for (int j = 0; j < inputs[i].Length; j++)

                    if (i != j && inputs[i][j].CompareTo(default(T)) != 0)
                        return false;

            return true;
        }
    }

    public class SquareMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SquareMatrix(T[][] _numbers)
        {
            if (_numbers == null)
                throw new ArgumentNullException();
            if (!IsInputCorrectly(_numbers))
                throw new Exception("Invalid parameter for this type" + nameof(_numbers));
            numbers = _numbers.Copy();
        }

        public override void SetElement(int i, int j, T element)
        {
            numbers[i][j] = element;
            OnElementChanged(i,j);
        }

        public override sealed bool IsInputCorrectly(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                if (inputs[i].Length != inputs.Length)
                    return false;
            return true;
        }
    }

    public class SimmetricMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        public SimmetricMatrix(T[][] _numbers)
        {
            if (_numbers == null)
                throw new ArgumentNullException();
            if (!IsInputCorrectly(_numbers))
                throw new Exception("Invalid parameter for this type" + nameof(_numbers));
            numbers = _numbers.Copy();
        }

        public override void SetElement(int i, int j, T element)
        {
            numbers[i][j] = element;
            numbers[j][i] = element;
            OnElementChanged(i,j);
        }

        public override sealed bool IsInputCorrectly(T[][] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
                for (int j = 0; j < i; j++)

                    if (inputs[i][j].CompareTo(inputs[j][i]) != 0)
                        return false;

            return true;
        }
    }
}
