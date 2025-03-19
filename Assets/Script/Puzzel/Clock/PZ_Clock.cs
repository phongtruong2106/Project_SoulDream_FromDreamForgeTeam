using UnityEngine;

public class PZ_Clock : NewMonoBehaviour
{
    [SerializeField] protected Transform minuteHand, hourHand;
    private bool previousClockState = false;
    public bool isClock = false;
    public Animator animator;
    private bool CanClock;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimation();
    }
    protected override void Start()
    {
        base.Start();
        this.CanClock = true;
    }
    protected virtual void LoadAnimation()
    {
        if(this.animator != null) return;
        this.animator = gameObject.GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        this.CompletedClock();
    }
    protected virtual void OnMouseDown()
    {
        minuteHand.Rotate(Vector3.forward, 30);
        hourHand.Rotate(Vector3.forward, 2.5f);
    }

    protected virtual void CompletedClock()
    {

        float minuteAngle = Mathf.Round(minuteHand.rotation.eulerAngles.z * 2) / 2;
        float hourAngle = Mathf.Round(hourHand.rotation.eulerAngles.z * 2) / 2;
        bool isTargetTime = Mathf.Approximately(minuteAngle, 329.5f) && Mathf.Approximately(hourAngle, 177f);
        if (isTargetTime != previousClockState)
        {
            this.CanClock = isTargetTime;
            previousClockState = isTargetTime;
            if (this.CanClock)
            {
                this.isClock = true;
            }
            else
            {
                this.isClock = false;
            }
        }
        
    }
}