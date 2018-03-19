using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._11._17_Generics_Collections
{
    class Stack_static<T>
    {
        public bool IsEmpty { get { return Count == 0; } }
        public int Count { get; set; }    // кол-во эл-тов в стеке по факту
        private T[] stack_mass;           // эл-ты стека

        private const int n = 10;         // кол-во эл-тов в стеке которое будет задаваться в конструкторе по умолчанию

        public Stack_static()
        { stack_mass = new T[n]; }

        public Stack_static(int length)
        { stack_mass = new T[length]; }

        public void Push(T element)
        {
            // если достигнута максимальная емкость стека, и помещать новый элемент некуда
            if (Count == stack_mass.Length) throw new InvalidOperationException("Переполнение стека");
            stack_mass[Count++] = element;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            T new_stack_mass = stack_mass[--Count];
            stack_mass[Count] = default(T);      // сброс ссылки удаляемого эл-та
            return new_stack_mass;               // возврат нового (массива)стэка, без удаленного эл-та
        }

        // возвращаем эл-т из вершушки стека
        public T Peek() { return stack_mass[Count - 1]; }
    }
}
