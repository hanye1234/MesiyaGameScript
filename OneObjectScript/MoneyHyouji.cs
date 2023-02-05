using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyHyouji : MonoBehaviour
{
    GameData gameData;
    TextMeshProUGUI moneytext;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        moneytext = gameObject.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        moneytext.text = gameData.playInformation.Money.ToString();
    }
}
