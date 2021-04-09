public static class GlobalVarStore
{
    //Points currently does nothing
    //To add a new global variable:
    // >> Add to the list of varaibles below
    // >> Add a new mini class with getters and setters
    //Refer to these objects globally using --GlobalVarStore.Variablename--
    private static int points, teles, coins;
    private static float nextTeleTime;

    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public static float NextTeleTime
    {
        get
        {
            return nextTeleTime;
        }
        set
        {
            nextTeleTime = value;
        }
    }

    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }


    //Teles is currently used for testing purposes, 
    //The value can be seen the debug log when pressing space
    //The value can be set by using the teleporters in level1
    public static int Teles
    {
        get
        {
            return teles;
        }
        set
        {
            teles = value;
        }
    }
}
