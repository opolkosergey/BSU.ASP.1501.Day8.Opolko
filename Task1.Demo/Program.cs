using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Demo
{
   
    public class User
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }
        public void Subscribed(object sender, ElementEventArgs e)
        {
            Console.WriteLine("Элемент в позиции {0}-{1} был изменен. User {2} уведомлен",e.i,e.j, Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[][] dm ={
                            new int[] {1,0,0}, new int[] {0,6,0}, new int[] {0,0,1}
                        };

            var diagonalMatrix = new DiagonalMatrix<int>(dm);
            var u1 = new User("Alex");
            var u2 = new User("John");
            diagonalMatrix.ElementChanged += u1.Subscribed;
            diagonalMatrix.ElementChanged += u2.Subscribed;
            diagonalMatrix.SetElement(1,1,8);
        }
    }
}
