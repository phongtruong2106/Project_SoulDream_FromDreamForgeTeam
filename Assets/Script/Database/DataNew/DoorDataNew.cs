using UnityEngine;

public class DoorDataNew : NewMonoBehaviour
{
    private bool Door1;
    private bool Door2;

    public bool IsDoor1
    {
        get{ return Door1;}
        set{ Door1 = value;}
    }
    public bool IsDoor2
    {
        get{return Door2;}
        set{Door2 = value;}
    }
}