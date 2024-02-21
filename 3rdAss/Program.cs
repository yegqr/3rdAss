using _3rdAss;

class Program
{
    private static void Main()
    {
        var dict = new StringsDictionary() ;
        foreach (var row in File.ReadAllLines("Dictionary.txt"))
        {
            var key = row.Split("|")[0] ;
            var value = row.Split("|")[2] ;
            
            dict.Add( key , value ) ;
        }

        while (true)
        {
            Console.WriteLine("Write the word , which definition you want to get .");
            var input = Console.ReadLine().Trim().ToLower();
            Console.WriteLine($"{input} => {dict.Get(input)}\n");
            if (input == "STOP")
            {
                Console.WriteLine("See you soon !");
                break;
            }
        }
    }
}