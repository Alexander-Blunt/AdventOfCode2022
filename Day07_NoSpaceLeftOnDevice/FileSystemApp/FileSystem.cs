using System.Collections;
using System.ComponentModel;
using AOCSharedMethods;

namespace FileSystem;

public class Program
{
    static void Main(string[] args)
    {
        string fileLocation = InputProcessing.GetInputFilePath(@"\FileSystemApp", "Day7Input.txt");
        List<DirectoryItem> directoryList = CreateDirectoryList(fileLocation);

        //Get sum of directories with size < 100_000
        int sum = 0;
        foreach (var directory in directoryList)
        {
            int size = directory.Size;
            if (size < 100_000)
            {
                sum += size;
            }
        }
        Console.WriteLine(sum);

        //Get directory size for deletion
        int totalSpace = 70_000_000;
        int requiredSpace = 30_000_000;
        int currentSize = directoryList[0].Size;
        int targetSize = totalSpace - requiredSpace;
        int deletableSize = totalSpace;

        foreach (var directory in directoryList)
        {
            int directorySize = directory.Size;
            if (currentSize - directorySize < targetSize &&
            directorySize < deletableSize)
            {
                deletableSize = directorySize;
            }
        }
        Console.WriteLine(deletableSize);
    }

    public static List<DirectoryItem> CreateDirectoryList(string fileLocation)
    {
        List<string> inputLines = new(File.ReadAllLines(fileLocation));
        inputLines.RemoveAt(0);

        DirectoryItem rootDirectory = new();
        DirectoryItem currentDirectory = rootDirectory;
        List<DirectoryItem> directoryList = new();
        directoryList.Add(rootDirectory);
        foreach (string line in inputLines)
        {
            if (line.Contains("$ cd"))
            {
                currentDirectory = currentDirectory.ChangeDirectory(line.Substring(5));
            }
            else if (!line.Contains("$"))
            {
                string[] splitLine = line.Split(' ');
                if (int.TryParse(splitLine[0], out int number))
                {
                    currentDirectory.Add(splitLine[1], number);
                }
                else
                {
                    currentDirectory.Add(splitLine[1]);
                    directoryList.Add((DirectoryItem)currentDirectory.Contents[splitLine[1]]);
                }
            }
        }
        return directoryList;
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

    public virtual DirectoryItem ChangeDirectory(string directoryName)
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

    public override DirectoryItem ChangeDirectory(string directoryName)
    {
        if (directoryName == "..") return Parent;
        else return base.ChangeDirectory(directoryName);
    }
}