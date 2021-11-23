using System;
using System.Collections.Generic;
using System.Text;

namespace External_Sort
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AskUserForSort();
        }

        static void AskUserForSort()
        {
            string nameFile = null;
            string attributeName = null;
            string ascendingString = "1";
            string sorterType = "2";
            UserInteerfase.AskUser(ref nameFile, ref attributeName, ref ascendingString, ref sorterType);
            TableWorker inputTable = new TableWorker(nameFile + ".csv");
            string outputFile = nameFile + "Sorted.csv";
            bool ascending = int.Parse(ascendingString) == 1;
            SortType sortType = (SortType)(int.Parse(sorterType) - 1);

            Condition condition = UserInteerfase.AskCondition(inputTable);

            if (condition != null)
                inputTable = TableWorker.GetFilteredTable(inputTable, "temp.txt", condition);

            inputTable.GetSortedTable(outputFile, ascending, attributeName, sortType);
        }
        
    }
}
