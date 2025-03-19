using UnityEngine;

public class DataIsLoaded : NewMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    public PlayerControler _playerControler => playerControler;
    
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }
}