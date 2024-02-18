namespace _3rdAss;

public class StringsDictionary
{
    private static int Size = 10;

    private BST[] buckets = new BST[Size];
    
    public void add(string key, string value)
    {
        var slot = CalculateHash(key) % Size ;
        if (buckets[slot] == null) { buckets[slot] = new BST() ; }
        buckets[slot].add(new KeyValuePair(key , value)) ;
    }
    
    public string Get(string key)
    {
        if (buckets[CalculateHash(key) % Size] == null )
        {
            return null ;
        }
        return buckets[CalculateHash(key) % Size].GetValueWithKey(key) ;
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