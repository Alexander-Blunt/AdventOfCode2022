using System.ComponentModel;

namespace FileSystem;

public class Program
{
    static void Main(string[] args)
    {
        string fileLocation = @"C:\Users\spore\source\repos\AdventOfCode2022\Day7_NoSpaceLeftOnDevice\FileSystemApp\Day7Input.txt";
        string[] inputLines = File.ReadAllLines(fileLocation);

        DirectoryItem rootDirectory = new();
        DirectoryItem currentDirectory = rootDirectory;
        foreach (string line in inputLines)
        {
            if (line.Contains("$ cd"))
            {
                currentDirectory = currentDirectory.ChangeDirectory(line.Substring(5));
            }
        }
    }
}

public interface IChildItem
{
    public DirectoryItem Parent { get; }
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

    public FileSystemItem() { }
}

public class FileItem : FileSystemItem, IChildItem
{
    public DirectoryItem Parent { get; }

    public FileItem(int size, DirectoryItem parent)
    {
        Parent = parent;
        Size = size;
    }
}

public class DirectoryItem : FileSystemItem
{
    public override int Size
    {
        get
        {
            int sum = 0;
            foreach (var item in Contents)
            {
                sum += item.Value.Size;
            }
            return sum;
        }
        set
        {
            throw new InvalidOperationException("Cannot set size for a directory.");
        }
    }

    public Dictionary<string, FileSystemItem> Contents { get; set; }

    public DirectoryItem()
    {
        Contents = new Dictionary<string, FileSystemItem>();
    }

    public void Add(string directoryName)
    {
        Contents.Add(directoryName, new ChildDirectory(this));
    }

    public void Add(string fileName, int fileSize)
    {
        Contents.Add(fileName, new FileItem(fileSize, this));
    }

    public DirectoryItem ChangeDirectory(string directoryName)
    {
        if (this.Contents.ContainsKey(directoryName)) return (DirectoryItem)this.Contents[directoryName];
        else throw new FieldAccessException("Directory not found.");
    }
}

public class ChildDirectory : DirectoryItem, IChildItem
{
    public DirectoryItem Parent { get; }

    public ChildDirectory(DirectoryItem parent)
    {
        Parent = parent;
    }
}