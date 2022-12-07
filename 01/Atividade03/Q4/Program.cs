using Q4;

GenericList<string> strlist = new();
strlist.Add("string 1");
strlist.Add("string 1");
strlist.Add("string 2");

GenericList<int> intlist = new();
intlist.Add(1);
intlist.Add(1);
intlist.Add(2);

strlist.RemoveRepetido();
intlist.RemoveRepetido();

foreach(string str in strlist.List)
    Console.WriteLine(str);

foreach (int i in intlist.List)
    Console.WriteLine(i);