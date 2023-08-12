using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public int itemID, requiredItemID;
    public Transform goToPoint;
    public GameObject[] itemsToRemove;
    public string itemName;
    public Vector2 nameTagSize = new Vector2(3,0.65f);
    [TextArea(3,3)]
    public string hintMessage;
    public Vector2 hintBoxSize = new Vector2(4,0.65f);
}
