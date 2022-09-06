﻿namespace Core.FileSystem;

public abstract class FileSystemEntityViewModel : BaseViewModel
{
    public string Name { get; }
    public string FullName { get; set; }

    protected FileSystemEntityViewModel(string name)
    {
        Name = name;
    }
}