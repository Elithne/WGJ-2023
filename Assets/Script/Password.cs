using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    //[SerializeField] private TMP_Text answer;
    [SerializeField] private TMP_Text UiText = null;
    string code ="2451";
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
        gameObject.SetActive(false);
    }
}
