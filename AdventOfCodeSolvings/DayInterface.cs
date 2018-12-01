using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public interface DayInterface<T>
    {
        T RunPartA(List<string> input);
        T RunPartB(List<string> input);
    }
}
