using Path = Core.FileSystem.Path;

namespace Core.Editor;

public sealed class DocumentViewModel : BaseViewModel
{
    public string Text { get; set; }

    public string FileName { get; set; }
    public Path FilePath { get; set; }

    public bool isEmpty => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath.Current);

    public DocumentViewModel(Path filePath, string fileName, string? text)
    {
        FilePath = filePath;
        FileName = fileName;
        Text = text ?? string.Empty;
    }
    
    public DocumentViewModel(string filePath, string fileName, string? text)
    {
        FilePath = new Path(filePath);
        FileName = fileName;
        Text = text ?? string.Empty;
    }

    
    
    
    
}