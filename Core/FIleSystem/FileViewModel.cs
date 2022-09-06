namespace Core.FileSystem;

public sealed class FileViewModel : FileSystemEntityViewModel
{
    public FileViewModel(string name) : base(name)
    {
    }

    public FileViewModel(FileInfo file) : base(file.Name)
    {
        
    }
}