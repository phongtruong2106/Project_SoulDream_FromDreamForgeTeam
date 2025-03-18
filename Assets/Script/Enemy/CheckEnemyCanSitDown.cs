using Unity.VisualScripting;
using UnityEngine;

public class CheckEnemyCanSitDown : NewMonoBehaviour
{
    public bool isCanShowObjCheckEnemyShitDown;
    [SerializeField] private CheckEnemySitDown objCheckEnemySitDown;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjCheckEnemySitDown();
    }
    private void LoadObjCheckEnemySitDown()
    {
        if(this.objCheckEnemySitDown != null) return;
        this.objCheckEnemySitDown = gameObject.GetComponentInChildren<CheckEnemySitDown>();
    }
    private void ShowObjCheckEnemySitDown()
    {
        if(!this.isCanShowObjCheckEnemyShitDown)
        {
            if(this.objCheckEnemySitDown == null)
            {
                objCheckEnemySitDown.gameObject.SetActive(true);
            }
            
            Debug.Log("Oídnnd");
            this.isCanShowObjCheckEnemyShitDown = true;
        }
    }

    private void HideObjectCheckEnemySitDown()
    {
        this.isCanShowObjCheckEnemyShitDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            this.ShowObjCheckEnemySitDown();
        }
    }
    private void OnTriggerExit(Collider other)
    {
         if(other.gameObject.tag == "Enemy")
        {
            this.HideObjectCheckEnemySitDown();
        }
    }
}