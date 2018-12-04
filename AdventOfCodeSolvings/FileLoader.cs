using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolvings
{
    public class FileLoader
    {
        public static List<string> LoadLinesFromFile(string pathToFile)
        {
            var streamReader = new StreamReader(System.Reflection.Assembly.GetExecutingAssembly().Location + pathToFile);
            var readResult = new List<string>();

            //string line = streamReader.ReadLine();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                readResult.Add(line);
            }

            return readResult;
        }
    }
}
