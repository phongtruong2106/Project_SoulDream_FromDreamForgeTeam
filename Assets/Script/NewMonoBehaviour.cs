using UnityEngine;

public class NewMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Start()
    {
        //for override
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //for override
    }
    protected virtual void ResetValue()
    {
        //for override
    }

    protected virtual void OnEnable()
    {
        //for override
    }
}