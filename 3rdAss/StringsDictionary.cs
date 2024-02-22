namespace _3rdAss;

public class StringsDictionary
{
    private static int Size = 10 ;

    private LinkedList[] buckets = new LinkedList[Size] ;
    
    public void Add( string key , string value )
    {
        var slot = CalculateHash( key ) % Size ;
        if ( buckets[ slot ] == null)
        {
            buckets[ slot ] = new LinkedList() ;
        }
        buckets[ slot ].Add( new KeyValuePair( key , value ) ,  CalculateHash( key ) ) ;

        if ( LoadFactor() > 5 )
        {
            Size *= 4 ;
            LinkedList[] newBuckets = new LinkedList[ Size ] ;
            
            foreach ( var LL in buckets )
            {
                if ( LL == null ) { continue ; }
                foreach ( var pair in LL.GetAllPairs () )
                {
                    var newSlot = CalculateHash(pair.Key) % Size ;
                    if ( newBuckets[ newSlot ] == null )
                    {
                        newBuckets[ newSlot ] = new LinkedList() ;
                    }
                    newBuckets[ newSlot ].Add( pair ,  newSlot ) ;
                }
            }
            buckets = newBuckets ;
        }
    }
    
    public void Remove( string key )
    {
        if ( buckets[ CalculateHash( key ) % Size ] == null )
        {
            Console.WriteLine( "No such KEY in my data ." ) ;
        }
        else
        {
            buckets[ CalculateHash( key ) % Size ].RemoveByKey( key ) ;
        }
    }
    
    public string Get( string key )
    {
        return buckets[CalculateHash(key) % Size] == null ?
            null : buckets[CalculateHash(key) % Size].GetItemWithKey(key , CalculateHash(key));
    }
    

    private int CalculateHash( string key )
    {
        const int prime = 79 ; 
        var result = 0 ;
        foreach ( var elemant in key )
        {
            result = result * prime + elemant ;
        }
        return Math.Abs( result ) ; 
    }

    private float LoadFactor()
    {
        var elements = 0 ;
        foreach ( var linkedlist in buckets )
        {
            if ( linkedlist != null )
            { 
                elements += linkedlist.len ;   
            }
        }
        return elements / buckets.Length ;
    }
}