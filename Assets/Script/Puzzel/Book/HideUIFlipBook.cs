using UnityEngine;

public class HideUIFlipBook : BookController
{
     [SerializeField] protected  GameObject UIFlipPage;

    protected override void Start()
    {
        UIFlipPage.gameObject.SetActive(false);
    }

    private void Update()
    {
        this.ClickBook();
        this.IsHideUI();
    }


    protected virtual void HideUI()
    {
        if(UIFlipPage != null)
        {
            UIFlipPage.gameObject.SetActive(true);
        }
    }

    protected virtual void Unhide()
    {
         if(UIFlipPage != null)
        {
            UIFlipPage.gameObject.SetActive(false);
        }
    }
    protected virtual void IsHideUI()
    {
        if(!object_Interact.IsClickObj)
        {
            this.Unhide();
        }
    }
    protected virtual void ClickBook()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Book"))
                {
                    HideUI();
                }
            }
        }
    }
}