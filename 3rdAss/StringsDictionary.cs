namespace _3rdAss;

public class StringsDictionary
{
    private static int Size = 10;

    private LinkedList[] buckets = new LinkedList[Size];
    
    public void Add(string key, string value)
    {
        var slot = CalculateHash(key) % Size ;
        if (buckets[slot] == null)
        {
            buckets[slot] = new LinkedList(new BST()) ;
        }
        buckets[slot].Add(new KeyValuePair(key , value)) ;

        if (LoadFactor() > 0.7)
        {
            Size *= 2 ;
            LinkedList[] newBuckets = new LinkedList[Size] ;
            
            foreach (var LL in buckets)
            {
                foreach ( var pair in LL.GetAllPairs () )
                {
                    var newSlot = CalculateHash(pair.Key) % Size ;
                    if (newBuckets[newSlot] == null)
                    {
                        newBuckets[newSlot] = new LinkedList(buckets[slot].GetCollisions() ) ;
                    }
                    newBuckets[ newSlot ].Add( pair ) ;
                }
            }
            buckets = newBuckets ;
        }
    }
    
    public void Remove(string key)
    {
        if (buckets[CalculateHash(key) % Size] == null)
        {
            Console.WriteLine("No such KEY in my data .");
        }
        else
        {
            buckets[CalculateHash(key) % Size].RemoveByKey(key);
        }
    }
    
    public string Get(string key)
    {
        if (buckets[CalculateHash(key) % Size] == null )
        {
            return null ;
        }
        return buckets[CalculateHash(key) % Size].GetItemWithKey(key) ;
    }
    

    private int CalculateHash( string key )
    {
        var result = 0 ;
        foreach ( var elemant in key )
        {
            result += Convert.ToChar(elemant) ;
        }
        return result ; 
    }

    private float LoadFactor()
    {
        var full = 0 ;
        foreach (var linkedlist in buckets)
        {
            full += (linkedlist != null) ? 1 : 0 ;
        }
        
        return full / buckets.Length ;
    }
}