using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{

    [Serializable]
    public class NodeItem
    {
        public IList<char> NodeItems { get; }
        public IList<char> Prerequisites { get; }

        public NodeItem()
        {
            NodeItems = new List<char>();
            Prerequisites = new List<char>();
        }

        public NodeItem(List<char> nodeItems, List<char> prerequisites)
        {
            NodeItems = nodeItems .ToList();
            Prerequisites = prerequisites;
        }
    }

    public class Day07 : DayInterface<string, string>
    {
        public static Dictionary<char, NodeItem> DeepClone(Dictionary<char, NodeItem> obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult as Dictionary<char, NodeItem>;
        }

        public string RunPartA(List<string> input)
        {
            Dictionary<char, NodeItem> nodeDictionary = new Dictionary<char, NodeItem>();
            char first = char.MinValue;
            foreach (var item in input)
            {
                var split = item.Split(' ');
                var stepToBeFinished = split[1].ToCharArray()[0];
                var stepToBegin = split[7].ToCharArray()[0];

                if (!nodeDictionary.ContainsKey(stepToBeFinished))
                {
                    var ni = new NodeItem();
                    if (nodeDictionary.Count == 0)
                    {
                        first = stepToBeFinished;
                    }
                    ni.NodeItems.Add(stepToBegin);
                    nodeDictionary.Add(stepToBeFinished, ni);
                }
                else
                {
                    nodeDictionary[stepToBeFinished].NodeItems.Add(stepToBegin);
                }
                if (!nodeDictionary.ContainsKey(stepToBegin))
                {
                    nodeDictionary.Add(stepToBegin, new NodeItem());
                }
                nodeDictionary[stepToBegin].Prerequisites.Add(stepToBeFinished);
            }

            var endResult = "";
            //foreach (var item in nodeDictionary.OrderBy(x => x.Key))
            //{
            //    if (item.Value.Prerequisites.Count == 0)
            //    {
            //         endResult += item.Key;
            //    }
            //}
            var copy = DeepClone(nodeDictionary);
            foreach (var item in copy.OrderBy(x => x.Key))
            {
                if(item.Value.Prerequisites.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(item.Key);
                    GetRecousiveThroughDictionary(ref nodeDictionary, item.Key, char.MinValue, out string result);
                    endResult += result;
                }
            }
            //GetRecousiveThroughDictionary(ref nodeDictionary, 'U', char.MinValue, out string result);

            return endResult;
        }

        private void GetRecousiveThroughDictionary(ref Dictionary<char, NodeItem> copy, char toCheck, char parent, out string result)
        {
            result = "";
            var firstItem = copy[toCheck];

            if (firstItem.Prerequisites.Contains(parent))
            {
                firstItem.Prerequisites.Remove(parent);
            }
            if (firstItem.Prerequisites.Count == 0)
            {
                result += toCheck;
            }
            if (firstItem.NodeItems.Count > 0)
            {
                foreach (var item in firstItem.NodeItems.OrderBy(x => x))
                {
                    GetRecousiveThroughDictionary(ref copy, item, toCheck, out string resultRec);
                    result += resultRec;
                }
            }
        }

        public string RunPartB(List<string> input)
        {
            return "";
        }
    }
}
