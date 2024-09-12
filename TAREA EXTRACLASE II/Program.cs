using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TAREA_EXTRACLASE_II;
// PROBLEMA #1: MEZCLAR EN ORDEN 
public class RetosListaEnlazadas
{
    public static IList<T> MergeSorted<T>(IList<T> listA, IList<T> listB, SortDirection direction) where T : IComparable<T>
    {
        // Resultant list
        List<T> mergedList = new List<T>();

        int indexA = 0;
        int indexB = 0;
        int countA = listA.Count;
        int countB = listB.Count;

        while (indexA < countA && indexB < countB)
        {
            int comparison = listA[indexA].CompareTo(listB[indexB]);

            if (direction == SortDirection.Asc)
            {
                if (comparison <= 0)
                {
                    mergedList.Add(listA[indexA++]);
                }
                else
                {
                    mergedList.Add(listB[indexB++]);
                }
            }
            else 
            {
                if (comparison <= 0)
                {
                    mergedList.Add(listB[indexB++]);
                }
                else
                {
                    mergedList.Add(listA[indexA++]); 
                }
            }
        }
        while (indexA < countA)
        {
            mergedList.Add(listA[indexA++]);
        }

        while (indexB < countB)
        {
            mergedList.Add(listB[indexB++]);
        }

        return mergedList;
    }

    public static void Main()
    {
        IList<int> listA = new List<int> { 1, 5, 6, 7 };
        IList<int> listB = new List<int> { 2, 8 };

        IList<int> mergedAscending = MergeSorted(listA, listB, SortDirection.Asc);
        Console.WriteLine("Merged Ascending: " + string.Join(", ", mergedAscending));

        IList<int> mergedDescending = MergeSorted(listA, listB, SortDirection.Desc);
        Console.WriteLine("Merged Descending: " + string.Join(", ", mergedDescending));
    }
}



