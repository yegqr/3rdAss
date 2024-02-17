using _3rdAss;
using KeyValuePair = _3rdAss.KeyValuePair;

class Program
{
    private static void Main()
    { 
        var dict = new StringsDictionary() ;
        foreach (var row in File.ReadAllLines("Dictionary.txt"))
        {
            var key = row.Split("|")[0] ;
            var value = row.Split("|")[2] ;
            dict.add( key , value ) ;
        }
        
        while (true)
        {
            Console.WriteLine("Write the word , which definition you want to get .");
            var input = Console.ReadLine().Trim().ToLower() ;
            try
            {
                Console.WriteLine($"{input} => {dict.Get(input)}\n");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Wrong input .");
            }
            if (input == "STOP")
            {
                Console.WriteLine("See you soon !");
                break;
            }
        }
    }
}