using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HatakeItemController : MonoBehaviour
{
    
    GameData gameData;
    GameController gameController;
    public GameObject AlertChang;
    TextMeshProUGUI AlertMessageText;
    public int item_id;
    public int item_count;
    void Awake()
    {
        AlertMessageText = AlertChang.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        gameController = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
    }

    void OnDisable()
    {
        AlertChang.SetActive(true);
        AlertMessageText.text = gameData.IngredientsList[item_id].name+"를"+item_count+"개 얻었다!";
        gameData.AddIngredients(item_id,item_count);
    }
}
