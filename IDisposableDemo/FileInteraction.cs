
public class FileInteraction : IDisposable
{

    public readonly StreamWriter _streamWriter;

    public FileInteraction(string path)
    {

        _streamWriter = new StreamWriter(path);
    }

    public void WriteToFile(string text)
    {
        _streamWriter.Write(text);
    }


    public void Dispose()
    {
        _streamWriter.Close();
    }

    ~FileInteraction()
    {
        _streamWriter.Close();
    }
}