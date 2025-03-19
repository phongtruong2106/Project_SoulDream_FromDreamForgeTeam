using UnityEngine;

public class LockManager : NewMonoBehaviour
{
    public static LockManager Instance { get; private set; }

    public bool isOpenLock = false;
    public bool isAfterOpenLock = false;
    public bool isPickKey = false;

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}