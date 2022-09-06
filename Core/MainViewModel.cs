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

                FilePath = Environment.SystemDirectory;
            }

        #endregion

        #region Commands Methods

            private void Open(object parameter)
            {
                Console.Out.Write(parameter.GetType().ToString());
                Debug.WriteLine(parameter.GetType().ToString());
                
                if (parameter is DirectoryViewModel directoryViewModel)
                {
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
            }

        #endregion
    }
}

