using System.ComponentModel;

namespace FileSystem;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public abstract class FileSystem
{
    public string Name { get; }

    public FileSystem(string name)
    {
        Name = name;
    }
}

public class File : FileSystem
{
    public int Size { get; set; }

    public File(string[] sizeAndName) : base(sizeAndName[1])
    {
        Size = int.Parse(sizeAndName[0]);
    }
}

public class Directory : FileSystem
{
    public List<FileSystem> Contents { get; set; }

    public Directory(string name) : base(name)
    {
        Contents = new List<FileSystem>();
    }

    public void Add(FileSystem item)
    {
        Contents.Add(item);
    }

    public void LSItem(string[] splitLine)
    {
        if (splitLine[0] == "dir")
        {
            Add(new Directory(splitLine[1]));
        }
        else
        {
            Add(new File(splitLine));
        }
    }
}