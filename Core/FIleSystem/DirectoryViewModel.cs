namespace Core.FileSystem;

public sealed class DirectoryViewModel : FileSystemEntityViewModel
{

    public DirectoryViewModel(string directoryName) : base(directoryName, directoryName)
    {
        
    }

    public DirectoryViewModel(DirectoryInfo directoryName) : base(directoryName.Name, directoryName.FullName)
    {
        
    }
}