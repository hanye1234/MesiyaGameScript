using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Sprite[] FoodSpriteList;
    public Sprite[] ZairyoSpriteList;
    GameData gameData;
    void Awake()
    {
        gameData = GetComponent<GameData>();
        gameData.ResetGameData();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameData.AddMoney(0);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameData.SyokuzaiList[0].have++;
            gameData.SyokuzaiList[1].have++;
            gameData.SyokuzaiList[2].have++;
            gameData.SyokuzaiList[3].have++;
            gameData.SyokuzaiList[4].have++;
            gameData.SyokuzaiList[5].have++;
            gameData.SyokuzaiList[6].have++;
            gameData.SyokuzaiList[10].have++;
            gameData.SyokuzaiList[7].have++;


        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log(gameData.SyokuzaiList[0].have);
        }
    }
}
