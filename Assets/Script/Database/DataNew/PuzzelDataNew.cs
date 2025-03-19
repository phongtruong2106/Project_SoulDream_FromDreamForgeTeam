using UnityEngine;

public class PuzzelDataNew : NewMonoBehaviour
{
    private bool isPuzzelPiano;
    private bool isPuzzelLockBox;
    private bool isWaterGlass;
    private bool isPuzzelPotSteam;
    private bool isPuzzelClock;
    private bool isPuzzelEar;


    public bool IsPuzzelPiano
    {
        get { return isPuzzelPiano; }
        set { isPuzzelPiano = value; }
    }

    public bool IsPuzzelLockBox
    {
        get { return isPuzzelLockBox; }
        set { isPuzzelLockBox = value; }
    }

    public bool IsWaterGlass
    {
        get { return isWaterGlass; }
        set { isWaterGlass = value; }
    }

    public bool IsPuzzelPotSteam
    {
        get { return isPuzzelPotSteam; }
        set { isPuzzelPotSteam = value; }
    }

    public bool IsPuzzelClock
    {
        get { return isPuzzelClock; }
        set { isPuzzelClock = value; }
    }

    public bool IsPuzzelEar
    {
        get { return isPuzzelEar; }
        set { isPuzzelEar = value; }
    }
}
