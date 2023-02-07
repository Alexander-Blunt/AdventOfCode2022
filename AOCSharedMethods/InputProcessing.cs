namespace AOCSharedMethods;

public class InputProcessing
{
    /// <summary>
    /// Finds the location of the input file using the name of the file's parent directory and the name of the file.
    /// </summary>
    /// <param name="parentDirName">The name of the file's parent directory</param>
    /// <param name="fileName">The file name</param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
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