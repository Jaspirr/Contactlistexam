
namespace Contactlist.Services;

public class FileService
{
    public object contacts { get; set; }

    public void Save(string filepath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filepath);
            sw.WriteLine(content);
        }
        catch { }
    }
    public string Read(string filepath)
    {
        try
        {
            using var sr = new StreamReader(filepath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }

}
