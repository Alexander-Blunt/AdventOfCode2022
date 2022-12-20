using System.ComponentModel;

namespace FileSystemApp;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public abstract class FileSystem
{
    public string Name { get; set; }
}

public class File : FileSystem
{
    public int Size { get; set; }

    public File(string lsLine)
    {
        string[] sizeAndName = lsLine.Split(' ');
        Size = int.Parse(sizeAndName[0]);
        Name = sizeAndName[1];
    }
}

public class Directory : FileSystem
{
    public List<FileSystem> Contents;

    public Directory()
    {
        Contents = new List<FileSystem>();
    }

    public void Add(FileSystem item)
    {
        Contents.Add(item);
    }
}