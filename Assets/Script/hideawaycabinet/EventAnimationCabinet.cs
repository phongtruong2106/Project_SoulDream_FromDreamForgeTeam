using UnityEngine;

public class EventAnimationCabinet : NewMonoBehaviour
{
    public bool isOpenCabinet;

    protected override void Start()
    {
        base.Start();
        this.isOpenCabinet = false;
    }

    public virtual void EventIsOpenCabinet()
    {
        this.isOpenCabinet = true;
    }

    public virtual void EventIsCloseCabinet()
    {
        this.isOpenCabinet = false;
    }
}