namespace _3rdAss;


public class BST
{
    public KeyValuePair pair ;
    public int pairValue ;
    public BST lesser ;
    public BST greater ;

    public void add(KeyValuePair input )
    {
        Balance();
        switch ( pair == null )
        {
            case true :
                pairValue = CalculateHash( input.Key ) ;
                pair = input ;
                break ;
            case false :
                switch ( CalculateHash(input.Key) > pairValue )
                {
                    case true :
                        if ( greater == null ) { greater = new BST() ; }
                        greater.add( input ) ;
                        break ;
                    case false :
                        if ( lesser == null ) { lesser = new BST() ; }
                        lesser.add( input ) ;
                        break ;
                }
                break ;
        }
    }

    public int Balance()
    {
        var lefChildHeight = lesser != null ? lesser.Balance() : 0 ;
        var rightChildHeight = greater != null ? greater.Balance() : 0 ;
        switch ( lefChildHeight - rightChildHeight )
        {
            case > 1 :
                var SwapRootToRight = new BST() ; 
                SwapRootToRight.add( pair ) ;
                SwapRootToRight.greater = greater ;
                SwapRootToRight.lesser = lesser.greater ;
                
                lesser.greater = SwapRootToRight ;
                pair = lesser.pair ;
                pairValue = lesser.pairValue ;
                greater = lesser.greater ;
                lesser = lesser.lesser ;
                
                return Math.Max( lefChildHeight , rightChildHeight ) + 1 ;
            case < -1 :
                var SwapToLeft = new BST() ; 
                SwapToLeft.add( pair ) ;
                SwapToLeft.lesser = lesser ;
                SwapToLeft.greater = greater.lesser ;
                
                greater.lesser = SwapToLeft ;
                pair = greater.pair ;
                pairValue = greater.pairValue ;
                lesser = greater.lesser ;
                greater = greater.greater ;
                
                return Math.Max( lefChildHeight , rightChildHeight ) + 1 ;
            default :
                return Math.Max( lefChildHeight , rightChildHeight ) + 1 ;
        }
    }
    
    public string GetValueWithKey( string key )
    {
        if (pair == null)
        {
            return null;
        }
        if ( pair.Key == key )
        {
            return pair.Value ;
        }
        var current = CalculateHash( key ) > pairValue ? greater : lesser ;
        if (current == null)
        {
            return null ;
        }
        return current.GetValueWithKey( key ) ;
    }
    
    public int CalculateHash( string key )
    {
        const int prime = 79;
        var result = 0 ;
        foreach ( var elemant in key )
        {
            result = result * prime + elemant ;
        }
        return result ; 
    }
}
