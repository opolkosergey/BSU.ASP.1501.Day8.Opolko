using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    public abstract class Matrix<T> where T : struct, IComparable<T> 
    {
        protected T[][] numbers;

        public event EventHandler ElementChanged;

        public delegate void EventHandler(object sender, ElementEventArgs e);

        public T this[int i, int j] => numbers[i][j];

        public abstract void SetElement(int i, int j, T element);
        
        public int Size() => numbers.Length;

        public abstract bool IsInputCorrectly(T[][] inputs);
        protected void OnElementChanged(int i , int j)
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
