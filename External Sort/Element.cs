using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_Sort
{
    struct Element : IComparable
    {
        public object Value { get; }
        public ColumnType Type { get; }
        public Element(string value, ColumnType type)
        {
            Type = type;
            switch (type)
            {
                case ColumnType.Integer:
                    Value = int.Parse(value);
                    break;
                case ColumnType.String:
                    Value = value;
                    break;
                default:
                    throw new Exception("Тип не реализован");
            }
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() == typeof(Element))
            {
                Element otherElement = (Element)obj;
                if (Type == otherElement.Type)
                {
                    IComparable value1 = (IComparable)Value;
                    IComparable value2 = (IComparable)otherElement.Value;
                    return value1.CompareTo(value2);
                }
                else
                {
                    throw new Exception("Попытка сравнить элементы, хронящие разные типы данных");
                }
            }
            else
            {
                throw new Exception("Нельзя сравнить с другими типами");
            }
        }
    }
}
