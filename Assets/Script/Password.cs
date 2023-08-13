using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    //[SerializeField] private TMP_Text answer;
    [SerializeField] private TMP_Text UiText = null;
    [SerializeField] private GameObject destroyedItem;
    [SerializeField] private GameObject destroyedImage;
    [SerializeField] private GameObject activatedItem;
    string code ="2541";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    GameManager gameManager;
    

    public void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Number(string Numbers){
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter(){
        if(Nr == code){
            UiText.text = "Success!";
            activatedItem.gameObject.SetActive(true);
            Destroy(destroyedItem.gameObject);
            Destroy(destroyedImage.gameObject);
            Destroy(gameObject);
            
            
        } else{
            UiText.text = "Error!";
        }
    }

    public void Delete(){
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
        Debug.Log(Nr);
    }

    public void Close(){
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
