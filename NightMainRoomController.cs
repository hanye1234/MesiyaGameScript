using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightMainRoomController : MonoBehaviour
{
    public List<GameObject> FunitureAreaObjectList;
    public List<GameObject> CharacterObjectList;
    GameData gameData;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }
    void OnEnable()
    {
        foreach(GameObject temp in FunitureAreaObjectList){
            temp.SetActive(false);
        }
        foreach(InventoryItem temp in gameData.PlayerInventory.Funitures){
            if(temp.equipped){
                GameObject Target = FunitureAreaObjectList[gameData.ItemPropertyStringToInt(gameData.FunitureList[temp.id].property)];
                Target.SetActive(true);
                Target.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.FunitureList[temp.id].image;
                Target.transform.GetChild(0).gameObject.GetComponent<Image>().SetNativeSize();
            }
        }
        
    }

}
