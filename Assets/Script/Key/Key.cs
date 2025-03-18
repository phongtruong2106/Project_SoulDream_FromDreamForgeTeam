using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : NewMonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
            door,
            able,
            box
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
