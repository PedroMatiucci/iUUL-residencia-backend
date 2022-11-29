using Q4;

GenericList<string> strlist = new GenericList<string>();
strlist.Add("string 1");
strlist.Add("string 1");
strlist.Add("string 2");

GenericList<int> intlist = new GenericList<int>();
intlist.Add(1);
intlist.Add(1);
intlist.Add(2);

strlist.RemoveRepetido();