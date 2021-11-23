using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_Sort
{
    delegate bool ConditionDelegate(IComparable value);
    class Condition
    {
        string Attribute { get; }
        int attributeNum;
        ConditionDelegate function;
        TableWorker table;

        public Condition(TableWorker table, string attribute, ConditionDelegate conditionFunction)
        {
            Attribute = attribute;
            function = conditionFunction;
            attributeNum = Array.IndexOf(table.Attributes, Attribute);
            this.table = table;
        }

        public bool Satisfies(Element[] elements)
        {
            return function((IComparable)elements[attributeNum].Value);
        }
    }
}
