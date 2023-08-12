using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public bool playerIsWalking;
    public Transform player;
    GameManager gameManager;

    private void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GoToItem(ItemData item){
        //update HintBox
        gameManager.UpdateHintBox(null, false);
        //Start Moving Player
        StartCoroutine(gameManager.MoveToPoint(player,item.goToPoint.position));
        //Start Walking
        playerIsWalking = true;
        //Equip Something
        TryGettingItem(item);

    }

    public void TryGettingItem(ItemData item){
        bool canGetItem = item.requiredItemID == -1 || GameManager.collectedItems.Contains(item.requiredItemID);
        if(canGetItem){         
            GameManager.collectedItems.Add(item.itemID);            
        }
        StartCoroutine(UpdateSceneAfterAction(item, canGetItem));
    }

    private IEnumerator UpdateSceneAfterAction(ItemData item, bool canGetItem){
        while(playerIsWalking){
            yield return new WaitForSeconds(0.05f);
        }
        if(canGetItem){
            foreach(GameObject g in item.itemsToRemove){
                Destroy(g);
            }
            Debug.Log("Collected");
        } else {
            gameManager.UpdateHintBox(item, player.GetComponentInChildren<SpriteRenderer>().flipX);
        }
        yield return null;
    }
}
