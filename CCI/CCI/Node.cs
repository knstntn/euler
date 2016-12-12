using System.Collections;
using System.Collections.Generic;

namespace CCI
{
    public class Node<T> : IEnumerable<Node<T>>
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

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private sealed class NodeEnumerator : IEnumerator<Node<T>>
        {
            private readonly Node<T> _root;

            public NodeEnumerator(Node<T> root)
            {
                _root = root;
                Current = null;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (Current == null)
                {
                    Current = _root;
                    return true;
                }

                if (Current?.Next == null)
                {
                    return false;
                }

                Current = Current.Next;

                return true;
            }

            public void Reset()
            {
                Current = null;
            }

            public Node<T> Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}