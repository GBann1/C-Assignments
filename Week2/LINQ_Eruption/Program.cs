

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
Eruption FirstChileEruption = eruptions.FirstOrDefault(entry => entry.Location == "Chile");
Console.WriteLine(FirstChileEruption);

// Console.WriteLine("************************************************************");
Eruption FirstHawaiianIs = eruptions.FirstOrDefault(entry => entry.Location == "Hawaiian Is");
Console.WriteLine(FirstHawaiianIs != null ? FirstHawaiianIs.ToString() : "No Hawaiian Is Eruption found");

// Console.WriteLine("************************************************************");
Eruption FirstGreenland = eruptions.FirstOrDefault(entry => entry.Location == "Greenland");
Console.WriteLine(FirstGreenland != null ? FirstGreenland.ToString() : "No Greenland Is Eruption found");

// Console.WriteLine("************************************************************");
Eruption FirstAfter1900AndNewZealand = eruptions.FirstOrDefault(entry => ((entry.Year > 1900) && (entry.Location == "New Zealand")));
Console.WriteLine(FirstAfter1900AndNewZealand.ToString());

// Console.WriteLine("************************************************************");
IEnumerable<Eruption> Over2KM = eruptions.Where(entry => entry.ElevationInMeters > 2000);
PrintEach(Over2KM);

// Console.WriteLine("************************************************************");
IEnumerable<Eruption> LEruptions = eruptions.Where(entry => entry.Volcano.StartsWith('L'));
PrintEach(LEruptions);
Console.WriteLine(LEruptions.Count());

// Console.WriteLine("************************************************************");
int MaxElevation = eruptions.Max(entry => entry.ElevationInMeters);
Console.WriteLine(MaxElevation);

// Console.WriteLine("************************************************************");
Eruption MaxElevationName = eruptions.FirstOrDefault(entry => entry.ElevationInMeters == MaxElevation);
Console.WriteLine(MaxElevationName);

// Console.WriteLine("************************************************************");
IEnumerable<Eruption> SortedAToZ = eruptions.OrderBy(entry => entry.Volcano);
PrintEach(SortedAToZ);

// Console.WriteLine("************************************************************");       
int ElevationSum = eruptions.Sum(entry => entry.ElevationInMeters);
Console.WriteLine(ElevationSum);

// Console.WriteLine("************************************************************");
bool VolcanoErupted = eruptions.Any(entry => entry.Year == 2000);
Console.WriteLine(VolcanoErupted);

// Console.WriteLine("************************************************************");
IEnumerable<Eruption> Take3Strato = eruptions.Where(entry => entry.Type == "Stratovolcano").Take(3);
PrintEach(Take3Strato);

// Console.WriteLine("************************************************************");
IEnumerable<Eruption> Before1000 = eruptions.Where(entry => entry.Year < 1000).OrderBy(entry => entry.Volcano);
PrintEach(Before1000);

// Console.WriteLine("************************************************************");
IEnumerable<string> Before1000Names = eruptions.Where(entry => entry.Year < 1000).OrderBy(entry => entry.Volcano).Select(entry => entry.Volcano);
// Loops through and prints each name
foreach(string name in Before1000Names)
{
    Console.WriteLine(name);
}
// Re-wrote the print each function
PrintEachName(Before1000Names);

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
static void PrintEachName(IEnumerable<string> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (string item in items)
    {
        Console.WriteLine(item.ToString());
    }
}