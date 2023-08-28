// Coin Flip
static string CoinFlip()
{
    Random rand = new Random();
    if(rand.Next(2)==0)
    {
        return "heads";
    }
    return "tails";
}
Console.WriteLine(CoinFlip());

//Dice roll
static int DiceRoll(int DiceSides)
{
    Random rand = new Random();
    return rand.Next(DiceSides)+1;
}
Console.WriteLine(DiceRoll(6));

// Stat Roll
static List<int> StatRoll(int DiceSides, int NumRolls)
{
    Random rand = new Random();
    List<int> stats = new List<int>();
    for(int i=0;i<NumRolls;i++)
    {
        stats.Add(rand.Next(DiceSides)+1);
    }
    return stats;
}

//  Roll Until
static string RollUntil(int DiceSides, int DesiredVal)
{
    Random rand = new Random();
    int count = 1;
    while (rand.Next(DiceSides)+1 != DesiredVal)
    {
        count++;
    }
    return $"Rolled a {DesiredVal} after {count} tries.";
}
Console.WriteLine(RollUntil(6,3));
