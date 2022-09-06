namespace Core.FileSystem;

public class Path
{
    protected string _path;

    public string Current => _path;

    public Path(string path)
    {
        _path = path;
    }

    public Path(DirectoryInfo directory)
    {
        _path = directory.FullName;
    }

    public Path(FileInfo file)
    {
        _path = file.FullName;
    }

    
}