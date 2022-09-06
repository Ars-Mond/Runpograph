using System.Windows.Input;

namespace Core.Commands;

public class DelegateCommand : ICommand
{
    private readonly Action<object> _open;

    public DelegateCommand(Action<object> open)
    {
        _open = open;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        //if (parameter == null) return;
        _open?.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}