using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PressHolder : UI
{
    protected override void Start()
    {
        base.Start();
    }   
    protected override void UpdateVisual()
    {
        Transform keyTransform = Instantiate(Template, container);
        TextMeshPro textMesh = keyTransform.Find("Text_Press").GetComponent<TextMeshPro>();
    }
}
