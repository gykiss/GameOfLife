using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Client.Services
{
    public static class TableExtensions
    {
        public static int[,] ToIntArray(this Models.Cell[,] table)
        {
            int[,] tableArray = new int[table.GetLength(0),table.GetLength(1)];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    tableArray[i,j] = table[i, j].live ? 1 : 0;
                }
            }
            return tableArray;
        }

        public static Models.Cell[,] ToCellArray(this int[,] table)
        {
            Models.Cell[,] tableArray = new Models.Cell[table.GetLength(0), table.GetLength(1)];
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    tableArray[i, j] = new Models.Cell();
                    tableArray[i, j].live = table[i, j] == 1 ? true : false;
                }
            }
            return tableArray;
        }
    }
}
