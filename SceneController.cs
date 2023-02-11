using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    GameData gameData;
    public GameObject AlertWindow;
    public void LoadScene(int SceneNumber)
    {
        if(SceneNumber==0)
        {
            SceneManager.LoadScene("Eigyoujunbi");
        }
        else if(SceneNumber==1)
        {
            SceneManager.LoadScene("Eigyou");
        }
        else if(SceneNumber==2)
        {
            SceneManager.LoadScene("Eigyouresult");
        }
        else if(SceneNumber==3)
        {
            SceneManager.LoadScene("YoruScene");
        }
        else if(SceneNumber==4)
        {
            SceneManager.LoadScene("Farm");
        }
        else if(SceneNumber==999)
        {
            gameData.ResetGameData();
            SceneManager.LoadScene("Title");
        }
    }
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool CanIBuyItWithAlertWindow(int M){
        if(gameData.playInformation.Money<M){
            AlertSomething("돈이 부족합니다!");
            return false;
        }
        return true;
    }

    public void AlertSomething(string AlertMessage){
        AlertWindow.SetActive(true);
        TextMeshProUGUI mytext = AlertWindow.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        mytext.text = AlertMessage;
        var textPreferredValues = mytext.GetPreferredValues();
        AlertWindow.transform.GetChild(1).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textPreferredValues[0]+50,200);        
    }

}
