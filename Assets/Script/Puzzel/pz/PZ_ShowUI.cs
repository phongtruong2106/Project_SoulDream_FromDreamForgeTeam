using UnityEngine;

public class PZ_ShowUI : NewMonoBehaviour
{
    public GameObject uiElement;
    protected void Update()
    {
        this.HoverMouse();
    }
    protected virtual void HoverMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        { 
            Collider hoveredCollider = hit.collider;
            PZ_ItemTypeNew pzItemTypeNew = hoveredCollider.GetComponent<PZ_ItemTypeNew>();
            if (hit.transform.CompareTag("PuzzelCheck")) 
            { 
                if (pzItemTypeNew != null)
                {
                    pzItemTypeNew.PZShowUI();
                }
            }
            else
            {
                this.uiElement.SetActive(false);
            }
        }
    }
}