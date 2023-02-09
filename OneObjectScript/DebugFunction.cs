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

    public void ItemCheat()
    {
        for(int i=0;i<gameData.IngredientsList.Count;i++){
            gameData.IngredientsList[i].have =999;
        }
        
    }
}
