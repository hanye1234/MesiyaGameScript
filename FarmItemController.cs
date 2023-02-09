using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmItemController : MonoBehaviour
{
    GameData gameData;
    public GameObject AlertChang;
    TextMeshProUGUI AlertMessageText;

    List<Item> CurrentHatakeIngredientsList = new List<Item>();
    public List<GameObject> HatakeGameObjectList;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }
    
    void OnEnable()
    {
        foreach(GameObject temp in HatakeGameObjectList){
            temp.SetActive(false);
        }
        ShowHatake();
    }


    public void GenerateIngredients(int index){
        if(CurrentHatakeIngredientsList.Count<HatakeGameObjectList.Count){
            CurrentHatakeIngredientsList.Add(new Item(){id=index,have=1});
        }
        
    }

    public void ShowHatake(){
        for(int i =0 ; i<CurrentHatakeIngredientsList.Count;i++){
            HatakeGameObjectList[i].SetActive(true);
            HatakeGameObjectList[i].GetComponent<SpriteRenderer>().sprite = gameData.IngredientsList[CurrentHatakeIngredientsList[i].id].image;
            HatakeGameObjectList[i].GetComponent<HatakeItemController>().item_id = CurrentHatakeIngredientsList[i].id;
            HatakeGameObjectList[i].GetComponent<HatakeItemController>().item_count = CurrentHatakeIngredientsList[i].have;
        }
    }
}
