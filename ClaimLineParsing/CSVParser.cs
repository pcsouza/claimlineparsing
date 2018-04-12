using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ClaimLineParsing {
    class CSVParser {
        private Uri _fileUri;

        public CSVParser() {
        }

        public List<List<CSVHeaderValue>> ParseLines(StreamReader f) {
                var headers = f.ReadLine().Split(',').ToList();
                string line;
                var lineList = new List<List<CSVHeaderValue>>();
                while((line  = f.ReadLine()) != null) {
                    var values = line.Split(',');
                    var pairList = new List<CSVHeaderValue>();
                    foreach(var i in Enumerable.Range(0, values.Count())) {
                        var pair = new CSVHeaderValue() { Header = headers[i], Value = values[i] };
                        pairList.Add(pair);
                    }
                    lineList.Add(pairList);
                }
                return lineList;
        }
    }

    public class TestClass {
        const string testText = @"header1,header2
value1,value2";


        [Test]
        public void ParsesCSVFile() {
            var stream = GenerateStreamFromString(testText);
            var reader = new StreamReader(stream);
            var parser = new CSVParser();
            var outPut = parser.ParseLines(reader);
        }

        public static Stream GenerateStreamFromString(string s) {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
