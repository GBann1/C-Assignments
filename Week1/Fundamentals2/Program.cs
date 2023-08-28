// Three basic arrays
int[] numArr = {0,1,2,3,4,5,6,7,8,9};
string[] strArr = {"Tim","Martin","Nikki","Sara"};
bool[] boolArr = new bool[10];
for(int i=0;i<boolArr.Length;i++){
    if (i%2==0){
        boolArr[i] = true;
    }else {
        boolArr[i] = false;
    }
    Console.WriteLine(boolArr[i]);
}

// List of Flavors
List<string> iceCream = new List<string>();
iceCream.Add("Vanilla");
iceCream.Add("Rocky Road");
iceCream.Add("Mint");
iceCream.Add("Peach");
iceCream.Add("Cherry Garcia");

Console.WriteLine(iceCream.Count);
Console.WriteLine(iceCream[2]);
iceCream.RemoveAt(2);
Console.WriteLine(iceCream.Count);

// User Dictionary
Random rand = new Random();
Dictionary<string,string> people = new Dictionary<string,string>();
for(int i=0;i<strArr.Length;i++){
    people.Add(strArr[i],iceCream[rand.Next(0,iceCream.Count)]);
}
foreach(KeyValuePair<string,string> person in people){
    Console.WriteLine($"{person.Key} - {person.Value}");
}