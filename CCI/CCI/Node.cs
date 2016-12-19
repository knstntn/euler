using System.Collections.Generic;

namespace CCI
{
    public class Node<T>
    {
        public Node()
        {
        }

        public Node(T data) : this(data, null)
        {
        }

        public Node(T data, Node<T> next)
        {
            Next = next;
            Data = data;
        }

        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public IEnumerable<Node<T>> AsEnumerable()
        {
            var tmp = this;
            while (tmp != null)
            {
                yield return tmp;

                tmp = tmp.Next;
            }
        }
    }
}