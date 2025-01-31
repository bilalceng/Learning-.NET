namespace WebApplication1.models;


public class Temperature
{
    public double Number { get; private set; }
    public string Unit { get; private set; }

    public static bool TryParse(string value, out Temperature result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }
        
        char unit = value[^1];

        if (unit != 'F' && unit != 'C')
        {
            return false;
        }

        if (double.TryParse(value[..^1], out double numericValue))
        {
            result = new Temperature { Number = numericValue, Unit = unit.ToString() };
            
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{Number}{Unit}";
    }
}