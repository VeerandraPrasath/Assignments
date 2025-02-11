/// <summary>
/// Used to implement the file interactions
/// </summary>
public class FileInteraction : IDisposable
{

    private readonly StreamWriter _streamWriter;

    /// <summary>
    /// Constructor to initialize the file path
    /// </summary>
    /// <param name="path"></param>
    public FileInteraction(string path)
    {
        _streamWriter = new StreamWriter(path);
    }

    /// <summary>
    /// Write the text to the file
    /// </summary>
    /// <param name="text">Content to write</param>
    public void WriteToFile(string text)
    {
        _streamWriter.Write(text);
    }

    /// <summary>
    /// Dispose the stream writer
    /// </summary>
    public void Dispose()
    {
        _streamWriter.Close();
    }

    /// <summary>
    /// Destructor to close the stream writer
    /// </summary>
    ~FileInteraction()
    {
        _streamWriter.Close();
    }
}