using System.Globalization;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using DslPresentation;

var csvLines = File.ReadAllLines("./MOCK_DATA.csv").Skip(1);
var rows = new List<DataRow>();

foreach (var line in csvLines)
{
    var data = line.Split(",");
    var row = new DataRow(Convert.ToInt32(data[0]), data[1], data[2], data[3], data[4], float.Parse(data[5], CultureInfo.InvariantCulture.NumberFormat));
    
    rows.Add(row);
}

var inputStream = new AntlrFileStream("./Input.txt");
var lexer = new DslLexer(inputStream);
var tokenStream = new CommonTokenStream(lexer);
var parser = new DslParser(tokenStream)
{
    BuildParseTree = true
};

IParseTree tree = parser.dsl_batch();

var interpreter = new DslInterpreter(tree, rows);
interpreter.Run();




