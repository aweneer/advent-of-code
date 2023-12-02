namespace Utilities
{
    public static class Utilities2023
    {
        public readonly static Dictionary<string, int> numberByWord = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };


        private static void PrintArray(this List<string> array)
        {
            var result = string.Concat("PrintArray() = [", string.Join(", ", array), "]");
            Console.WriteLine(result);
        }

        private static void PrintArray(this char[] array)
        {
            var result = string.Concat("PrintArray() = [", string.Join(", ", array), "]");
            Console.WriteLine(result);
        }
    }
}
