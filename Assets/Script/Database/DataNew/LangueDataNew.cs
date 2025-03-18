using UnityEngine;

public class LangueDataNew : NewMonoBehaviour
{
    private bool IsVN;
    private bool IsEN;

    public bool isVN
    {
        get{ return IsVN;}
        set{ IsVN = value;}
    }
    public bool isEN
    {
        get{return IsEN;}
        set{IsEN = value;}
    }
}