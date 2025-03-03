using System.Reflection;
using System.Drawing;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the image convertor ");
            var binDir = Environment.CurrentDirectory + "\\Plugins";
            var files = Directory.GetFiles(binDir, "*.dll").ToList();
            Bitmap image = new Bitmap("image.bmp");
            List<IImageProcessor> imageProcessors = PluginLoader.LoadPluginsFromFile(files);


            int count = 0;
            Console.WriteLine("Available plugins are : ");

            foreach (var imageProcessor in imageProcessors)
            {
                Console.WriteLine($"{++count}.{imageProcessor.GetType().Name}");

            }

            Console.WriteLine("Enter the option :");
            int userOption = int.Parse(Console.ReadLine());
            if (userOption > 0 && userOption <= count)
            {
                MethodInfo methodInfo = imageProcessors[userOption - 1].GetType().GetMethod("GitMapProcessor");
                Bitmap result = (Bitmap)methodInfo.Invoke(imageProcessors[userOption - 1], [image]);
                Console.WriteLine("Do u want to save (Y/N) :");
                string saveOption = Console.ReadLine();
                if (saveOption.Equals("Y"))
                {
                    result.Save("result.png");
                }
                else
                {
                    Console.Write("Discard changes");

                }
            }
            else
            {
                Console.WriteLine("Invalid Option !");
            }

            Console.ReadKey();
        }
    }
        public static class PluginLoader
        {
            public static List<IImageProcessor> LoadPluginsFromFile(List<string> files)
            {
                List<IImageProcessor> pluginList = new List<IImageProcessor>();
                foreach (string assembly in files)
                {
                    Assembly.LoadFrom(assembly).GetTypes().Where(t => typeof(IImageProcessor).IsAssignableFrom(t) && !t.IsInterface).ToList().ForEach(t => pluginList.Add((IImageProcessor)Activator.CreateInstance(t)));
                }
                return pluginList;
            }

        }
    
}
