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
    [Header("Setup")]
    public RectTransform nameTag, hintBox;
    
    [Header("Local Scene")]
    public Image blockingImage;
    public GameObject[] localScenes;
    int activeLocalScene = 0;
    public Transform[] playerStartPositions;

     public IEnumerator MoveToPoint(Transform myObject, Vector2 point){
        // if(GetComponentInChildren<SpriteRenderer>() &&  positionDifference.x != 0){
        //     GetComponentInChildren<SpriteRenderer>().flipX = ositionDifference.x > 0;
        // }
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

    public void CheckSpecialCondition(ItemData item){
        switch(item.itemID){
            case -11:
                //go to scene 2
                StartCoroutine(ChangeScene(1,0));
                Debug.Log("Escene Expresionista");
                break;
            case -12:
                //go to scene 1
                StartCoroutine(ChangeScene(0,1));
                Debug.Log("Escene Cubista");
                break;
            case -1:
                //win the game (With the Actual GameManager)
                break;
        }
    }
    public IEnumerator ChangeScene(int sceneNumber, float delay){
        
        Color c = blockingImage.color;
        blockingImage.enabled = true;
        while(blockingImage.color.a<1){
            //increase alpha
            c.a+=Time.deltaTime;
            blockingImage.color = c;
        }

        //hide the old one
        localScenes[activeLocalScene].SetActive(false);
        //show the new one
        localScenes[sceneNumber].SetActive(true);
        //save which one is currently used
        activeLocalScene = sceneNumber;
        //teleport the player
        FindObjectOfType<ClickManager>().player.position = playerStartPositions[sceneNumber].position;
        UpdateHintBox(null,false);

        while(blockingImage.color.a>0){
            //decrease alpha
            c.a-=Time.deltaTime;
            blockingImage.color = c;
        }
        blockingImage.enabled = false;
        yield return null;
    }
}
