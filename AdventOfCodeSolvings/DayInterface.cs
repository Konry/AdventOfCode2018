using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public interface DayInterface<TA, TB>
    {
        TA RunPartA(List<string> input);
        TB RunPartB(List<string> input);
    }
}
