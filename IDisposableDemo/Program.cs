string filePath = "test.text";
using (FileInteraction file = new FileInteraction(filePath))
{
    file.WriteToFile("Hello World");

}
StreamReader streamReader = new StreamReader(filePath);
Console.WriteLine(streamReader.ReadToEnd());
Console.ReadKey();
