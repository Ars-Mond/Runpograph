using Avalonia.Media;

namespace Core.Editor;

public sealed class FormatViewModel : BaseViewModel
{
    public FontFamily Family { get; set; }
    
    public FontStyle Style { get; set; }

    public FontWeight Weight { get; set; }

    private TextWrapping _wrap;

    public TextWrapping Wrap
    {
        get => _wrap;
        set => isWrapped = value == TextWrapping.Wrap;
    }

    public bool isWrapped { get; set; }
    
    public double SizeFont { get; set; }
}