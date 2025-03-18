using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : NewMonoBehaviour
{
    [SerializeField] private ItemType itemType;
    
    
    public ItemType GetKeyType()
    {
        return itemType;
    }

    public void OpenDoor()
    {
        DoorAnim.instance.OpenDoor();
    }
}
