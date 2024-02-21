namespace _3rdAss;

public class LinkedList
{
    private LinkedListNode first;
    private LinkedListNode lastNode ;
    private BST collisions { get; set; }

    
    public LinkedList(BST damm)
    {
        collisions = damm ;
    }

    public BST GetCollisions()
    {
        return collisions ;
    }
    
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

        var current = first ;
        while ( current != lastNode )
        {
            if (current.Pair.Key.Equals(pair.Key))
            {
                collisions.add(pair);
            }
            current = current.Next ;
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

    public string GetItemWithKey(string key)
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
                var tryCollisions = collisions.GetValueWithKey(key);
                if (tryCollisions != null)
                {
                    return $"{current.Pair.Value} || {tryCollisions}" ;
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