using UnityEngine;

[CreateAssetMenu(menuName = "Project_SoulDream_FromDreamForge/ScriptAbleObject/DataSave")]
public class SO_dataSave : ScriptableObject
{
    [SerializeField]private bool isCheck;

    public bool IsCheck
    {
        get{ return isCheck;}
        set{ isCheck = value;}
    }
}