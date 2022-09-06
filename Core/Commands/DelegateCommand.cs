using System.Windows.Input;

namespace Core.Commands;

public class DelegateCommand : ICommand
{
    public event Action NullExecute = null!;
    
    private readonly Action<object> _execute;
    private readonly Func<bool>? _canExecute;

    public DelegateCommand(Action<object> execute)
    {
        _execute = execute ?? throw new NullReferenceException(nameof(execute));
    }
    
    public DelegateCommand(Action<object> execute, Func<bool> canExecute) : this(execute)
    {
        _canExecute = canExecute;
    }

    private void OnNullExecute()
    {
        NullExecute?.Invoke();
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute();
    }

    public void Execute(object? parameter)
    {
        if (parameter == null)
        {
            OnNullExecute();
            return;
        }
        _execute?.Invoke(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}