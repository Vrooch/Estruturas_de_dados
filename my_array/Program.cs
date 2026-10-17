using my_array;

Console.WriteLine("Hello, World!");
SmartArray<int> meu_array = new SmartArray<int>(5);



meu_array.Insert(1);
meu_array.Insert(2);
meu_array.Insert(3);
meu_array.Insert(4);

meu_array[2] = 9;


meu_array.Show();
foreach(var item in meu_array.Iterate()) Console.WriteLine(item);

meu_array.Insert(5);
meu_array[4] = 9;
meu_array.Show();

meu_array.RemoveLast();
meu_array.Show();







