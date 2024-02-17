namespace _3rdAss;

public class BST
{
    public KeyValuePair pair ;
    public int pairValue ;
    public BST lesser ;
    public BST greater ;

    public void add(KeyValuePair input )
        {
            if (pair == null)
            {
                pairValue = CalculateHash(input.Key) ;
                pair = input ;
            }
            else
            {
                if (CalculateHash(input.Key) > pairValue)
                {
                    if (greater == null){greater = new BST() ;}
                    greater.add(input);
                }
                else
                {
                    if (lesser == null){lesser = new BST() ;}
                    lesser.add(input);
                }
            }
        }
    
    public string GetValueWithKey(string key)
    {
        if ( pair.Key == key )
        {
            return pair.Value ;
        }
        var current = CalculateHash(key) > pairValue ? greater : lesser ;
        return current.GetValueWithKey(key) ;
    }
    
    public int CalculateHash( string key )
    {
        var result = 0 ;
        foreach ( var elemant in key )
        {
            result += Convert.ToChar(elemant) * Convert.ToInt32(elemant) ;
        }
        return result ; 
    }

}