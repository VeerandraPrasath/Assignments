namespace Linq
{
    /// <summary>
    /// Find the second highest number and unique pairs which sum is equal to the target
    /// </summary>
    public class Task3
    {
        int[] intArray = { 1, 2, 3, 4, 2, 4, 9, 8, 7, 6, 5, 2, 3, 4, 5, 4, 2, 3, 4, 5, 6, 7 };

        /// <summary>
        /// Initialize all the methods
        /// </summary>
        public void ExecuteTask3Queries()
        {
            //Query 3.1
            SecondHighestNumber();
            //Query 3.2
            UniqueTargetPair(10);
        }

        /// <summary>
        /// Find the second highest number in the array
        /// </summary>
        private void SecondHighestNumber()
        {
            var secondHighest = intArray
                .OrderByDescending(x => x)
                .Distinct()
                .Skip(1)
                .FirstOrDefault();
            Console.WriteLine($"\nSecond Highest value   : {secondHighest}");
        }

        /// <summary>
        /// Find the unique pairs which sum is equal to the target
        /// </summary>
        /// <param name="target">Target value</param>
        private void UniqueTargetPair(int target)
        {
            Console.WriteLine($"\nUnique Pairs with sum equal to {target}\n");
            intArray
                .Distinct()
                .SelectMany((x, index) => intArray.Skip(index + 1).Where(y => x + y == target).Select(y => new { x, y }))
                .Distinct()
                .ToList()
                .ForEach(pair => Console.WriteLine($"Pair : {pair.x} , {pair.y}"));
        }
    }
}
