using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSSDK_DotNet35.UnitTests.TestTools
{
    internal class TypeCircularReference<T>
    {
        Stack<T> stack = new Stack<T>();
        HashSet<T> hash = new HashSet<T>();

        public bool Push(T type)
        {
            if (hash.Contains(type))
                return false;

            stack.Push(type);
            hash.Add(type);


            return true;
        }

        public void Pop()
        {
            var type = stack.Pop();
            hash.Remove(type);
        }

        public bool Contains(T type)
        {
            return hash.Contains(type);
        }
    }
}
