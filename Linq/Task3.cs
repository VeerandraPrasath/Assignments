
namespace Linq
{
    /// <summary>
    /// Find the second highest number and unique pairs which sum is equal to the target
    /// </summary>
    public class Task3
    {
        int[] arr = { 1, 2, 3, 4, 2, 4, 9, 8, 7, 6, 5, 2, 3, 4, 5, 4, 2, 3, 4, 5, 6, 7 };

        /// <summary>
        /// Initialize all the methods
        /// </summary>
        public void Run()
        {
            SecondHighestNumber();
            UniqueTargetPair(10);
        }

        /// <summary>
        /// Find the second highest number in the array
        /// </summary>
        public void SecondHighestNumber()
        {
            var secondHighest = arr.OrderByDescending(x => x).Distinct().Skip(1).First();
            Console.WriteLine($"\nSecond Highest value   : {secondHighest}");
        }

        /// <summary>
        /// Find the unique pairs which sum is equal to the target
        /// </summary>
        /// <param name="target">Target value</param>
        public void UniqueTargetPair(int target)
        {
            Console.WriteLine($"\nUnique Pairs with sum equal to {target}\n");
            arr.Distinct().SelectMany((x, index) => arr.Skip(index + 1).Where(y => x + y == target).Select(y => new { x, y })).Distinct().ToList().ForEach(pair => Console.WriteLine($"Pair : {pair.x} , {pair.y}"));
        }

    }
}
