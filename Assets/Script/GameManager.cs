using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static List<int> collectedItems = new List<int>();
    float moveSpeed = 3.5f;
    float moveAccuracy = 0.15f;
    public RectTransform nameTag, hintBox;

     public IEnumerator MoveToPoint(Transform myObject, Vector2 point){
        //Calculate position difference
        Vector2 positionDifference = point - (Vector2)myObject.position; 
        //stop when we are nar that point
        while(positionDifference.magnitude > moveAccuracy){
            //move in direction frame
            myObject.Translate(moveSpeed*positionDifference.normalized  * Time.deltaTime);
            //recalculate position difference
            positionDifference = point - (Vector2)myObject.position;
            yield return null;
        }
        //snap to point
        myObject.position = point;
        if(myObject == FindObjectOfType<ClickManager>().player){
            FindObjectOfType<ClickManager>().playerIsWalking = false;
        }
        yield return null;
    }

    public void UpdateNameTag(ItemData item){
        nameTag.GetComponentInChildren<TextMeshProUGUI>().text = item.itemName;
        nameTag.sizeDelta = item.nameTagSize;
        nameTag.localPosition = new Vector2(item.nameTagSize.x/2, -.05f);
    }

    public void UpdateHintBox(ItemData item, bool isPlayerFlipped){
        if(item == null){
            hintBox.gameObject.SetActive(false);
            return;
        }
        
        hintBox.gameObject.SetActive(true);
        //change name
        hintBox.GetComponentInChildren<TextMeshProUGUI>().text = item.hintMessage;
        //change size
        hintBox.sizeDelta = item.hintBoxSize;
        //move tag
        if(isPlayerFlipped){
            hintBox.parent.localPosition = new Vector2(-1,0);
        }else{
            hintBox.parent.localPosition = Vector2.zero;
        }
    }
}
