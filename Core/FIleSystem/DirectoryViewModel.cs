namespace Core.FileSystem;

public sealed class DirectoryViewModel : FileSystemEntityViewModel
{

    public DirectoryViewModel(string directoryName) : base(directoryName)
    {
        FullName = Name;
    }

    public DirectoryViewModel(DirectoryInfo directoryName) : base(directoryName.FullName)
    {
        FullName = directoryName.FullName;
    }
}