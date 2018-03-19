using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._11._17_Generics_Collections
{
    class Stack_dynamic<T>
    {
        public bool IsEmpty { get { return Count == 0; } }
        public int Count { get; set; }    // кол-во эл-тов в стеке по факту
        private T[] stack_mass;           // эл-ты стека

        private const int n = 10;         // кол-во эл-тов в стеке которое будет задаваться в конструкторе по умолчанию

        public Stack_dynamic()
        { stack_mass = new T[n]; }

        public Stack_dynamic(int length)
        { stack_mass = new T[length]; }

        private void Resize(int max)
        {
            T[] tempStack = new T[max];
            for (int i = 0; i < Count; i++)
            {
                tempStack[i] = stack_mass[i];
                stack_mass = tempStack;
            }
        }

        public void Push(T element)
        {
            // если достигнута максимальная емкость стека, и помещать новый элемент некуда
            if (Count == stack_mass.Length) Resize(stack_mass.Length + 10);
            stack_mass[Count++] = element;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            T new_stack_mass = stack_mass[--Count];
            stack_mass[Count] = default(T);      // сброс ссылки удаляемого эл-та

            // Если в стеке образовалось более 10 пустых, то изменяем его размер в сторону уменьшения
            if (Count > 0 && Count < stack_mass.Length - 10) Resize(stack_mass.Length - 10);
            
            return new_stack_mass;               // возврат нового (массива)стэка, без удаленного эл-та
        }

        // возвращаем эл-т из вершушки стека
        public T Peek() { return stack_mass[Count - 1]; }
    }
}
