Console.WriteLine("\n======================\nSorting\n======================");
Sorting.Run();

Console.WriteLine("\n======================\nStandardDeviation\n======================");
StandardDeviation.Run();

Console.WriteLine("\n======================\nSearch\n======================");
Search.Run();

/*
part 1
SortArray - O(n^2)
StandardDeviation - O(n^2 + 3n)
O - 1,log n,n,n log n,n^2,2^n
part 2
SearchSorted1 - O(n)
SearchSorted2 - O(1)

my prediction was that 1 was O(n) and 2 was O(1). 1 increases roughly linearly, and 2 increases imprecievebly slow. upon further examination, 2 is log(n)
of the two, number 2 has the better performance in a worst case scenario
*/