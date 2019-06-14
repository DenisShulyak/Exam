using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    [Synchronization]
    public class RecordArray : ContextBoundObject
    {

        public int[] Array { get; set; }
        public int index = 0;
        public void WriteToArray()//Запись в массив
        {
            Array[index] = index;

            index++;
        }

    }
}
