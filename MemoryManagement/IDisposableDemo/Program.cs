string filePath = "test.text";
using (FileInteraction file = new FileInteraction(filePath))
{
    file.WriteToFile("Content written to file successfully !!!!!!");

}
StreamReader streamReader = new StreamReader(filePath);
Console.WriteLine(streamReader.ReadToEnd());
Console.ReadKey();
