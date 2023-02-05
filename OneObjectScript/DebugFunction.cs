using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFunction : MonoBehaviour
{

    GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }

    public void MoneyCheat()
    {
        gameData.playInformation.Money=99999;
    }

    public void SyokuzaiCheat()
    {
        for(int i=0;i<gameData.SyokuzaiList.Count;i++){
            gameData.SyokuzaiList[i].have =999;
        }
        
    }
}
