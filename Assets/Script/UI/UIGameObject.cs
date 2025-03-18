using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameObject : NewMonoBehaviour
{
    [SerializeField] protected GameObject uI_PressButtonObj;
    public GameObject UI_PressButtonObj => uI_PressButtonObj;
    [SerializeField] protected GameObject ui_ObjPress;
    public GameObject UI_ObjPress => ui_ObjPress;
    [SerializeField] protected GameObject uI_PressExit;
    public GameObject UI_PressExit => ui_ObjPress;
    [SerializeField] protected GameObject uI_PressButtonObj_Item;
    public GameObject UI_PressButtonObj_Item => uI_PressButtonObj_Item;
}
