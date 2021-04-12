public static class GlobalVarStore
{
    //Points currently does nothing
    //To add a new global variable:
    // >> Add to the list of varaibles below
    // >> Add a new mini class with getters and setters
    //Refer to these objects globally using --GlobalVarStore.Variablename--
    private static int points, coins, projDamage;
    private static float nextTeleTime, attackDelay;
    private static bool defaultPurchased, firePurchased, icePurchased, lightningPurchased;
    private static string equipped;

    //Global Delays
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

    public static float AttackDelay
    {
        get
        {
            return attackDelay;
        }
        set
        {
            attackDelay = value;
        }
    }

    //Coins and score
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


    //Purchased Shop Items
    public static bool DefaultPurchased
    {
        get
        {
            return defaultPurchased;
        }
        set
        {
            defaultPurchased = value;
        }
    }

    public static bool FirePurchased
    {
        get
        {
            return firePurchased;
        }
        set
        {
            firePurchased = value;
        }
    }

    public static bool IcePurchased
    {
        get
        {
            return icePurchased;
        }
        set
        {
            icePurchased = value;
        }
    }

    public static bool LightningPurchased
    {
        get
        {
            return lightningPurchased;
        }
        set
        {
            firePurchased = value;
        }
    }

    //Equipped stats
    public static string Equipped
    {
        get
        {
            return equipped;
        }
        set
        {
            equipped = value;
        }
    }

    //Projectile Damge
    public static int ProjDamage
    {
        get
        {
            return projDamage;
        }
        set
        {
            projDamage = value;
        }
    }
}
