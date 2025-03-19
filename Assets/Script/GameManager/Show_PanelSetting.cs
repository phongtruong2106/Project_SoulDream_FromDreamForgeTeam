using UnityEngine;

public class Show_PanelSetting : NewMonoBehaviour
{
    public void ShowPanel(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void HidePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}