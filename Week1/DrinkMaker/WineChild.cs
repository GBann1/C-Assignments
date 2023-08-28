public class Wine : Drink
{
    // add specific fields
    string Region;
    int YearBottled;
    public Wine(string name, string color, double temp, bool isFizzy,int calories, string region, int yearBottled):base(name,color,temp,isFizzy,calories)
    {
        Region = region;
        YearBottled = yearBottled;
    }
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year Bottled: {YearBottled}");
    }
}