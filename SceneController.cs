using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    GameData gameData;
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

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }

}
