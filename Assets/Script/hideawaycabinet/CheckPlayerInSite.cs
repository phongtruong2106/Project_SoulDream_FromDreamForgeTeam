using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPlayerInSite : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;
    [SerializeField] protected string textBox;
    [SerializeField] protected UIController uIController;
    [SerializeField] protected bool isPlayer  = false;
    public bool IsPlayer => isPlayer;
    [SerializeField] protected GameObject objcheckEnemy;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected CheckEnemy  checkEnemy;
    [SerializeField] protected CheckEnemySitDown checkEnemySitDown;
    [SerializeField] protected bool isFlSitDown = false;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void Start()
    {
        if(this.objcheckEnemy != null)
        {
            this.objcheckEnemy.gameObject.SetActive(false);
        }
            
    }   
    protected void Update()
    {
        this.HideCheckEnemy();
        this.UnHideCheckEnemy();
        this.ChangeBoolSitDown();
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIController();
        this.LoadhideawayCabinetController();
        this.LoadPlayerController();
        this.LoadCheckEnemySitDown();
    }

    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
    }

    protected virtual void LoadhideawayCabinetController()
    {
        if(this.hideawayCabinetController != null) return;
        this.hideawayCabinetController = transform.parent.GetComponent<hideawayCabinetController>();
    }
    protected virtual void LoadUIController()
    {
        if(this.uIController != null) return;
        this.uIController = FindAnyObjectByType<UIController>();
    }
    protected virtual void LoadCheckEnemySitDown()
    {
        if(this.checkEnemySitDown != null) return;
        this.checkEnemySitDown = FindAnyObjectByType<CheckEnemySitDown>();
    }
     protected virtual void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) 
        {
            uIController._uIGameObject.UI_PressButtonObj.gameObject.SetActive(true);
            uIController._uI_PressButton._text_ObjPress.text = textBox;
            this.Following();
            if(objcheckEnemy != null)
            {
                this.objcheckEnemy.gameObject.SetActive(true);
            }
            
            this.isPlayer = true;
            this.playerControler._objectCrouch.isPlayerInSite = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
           checkEnemy.isCheckEnemy = false;
           this.isPlayer = false;
           this.playerControler._objectCrouch.isPlayerInSite = false;
        }
    }
    protected virtual void ChangeBoolSitDown()
    {
        if(checkEnemySitDown.isStop)
        {
            StartCoroutine(WaitAndSitDown());
        }
    }

    private IEnumerator WaitAndSitDown()
    {
        yield return new WaitForSeconds(10f);
        this.isFlSitDown = true;
    }
    protected virtual void UnHideCheckEnemy()
    {
        if(checkEnemy.isCheckEnemy && this.isPlayer)
        {
            this.objcheckEnemy.gameObject.SetActive(true);
            this.isFlSitDown = false;
        }
    }

    protected virtual void HideCheckEnemy()
    {
        if(this.isFlSitDown && !this.isPlayer) 
        {
            if(this.objcheckEnemy != null)
            {
                 this.objcheckEnemy.gameObject.SetActive(false);
            }
           
            
        }
    }
    protected virtual void Following()
    {
        if(this.target == null) return;
        this.uIController._uIGameObject.UI_PressButtonObj.transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }

}