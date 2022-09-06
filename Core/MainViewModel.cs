using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Core.FileSystem;
using Core.Commands;

namespace Core
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

            public string FilePath { get; set; }
            public ObservableCollection<FileSystemEntityViewModel> DirectoriesAndFiles { get; set; }
                = new ObservableCollection<FileSystemEntityViewModel>();
            public FileSystemEntityViewModel SelectedFileSystemEntity { get; set; }
            

        #endregion

        #region Commands

            public ICommand OpenCommand { get; }

        #endregion
        
        #region Events
        
            
        
        #endregion

        #region Constructor
    
            public MainViewModel()
            {
                OpenCommand = new DelegateCommand(Open);
                foreach (var logicalDrive in Directory.GetLogicalDrives())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
                }

                if (OpenCommand is DelegateCommand delegateCommand)
                {
                    delegateCommand.NullExecute += () => Debug.WriteLine("Action");
                }

                FilePath = String.Empty; //Environment.SystemDirectory
            }

        #endregion

        #region Commands Methods

            private void Open(object parameter)
            {
                Console.Out.Write(parameter.GetType().ToString());
                Debug.WriteLine(parameter.GetType().ToString());

                try
                {
                    if (parameter is not DirectoryViewModel directoryViewModel) return;
                    
                    FilePath = directoryViewModel.Name;
                    DirectoriesAndFiles.Clear();
                    var directoryInfo = new DirectoryInfo(FilePath);
                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        DirectoriesAndFiles.Add(new DirectoryViewModel(directory));
                    }
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        DirectoriesAndFiles.Add(new FileViewModel(file));
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                    //throw;
                }
            }

        #endregion
    }
}

