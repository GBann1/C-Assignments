
public class Drink
{
    public string Name;
    public string Color;
    public double Temp;
    public bool IsFizzy;
    public int Calories;

    public Drink(string name, string color, double temp, bool isFizzy, int calories)
    {
        Name = name;
        Color = color;
        Temp = temp;
        IsFizzy = isFizzy;
        Calories = calories;
    }

    public virtual void ShowDrink()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Temp: {Temp}");
        Console.WriteLine($"IsFizzy: {IsFizzy}");
        Console.WriteLine($"Calories: {Calories}");
    }
}