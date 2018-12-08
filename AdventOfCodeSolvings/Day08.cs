using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AdventOfCodeSolvings
{

    public class Header
    {
        public Metadata Meta { get; set; }
        public int AmoutChilds { get; set; }
        public int AmountMeta { get; set; }
        public int MetaValue = 0;

        public List<Header> SubHeader { get; set; } = new List<Header>();

        public Header()
        {
        }

        public Header(int amoutChilds, int amountMeta)
        {
            AmoutChilds = amoutChilds;
            AmountMeta = amountMeta;
        }
        
        public void AddMetaData(int[] metaData)
        {
            Meta = new Metadata(metaData);
            MetaValue = Meta.MetaData.Sum(x => x);
        }
    }

    public class Metadata
    {
        public List<int> MetaData = new List<int>();

        public Metadata(int[] metaData)
        {
            MetaData.AddRange(metaData);
        }
    }

    public class Day08 : DayInterface<int, int>
    {
        Header Main = null;
        

        public int RunPartA(List<string> input)
        {
            List<int> inputInt = new List<int>();
            ParseIntOutOfString(input, inputInt);

            while (inputInt.Count > 0)
            {
                CalcHeader(ref Main, ref inputInt);
            }

            return CalcMetadata(Main);
        }

        private static void ParseIntOutOfString(List<string> input, List<int> inputInt)
        {
            foreach (var item in input)
            {
                var split = item.Split(' ');
                foreach (var splititem in split)
                {
                    inputInt.Add(int.Parse(splititem));
                }
            }
        }

        private int CalcMetadata(Header main)
        {
            int value = 0;
            if(main.SubHeader.Count > 0)
            {
                foreach(var header in main.SubHeader)
                {
                    value += CalcMetadata(header);
                }
            }
            value += main.Meta.MetaData.Sum(x => x);

            return value;
        }

        private static void CalcHeader(ref Header header, ref List<int> inputInt)
        {
            var childs = inputInt.Take(1).ToArray()[0];
            var meta = inputInt.Skip(1).Take(1).ToArray()[0];
            var head = new Header(childs, meta);
            inputInt.RemoveRange(0, 2);
            if (header == null)
            {
                header = head;
            }
            else
            {
                header.SubHeader.Add(head);
            }

            if (childs > 0)
            {
                for(var i = 0; i < childs; i++)
                {
                    CalcHeader(ref head, ref inputInt);
                }
                head.AddMetaData(inputInt.Take(meta).ToArray());
                inputInt.RemoveRange(0, meta);
            }
            else
            {
                head.AddMetaData(inputInt.Take(meta).ToArray());
                inputInt.RemoveRange(0, meta);
            }
        }

        public int RunPartB(List<string> input)
        {
            List<int> inputInt = new List<int>();
            ParseIntOutOfString(input, inputInt);

            CalcHeader(ref Main, ref inputInt);

            return CalcReferenceMetadata(Main);
        }

        private int CalcReferenceMetadata(Header main)
        {
            int value = 0;
            if (main.AmoutChilds > 0)
            {
                foreach(var item in main.Meta.MetaData)
                {
                    var index = item - 1;
                    if(index < main.AmoutChilds)
                    {
                        value += CalcReferenceMetadata(main.SubHeader[index]);
                    }
                }
            }
            else
            {
                value += main.MetaValue;
            }

            return value;
        }
    }
}
