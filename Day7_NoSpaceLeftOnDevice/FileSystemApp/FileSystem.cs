using System.ComponentModel;

namespace FileSystem;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public abstract class FileSystemItem
{
    private int _size;

    public string Name { get; }

    public virtual int Size
    {
        get
        {
            return _size;
        }
        set
        {
            _size = value;
        }
    }

    public FileSystemItem(string name)
    {
        Name = name;
    }
}

public class FileItem : FileSystemItem
{
    public FileItem(string[] sizeAndName) : base(sizeAndName[1])
    {
        Size = int.Parse(sizeAndName[0]);
    }
}

public class DirectoryItem : FileSystemItem
{
    public override int Size
    {
        get
        {
            int sum = 0;
            foreach (FileSystemItem item in Contents)
            {
                sum += item.Size;
            }
            return sum;
        }
        set
        {
            throw new InvalidOperationException("Cannot set size for a directory.");
        }
    }

    public List<FileSystemItem> Contents { get; set; }

    public DirectoryItem(string name) : base(name)
    {
        Contents = new List<FileSystemItem>();
    }

    public void Add(string lsLine)
    {
        string[] splitLine = lsLine.Split(' ');
        if (splitLine[0] == "dir")
        {
            Contents.Add(new DirectoryItem(splitLine[1]));
        }
        else
        {
            Contents.Add(new FileItem(splitLine));
        }
    }
}