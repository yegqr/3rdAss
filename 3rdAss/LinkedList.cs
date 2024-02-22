namespace _3rdAss;

public class LinkedList
{
    private LinkedListNode first;
    private LinkedListNode lastNode ;
    public int len ;
    
    public void Add( KeyValuePair pair , int hash )
    {
        var current = first ;
        while ( current != lastNode )
        {
            if ( hash == current.HashValue )
            {
                if ( current.status == false )
                {
                    current.status = true ;
                    current.colisions = new BST();
                    current.colisions.add( current.Pair ) ;
                }
                current.colisions.add( pair ) ;
            }
            current = current.Next ;
        }
        
        if ( first == null )
        {
            first = new LinkedListNode(pair) ;
            lastNode = first ;
            first.HashValue = hash ;
            len += 1 ; 
        }
        else
        {
            lastNode.Next = new LinkedListNode( pair ) ;
            lastNode = lastNode.Next ;
            first.HashValue = hash ;
            len += 1 ;
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
                break ;
            }
            if ( current.Pair.Key.Equals( key ) )
            {
                previous.Next = current ;
                break ;
            }
            previous = current ;
            current = current.Next ;
        }
    }

    public string GetItemWithKey( string key , int hash )
    {
        if ( first == null )
        {
            Console.WriteLine("The list is completely empty . There is no such key here .") ;
            return null ;
        }

        var current = first ;
        while ( true ) 
        {
            if ( current.Pair.Key.Equals( key ) )
            {
                if ( current.status && current.HashValue.Equals( hash ) )
                {
                    return current.colisions.GetValueWithKey( key ) ;
                }
                return current.Pair.Value ;
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