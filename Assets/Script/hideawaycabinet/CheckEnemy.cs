using UnityEngine;

public class CheckEnemy : NewMonoBehaviour
{
    public bool isCheckEnemy = false;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("checkEnemy"))
        {
            isCheckEnemy = true;
        }
    }
}