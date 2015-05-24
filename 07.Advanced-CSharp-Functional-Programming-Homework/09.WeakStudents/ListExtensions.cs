using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakStudents
{
    public static class ListExtensions
    {
        public static bool CheckIfListContainsTwoMarksOfTwo(this List<int> marks)
        {
            int count = 0;
            foreach (var mark in marks)
            {
                if (mark == 2)
                {
                    count++;
                }
                if (count > 2)
                {
                    break;
                }
            }

            if (count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
