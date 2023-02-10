using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
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
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log(gameData.IngredientsList[0].have);
        }
    }
}
