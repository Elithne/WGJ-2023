using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<int> collectedItems = new List<int>();
    float moveSpeed = 3.5f;
    float moveAccuracy = 0.15f;

     public IEnumerator MoveToPoint(Transform myObject, Vector2 point){
        Vector2 positionDifference = point - (Vector2)myObject.position; //Direction
        while(positionDifference.magnitude > moveAccuracy){
            myObject.Translate(moveSpeed*positionDifference.normalized  * Time.deltaTime);
            positionDifference = point - (Vector2)myObject.position;
            yield return null;
        }
        myObject.position = point;
        if(myObject == FindObjectOfType<ClickManager>()){

        }

        if(myObject == FindObjectOfType<ClickManager>().player){
            FindObjectOfType<ClickManager>().playerIsWalking = false;
        }
        yield return null;
    }
}
