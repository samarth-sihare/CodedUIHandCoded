using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUIHandCoded
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class SequenceAttribute : Attribute
    {
        private int order;

        public int Order
        {
            get { return order; }
        }

        public SequenceAttribute(int i)
        {
            order = i;

        }
    }
    public sealed class RequiresAttribute : Attribute
    {
        private string priorTestMethod;

        public string PriorTestMethod
        {
            get { return priorTestMethod; }
        }

        public RequiresAttribute(string methodName)
        {
            priorTestMethod = methodName;
        }
    }
    
}
