using System;
using System.Collections.Generic;
using System.Text;

public class Sorter
{
    public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j].CompareTo(list[j + 1]) > 0)
                {
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}
