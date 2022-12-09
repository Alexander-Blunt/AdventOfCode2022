namespace Day1_CalorieCounting
{
    internal class CalorieCounting
    {
        static void Main(string[] args)
        {
            string fileLocation = "..\\..\\..\\Day1Input.txt";
            foreach (string item in File.ReadAllLines(fileLocation))
            {
                Console.WriteLine(item);
            }
        }
    }
}