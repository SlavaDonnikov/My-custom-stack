using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Стэк на основе односвязного списка
namespace _25._11._17_Generics_Collections
{   
    // Класс элемента стека
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        { Data = data; }
    }

    class Node_Stack<T> : IEnumerable<T>
    {
        Node<T> head;       

        public int Count { get; set; }    
        public bool IsEmpty { get { return Count == 0; } }

        public void Push(T element)
        {
            Node<T> node = new Node<T>(element);
            node.Next = head;                       // переустанавливаем верхушку стека на новый элемент (который сейчас добавили), т.е. этот элемент - вершина.
            head = node;                            // устанавливаем переменной вершины этот элемент
            Count++;                                // увеличиваем счетчик эл-тов стека
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");

            Node<T> temp = head;
            head = head.Next;           // переустанавливаем верхушку стека на новый элемент
            Count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
