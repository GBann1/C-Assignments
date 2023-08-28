Soda Coke = new Soda("Coke","Brown",34.54,260,false);
Wine Red = new Wine("Red Wine","Red",63.54,false,30,"France",1717);
Coffee FrenchVanilla = new Coffee("French Vanilla","Brown",198.2,false,140,"light","Garbonzo");
List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(Coke);
AllBeverages.Add(Red);
AllBeverages.Add(FrenchVanilla);

foreach(Drink drink in AllBeverages)
{
    drink.ShowDrink();
}