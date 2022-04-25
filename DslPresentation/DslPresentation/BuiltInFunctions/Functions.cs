namespace DslPresentation.BuiltInFunctions;

public class Functions
{
    public static void SendEmail(string message)
    {
        Console.WriteLine($"Email sent: {message}"); 
        Console.WriteLine();
    }
}