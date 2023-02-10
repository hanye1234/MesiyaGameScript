using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaController : MonoBehaviour
{
    GameData gameData;
    public GameObject GachaResult;
    public List<GameObject> GachaCardObjectList;
    public GameObject GachaEndButton;
    public GameObject GachaConfirm;
    public GameObject GachaConfirm10;
    List<Image> GachaCardObjectSpriteList;
    List<GachaCardController> CardControllerList;
    List<Item> CurrentGachaResult = new List<Item>();
    public int FlippedCardCount = 0;
    void Awake() {

        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        GachaCardObjectSpriteList = new List<Image>();
        CardControllerList = new List<GachaCardController>();
        foreach(GameObject temp in GachaCardObjectList){
            GachaCardObjectSpriteList.Add(temp.GetComponent<Image>());
            CardControllerList.Add(temp.GetComponent<GachaCardController>());
        }
    }
    

    public void IsGachaAvailable(int M){
        if(gameData.CanIBuyItWithAlertWindow(M)){
            GachaConfirm.SetActive(false);
            GachaConfirm10.SetActive(false);
            gameData.AddMoney(-M);
            GachaResult.SetActive(true);
            GachaCardsCreate(M/1000);
            CreateGachaResultList(M/1000);
        }
    }

    void GachaCardsCreate(int CardCount){
        FlippedCardCount = 0;
        if(CardCount==1){
            GachaResult.transform.GetChild(1).gameObject.SetActive(true);
            GachaCardObjectList[0].SetActive(true);
        }else{
            GachaResult.transform.GetChild(2).gameObject.SetActive(true);
            for(int i=1;i<CardCount+1;i++){
                GachaCardObjectList[i].SetActive(true);
            }
        }
    }

    void CreateGachaResultList(int CardCount){
        CurrentGachaResult = new List<Item>();
        if(CardCount>1){
            for(int i=1;i<CardCount+1;i++){
                Item tempitem = RandomGachaFromItemList();
                CurrentGachaResult.Add(tempitem);
                CardControllerList[i].ResultItem = tempitem;
            }
        }
        else{
            Item tempitem = RandomGachaFromItemList();
            CurrentGachaResult.Add(tempitem);
            CardControllerList[0].ResultItem = tempitem;
        }
      
    }

    Item RandomGachaFromItemList(){
        return gameData.IngredientsList[Random.Range(0,gameData.IngredientsList.Count)];
    }

    public void GachaEnd(){
        foreach(Item temp in CurrentGachaResult){
            gameData.AddItem(temp);
        }

        foreach(GameObject temp in GachaCardObjectList){
            temp.SetActive(false);
        }
        GachaResult.SetActive(false);
        
        
    }

    void Update()
    {
        if(FlippedCardCount==CurrentGachaResult.Count){
            GachaEndButton.SetActive(true);
        }else{
            GachaEndButton.SetActive(false);
        }
    }
}
