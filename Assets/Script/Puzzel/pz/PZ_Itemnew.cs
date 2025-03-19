using UnityEngine;

public class PZ_Itemnew : MonoBehaviour
{
  [SerializeField] private ItemType itemType;

    public enum ItemType
    {
            burn_paper,
            water,
            ear
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}