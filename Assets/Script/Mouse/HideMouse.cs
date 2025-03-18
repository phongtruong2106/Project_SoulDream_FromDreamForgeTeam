using UnityEngine;

public class HideMouse : NewMonoBehaviour
{
    public bool isHide = false;

    private void Update()
    {
        this.CanHideMouse();
        this.CanUnHideMouse();
    }

    protected virtual void CanHideMouse()
    {
        if(!isHide)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    protected virtual void CanUnHideMouse()
    {
        if(isHide)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}