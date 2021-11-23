using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_Sort
{
    static class UserInteerfase
    {
        public static void AskUser(ref string nameFile, ref string attributeName,
            ref string ascending, ref string sorterType)
        {
            Console.WriteLine("Введите имя файла для сортировки");
            nameFile = Console.ReadLine();
            Console.WriteLine("Введите название столбца для сортировки");
            attributeName = Console.ReadLine();
            Console.WriteLine("Введите порядок сортировки: 1 - по возрастанию, 2 - по убыванию");
            ascending = Console.ReadLine();
            Console.WriteLine("Введите тип сортировки: 1 - прямая, 2 - натуральная, 3 - многопутевая");
            sorterType = Console.ReadLine();
        }

        public static Condition AskCondition(TableWorker table)
        {
            Console.Write("В каком столбце зададим условие (если нет условия нажмите Enter): ");
            string conditionAttributeName = Console.ReadLine();

            if (conditionAttributeName.Length != 0)
            {
                Console.Write("Введите условие (например x < 5): ");
                string textOfFunction = Console.ReadLine();

                string[] words = ParseLine(textOfFunction);
                IComparable operand = GetOpernd(words[2]);

                ConditionDelegate function = GetFunction(words[1], operand);

                return new Condition(table, conditionAttributeName, function);
            }
            else
            {
                return null;
            }

            string[] ParseLine(string line)
            {
                return line.Split(); 
            }
            IComparable GetOpernd(string operand)
            {
                if (int.TryParse(operand, out int result))
                    return result;
                else
                    return operand;
            }
            ConditionDelegate GetFunction(string operatorStr, IComparable operand)
            {
                switch (operatorStr)
                {
                    case ">":
                        return (value) => { return value.CompareTo(operand) == 1; };
                    case "<":
                        return (value) => { return value.CompareTo(operand) == -1; };
                    case "=":
                    case "==":
                        return (value) => { return value.CompareTo(operand) == 0; };
                    case ">=":
                        return (value) => { return value.CompareTo(operand) != -1; };
                    case "<=":
                        return (value) => { return value.CompareTo(operand) != 1; };
                    default:
                        throw new Exception("Некорректные данные");
                }
            }
        }
    }
}
