using System.Reflection;
using Antlr4.Runtime.Tree;
using DslPresentation.BuiltInFunctions;
using DslPresentation.Extensions;

namespace DslPresentation;

public class DslInterpreter
{
    private readonly DslListener _listener;
    private readonly IParseTree _tree;
    private readonly List<DataRow> _rows;
    
    public DslInterpreter(IParseTree tree, IEnumerable<DataRow> rows)
    {
        _tree = tree;
        _rows = new List<DataRow>(rows);
        
        _listener = new DslListener
        {
            GetAllFound = OnGetAll,
            GetSimpleFound = OnGetSimple,
            SendEmailFound = OnSendEmail
        };
    }

    public void Run()
    {
        var treeWalker = new ParseTreeWalker();
        treeWalker.Walk(_listener, _tree);
    }

    private void OnGetAll()
    {
        foreach (var row in _rows)
        {
            Console.WriteLine(row.ToString()); 
        }
    }

    private void OnGetSimple(List<string> ids)
    {
        foreach (var dataRow in _rows)
        {
            foreach (var id in ids)
            {
                var propertyValue = dataRow.GetType().GetField(id,
                    BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public).GetValue(dataRow);

                Console.Write($"{id}: {propertyValue} ");
            }

            Console.WriteLine();
        }
    }

    private void OnSendEmail(string message)
    {
        foreach (var dataRow in _rows)
        {
            Functions.SendEmail(message.InterpolateRow(dataRow));
        }
    }
}