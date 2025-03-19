using UnityEngine;
using UnityEngine.AI;

public class Enemy : NewMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected PlayerControler playerControler;
    
    protected virtual void Update()
    {
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
        this.LoadPlayerController();
    }

    protected virtual void LoadEnemyController()
    {
        if(this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController()", gameObject);
    }
     protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }
}