
namespace Linq
{
    public class Task3
    {
        int[] arr = { 1, 2, 3, 4, 2, 4, 9, 8, 7, 6, 5, 2, 3, 4, 5, 4, 2, 3, 4, 5, 6, 7 };

        public void SecondHighestNumber()
        {
            var secondHighest = arr.OrderByDescending(x => x).Distinct().Skip(1).First();
            Console.WriteLine($"Second Highest : {secondHighest}");
        }

        public void UniqueTargetPair(int target)
        {
            arr.Distinct().SelectMany((x, index) => arr.Skip(index + 1).Where(y => x + y == target).Select(y => new { x, y })).Distinct().ToList().ForEach(pair => Console.WriteLine($"Pair : {pair.x} , {pair.y}"));
        }

    }
}
