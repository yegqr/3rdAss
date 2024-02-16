namespace _3rdAss;

public class LinkedList
{
    private LinkedListNode first;
    private LinkedListNode lastNode ;
    
    public void Add(KeyValuePair pair)
    {
        if ( first == null )
        {
            first = new LinkedListNode(pair) ;
            lastNode = first ;
        }
        else
        {
            lastNode.Next = new LinkedListNode( pair ) ;
            lastNode = lastNode.Next ;
        }
    }

    public void RemoveByKey(string key)
    {
        var current = first ;
        var previous = first ;
        
        while ( true )
        {
            if ( current.Pair.Key.Equals( key ) && current.Equals( previous ) )
            {
                first = first.Next ;
                break ;
            }
            if ( current.Pair.Key.Equals( key ) && current.Next.IsNull() )
            {
                previous.Next = null ;
                break;
            }
            if ( current.Pair.Key.Equals( key ) )
            {
                previous.Next = current ;
            }
            previous = current ;
            current = current.Next ;
        }
    }

    public KeyValuePair GetItemWithKey(string key)
    {
        var current = first ;
        if (first == null)
        {
            Console.WriteLine("The list is completely empty . There is no such key here .");
            return null ;
        }

        while ( true ) 
        {
            if ( current.Pair.Key.Equals( key ) )
            {
                return current.Pair ;
            }
            if ( current.Next == null )
            {
                Console.WriteLine("Wrong key ! It doesn^t exist in a list .") ;
                return null ;
            }
            current = current.Next ;
        }
    }

    public List<KeyValuePair> GetAllPairs()
    {
        var temporaryList = new List<KeyValuePair>() ;
        var current = first ;
        while ( current != null )
        {
            temporaryList.Add(current.Pair) ;
            current = current.Next ;
        }

        return temporaryList ;
    }
}