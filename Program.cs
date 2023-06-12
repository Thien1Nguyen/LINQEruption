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
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!


//Use LINQ to find the first eruption that is in Chile and print the result.
PrintFirst("Chile");

//Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
PrintFirst("Hawaiian Is");


//Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
PrintFirst("GreendLand");

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? firstNewZealand = eruptions.Where(e => e.Location == "New Zealand").Where(e => e.Year > 1900).OrderBy(y => y.Year).FirstOrDefault();

Console.WriteLine(firstNewZealand.ToString());

//Find all eruptions where the volcano's elevation is over 2000m and print them.
List<Eruption> twoThousandClub = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();

PrintEach(twoThousandClub, "These volcanos' elevation are over 2000m");

//Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
List<Eruption> lClub = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
PrintEach(lClub, "These volcanos' name starts with L");
Console.WriteLine($"There are {lClub.Count} eruptions found");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int highestElev = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine($"The highest Elevation is: {highestElev}m");

//Use the highest elevation variable to find and print the name of the Volcano with that elevation.
Eruption tallestVolcano = eruptions.Where(e => e.ElevationInMeters == highestElev).FirstOrDefault();
Console.WriteLine($"The Volcano with the highest elevation is mount {tallestVolcano.Volcano}");

//Print all Volcano names alphabetically.
IEnumerable<Eruption> volcanoNameByAlpha = eruptions.OrderBy(e => e.Volcano).ToList();
Console.WriteLine("Volcanos sorted by names");
foreach(Eruption volcano in volcanoNameByAlpha)
{
    Console.WriteLine(volcano.Volcano);
    Console.WriteLine();
}
// PrintEach(volcanoNameByAlpha, "Volcanos sorted by names");
int elevationSum = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine($"Total Elevation of all volcanos: {elevationSum}m");
Console.WriteLine();

//Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool y2kEruption = eruptions.Any(e => e.Year > 2000);
Console.WriteLine($"Were there any eruptions in the year 2000? Answer:{y2kEruption}");


//Find all stratovolcanoes and print just the first three (Hint: look up Take)
IEnumerable<Eruption> top3Strato = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(top3Strato, "These are 3 Stratovolcano type Volcano");

//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> pre1000ByAlpha = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(pre1000ByAlpha, "Eruptions before 1000CE sorted alphabetically ");

//Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
List<string> pre1000ByAlphaName = pre1000ByAlpha.Select(e=> e.Volcano).ToList();

foreach(string name in pre1000ByAlphaName)
{
    Console.WriteLine(name);
    Console.WriteLine();
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


// A method to find the first eruption at a location
Eruption PrintFirst(string site)
{
    Eruption? firstEruption = eruptions.Where(l => l.Location == site).OrderBy(y => y.Year).FirstOrDefault();

    if(firstEruption == null)
    {
        Console.Write($"No {site} Eruption found.");
        Console.WriteLine();
        return null;
    }
    else
    {
        Console.Write(firstEruption.ToString());
        Console.WriteLine();
        return firstEruption;
    }
}
