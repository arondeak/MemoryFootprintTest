using DTO;

Console.WriteLine($"Size of {nameof(DataClass)} is {UsagePerObject<DataClass>()}");
Console.WriteLine($"Size of {nameof(DataStruct)} is {UsagePerObject<DataStruct>()}");
Console.WriteLine($"Size of {nameof(DataStruct2)} is {UsagePerObject<DataStruct2>()}");
Console.WriteLine($"Size of {nameof(DataStruct3)} is {UsagePerObject<DataStruct3>()}");
Console.WriteLine($"Size of {nameof(DataStruct4)} is {UsagePerObject<DataStruct4>()}");
Console.WriteLine($"Size of {nameof(DataStruct5)} is {UsagePerObject<DataStruct5>()}");

double UsagePerObject<T>() where T: new()
{
    int n = 1_0000_000;
    var memBefore = GC.GetTotalMemory(true);
    var a = new T[n];
    for (int i = 0; i < n; ++i)
        a[i] = new T();
    var memAfter = GC.GetTotalMemory(true);
    return (memAfter - memBefore) / (double)a.Length;
}

double UsagePerStruct<T>() where T: new()
{
    int n = 1_0000_000;
    var memBefore = GC.GetTotalMemory(true);
    var a = new T[n];
    var memAfter = GC.GetTotalMemory(true);
    return (memAfter - memBefore) / (double)a.Length;
}