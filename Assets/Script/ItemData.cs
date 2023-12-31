using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    [Header("Setup")]
    public int itemID, requiredItemID;
    public Transform goToPoint;
    public string itemName;
    public Vector2 nameTagSize = new Vector2(3,0.65f);

    [Header("Success")]
    public GameObject[] itemsToRemove;

    [Header("Failure")]
    [TextArea(5,5)]
    public string hintMessage;
    public Vector2 hintBoxSize = new Vector2(4,0.65f);
}
