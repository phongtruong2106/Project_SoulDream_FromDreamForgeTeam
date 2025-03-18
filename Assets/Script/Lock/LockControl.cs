using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : NewMonoBehaviour
{
    [Header("LockControl")]
    private int[] result, correctCombination;
    public bool isOpened;
    [SerializeField] protected Animator animator;
    [SerializeField] protected DataController dataController;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadDataController();
    }
      protected virtual void LoadDataController()
    {
        if(this.dataController != null) return;
        this.dataController = FindAnyObjectByType<DataController>();
    }

    protected virtual void LoadAnimator()
    {
         if(this.animator != null) return;
        this.animator = transform.parent.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadObjectPushDetected()", gameObject);
    }

    protected override void Start()
    {
        result = new int[]{0,0,0,0};
        correctCombination = new int[] {6,7,8,4};
        isOpened = false;
        Rotatee.Rotated += CheckResults;
    }

    private void Update() {
        this.ISOpen();
         this.OpenByData();
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "WheelOne":
                result[0] = number;
                break;

            case "WheelTwo":
                result[1] = number;
                break;

            case "WheelThree":
                result[2] = number;
                break;

            case "WheelFour":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1]
            && result[2] == correctCombination[2] && result[3] == correctCombination[3] && !isOpened)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
            LockManager.Instance.isOpenLock = true;
        }
    }

    private void ISOpen()
    {
        if(LockManager.Instance.isOpenLock)
        {
            animator.SetTrigger("IsOpen");
            LockManager.Instance.isAfterOpenLock = true;
            Invoke("DestroyLock", 1);
        }
    }

    private void OpenByData()
    {
        // if(this.dataController._dataPuzzel.isPuzzelLockBox)
        // {
        //    transform.parent.gameObject.SetActive(false);
        // }
    }

    protected virtual void DestroyLock()
    {
        if(LockManager.Instance.isAfterOpenLock)
        {
            transform.parent.parent.gameObject.SetActive(false);
        } 
    }
    private void OnDestroy()
    {
        Rotatee.Rotated -= CheckResults; // Hủy đăng ký sự kiện để tránh giữ tham chiếu cũ
    }

}
