using UnityEngine;

public class PianoController : NewMonoBehaviour
{
    protected NotificationPiano nofiticationPiano;
    public NotificationPiano _notificationPiano => nofiticationPiano;
    [SerializeField] protected InputPiano inputPiano;
    public InputPiano _inputPiano => inputPiano;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNotificationPiano();
        this.LoadInputPiano();
    }

    protected virtual void LoadNotificationPiano()
    {
        if(this.nofiticationPiano != null) return;
        this.nofiticationPiano = GetComponentInChildren<NotificationPiano>();
    }

    protected virtual void LoadInputPiano()
    {
        if(this.inputPiano != null) return;
        this.inputPiano = FindAnyObjectByType<InputPiano>();
    }


    
}