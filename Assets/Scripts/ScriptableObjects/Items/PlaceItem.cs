using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Mine/Items/PlaceItem", order = 0)]
public class PlaceItem : Item
{
    [Header("PlaceItem")]
    public GameObject Prefab;
}
