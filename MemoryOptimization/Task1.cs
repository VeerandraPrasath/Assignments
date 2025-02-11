
namespace MemoryOptimization
{
    public class Task1
    {
        List<int[]> memalloc = new List<int[]>();

        public void Allocate()
        {
            while (true)
            {
                memalloc.Add(new int[1000]);
                Thread.Sleep(100);
            }
        }

    }


}
