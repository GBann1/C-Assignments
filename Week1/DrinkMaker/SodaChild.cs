public class Soda : Drink
{
    // add specific fields
    public bool IsFizzy = true;
    public bool IsDiet;

    public Soda(string name, string color, double temp, int calories, bool isDiet):base(name,color,temp,true,calories)
    {
        IsDiet = isDiet;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Diet: {IsDiet}");
    }
}