int[] input = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int number in ProceduralCode(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in KeywordSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in MethodCallSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

IEnumerable<int> ProceduralCode(int[] input) {
    List<int> filtered = new List<int>();
    foreach (int number in input) {
        if (number % 2 == 0) {
            filtered.Add(number);
        }
    }

    int[] result = filtered.ToArray();
    Array.Sort(result);

    for (int i = 0; i < result.Length; i++) {
        result[i] = result[i] * 2;
    }

    return result;
}

IEnumerable<int> KeywordSyntax(int[] input) {
    var result = from number in input
                 where number % 2 == 0
                 orderby number ascending
                 select number * 2;
    return result;
}


IEnumerable<int> MethodCallSyntax(int[] input) {
    var result = input
                 .Where(number => number % 2 == 0)
                 .OrderBy(number => number)
                 .Select(number => number * 2);
    return result;
}