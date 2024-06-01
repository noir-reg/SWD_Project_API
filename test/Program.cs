namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(n => false);
            foreach (int n in evenNumbers)
            {
                Console.WriteLine(n);
            }
            
        }
    }
}
