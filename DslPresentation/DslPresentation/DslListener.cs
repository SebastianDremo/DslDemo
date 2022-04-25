namespace DslPresentation;

public class DslListener : DslParserBaseListener
{
    public Action? GetAllFound { get; set; }
    public Action<List<string>>? GetSimpleFound { get; set; }
    public Action<string>? SendEmailFound { get; set; }

    public override void EnterGet_all(DslParser.Get_allContext context)
    {
        GetAllFound?.Invoke(); 
    }

    public override void EnterGet_simple(DslParser.Get_simpleContext context)
    {
        var idContexts = context.ID();
        var ids = new List<string>();
        foreach (var idContext in idContexts)
        {
            ids.Add(idContext.GetText()); 
        }
        
        GetSimpleFound?.Invoke(ids);
    }

    public override void EnterSend_email(DslParser.Send_emailContext context)
    {
        var message = context.message.Text;
        SendEmailFound?.Invoke(message);
    }
}