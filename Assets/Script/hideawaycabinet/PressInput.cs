using UnityEngine;

public class PressInput : NewMonoBehaviour
{
    [SerializeField] protected hideawayCabinetController hideawayCabinetController;
    [SerializeField] protected GameObject ObjectCheckPlayerInSite;   
    [SerializeField] protected PlayerControler playerControler;   
    [SerializeField] private GameObject objectCheckOpenCabinet;
    [SerializeField] private GameObject objectCheckCloseCabinet;
    [SerializeField] private GameObject objectCheckInSiteOpenCabinet;
    [SerializeField] private GameObject objectCheckInSiteCloseCabinet;
    
    protected bool isCanPress;
 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadhideawayCabinetController();
        this.LoadPlayerController();
    }

    protected override void Start()
    {
        base.Start();
        this.objectCheckCloseCabinet.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.InputCloseCabinet();
        this.InputOpenCabinet();
        this.InputCloseInSiteCabinet();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerControler != null) return;
        this.playerControler = FindAnyObjectByType<PlayerControler>();
        Debug.Log(transform.name + ": LoadUIController()", gameObject);
    }
    protected virtual void LoadhideawayCabinetController()
    {
        if(this.hideawayCabinetController != null) return;
        this.hideawayCabinetController = transform.parent.GetComponent<hideawayCabinetController>();
        Debug.Log(transform.name + ": LoadhideawayCabinetController()", gameObject);
    }
    protected virtual void InputOpenCabinet()
    {
        if(this.hideawayCabinetController._checkPlayer.IsPlayer && !this.hideawayCabinetController._eventAnimationCabinet.isOpenCabinet)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.OpenCabinet();
                this.objectCheckCloseCabinet.gameObject.SetActive(true);
                this.objectCheckOpenCabinet.gameObject.SetActive(false);
                this.objectCheckInSiteCloseCabinet.gameObject.SetActive(true);
                this.objectCheckInSiteOpenCabinet.gameObject.SetActive(false);
            }
        }
    }
    protected virtual void InputCloseCabinet()
    {
        if(this.hideawayCabinetController._checkPlayer.IsPlayer && this.hideawayCabinetController._eventAnimationCabinet.isOpenCabinet)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.CloseCabinet();
                this.objectCheckCloseCabinet.gameObject.SetActive(false);
                this.objectCheckOpenCabinet.gameObject.SetActive(true);
                this.objectCheckInSiteCloseCabinet.gameObject.SetActive(false);
                this.objectCheckInSiteOpenCabinet.gameObject.SetActive(true);
            }
        }
    }

    protected virtual void InputCloseInSiteCabinet()
    {
        if(this.hideawayCabinetController._checkPlayerInSite.IsPlayer && this.hideawayCabinetController._eventAnimationCabinet.isOpenCabinet)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.CloseCabinet();
                this.objectCheckCloseCabinet.gameObject.SetActive(false);
                this.objectCheckOpenCabinet.gameObject.SetActive(true);
                this.objectCheckInSiteCloseCabinet.gameObject.SetActive(false);
                this.objectCheckInSiteOpenCabinet.gameObject.SetActive(true);
            }
        }
    }

    protected virtual void CloseCabinet()
    {
        hideawayCabinetController._animator.SetBool("CLose", true);
        hideawayCabinetController._animator.SetBool("Open", false);
    }

    protected virtual void OpenCabinet()
    {
        hideawayCabinetController._animator.SetBool("Open", true);
        hideawayCabinetController._animator.SetBool("CLose", false);
    }
}