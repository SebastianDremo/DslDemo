namespace DslPresentation;

public class DataRow
{
    public DataRow(int id, string email, string ip, string currency, string stock, float price)
    {
        Id = id;
        Email = email;
        Ip = ip;
        Currency = currency;
        StockName = stock;
        Price = price;
    }

    public int Id;
    public string Email ;
    public string Ip;
    public string Currency;
    public string StockName;
    public float Price;

    public override string ToString()
    {
        return $"ID: {Id}, Email: {Email}, Ip: {Ip}, Currency: {Currency}, Stock: {StockName}, Price: {Price}";
    }
}