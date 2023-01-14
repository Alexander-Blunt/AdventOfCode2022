namespace AOCSharedMethods;

public class InputProcessing
{
    public static string GetInputFilePath(string parentDirName, string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        int parentDirIndex = currentDirectory.LastIndexOf(parentDirName);
        int lengthOfParentDirPath = parentDirName.Length + parentDirIndex;
        string fullParentPath = currentDirectory.Substring(0, lengthOfParentDirPath);

        string filePath = fullParentPath + @"\" + fileName;

        if (File.Exists(filePath)) return filePath;
        else throw new FileNotFoundException();
    }
}