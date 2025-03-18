using UnityEngine;

public abstract class UI : NewMonoBehaviour
{
    [Header("UI")]
    [SerializeField] protected KeyHolder keyHolder;
    protected Transform container;
    protected Transform Template;

    protected override void Awake()
    {
        base.Awake();
        container = transform.Find("container");
        Template = container.Find("Template");
        // keyTemplate.gameObject.SetActive(false);
    }

    protected abstract void UpdateVisual();
}