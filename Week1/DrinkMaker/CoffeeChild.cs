
public class Coffee : Drink
{
    // add specific fields
    string RoastValue;
    string BeanType;


    public Coffee(string name, string color, double temp, bool isFizzy, int calories, string roastValue, string beanType):base(name,color,temp, isFizzy,calories)
    {
        RoastValue = roastValue;
        BeanType = beanType;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast Level: {RoastValue}");
        Console.WriteLine($"Bean Type: {BeanType}");
    }
}