using UnityEngine;

public class Dataprogress : NewMonoBehaviour
{   
    [SerializeField] protected GameObject ObjCheckPlayer;
    public bool isPlayer = false;

    protected void Update()
    {
        this.CheckPlayer();
    }

    protected virtual void CheckPlayer()
    {
        if(this.isPlayer)
        {
            this.ObjCheckPlayer.SetActive(false); 
        }
    }

    
}