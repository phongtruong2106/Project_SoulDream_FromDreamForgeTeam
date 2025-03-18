using System.Collections.Generic;
using UnityEngine;

public class PZ_BookCaseController : NewMonoBehaviour
{
    [SerializeField] protected List<Light> lightsList;
    public List<Light> _lightlist => lightsList;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLights();
    }

    private void LoadLights()
    {
        if (this.lightsList != null && this.lightsList.Count > 0) return;         
        this.lightsList = new List<Light>(gameObject.GetComponentsInChildren<Light>());

    }
}