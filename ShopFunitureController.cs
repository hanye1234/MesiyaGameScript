using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopFunitureController : MonoBehaviour
{
    GameData gameData;
    public List<GameObject> ShopObject;
    List<Item> CurrentShopItems;
    public TextMeshProUGUI FunitureDescriptionText;
    public TextMeshProUGUI FunitureCostText;
    int itemid = 999;
    void Awake()
    {
        CurrentShopItems  = new List<Item>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        for (int i=0;i<gameData.FunitureList.Count;i++){
            CurrentShopItems.Add(new Item(){id=i});
        }
        ShowShopFuniture();
    }

    void OnEnable()
    {
        ShowShopFuniture();
    }

    public void ShowShopFuniture(){
        foreach(GameObject tempitem in ShopObject){
            tempitem.SetActive(false);
        }
        for(int i=0;i<CurrentShopItems.Count;i++){
            ShopObject[i].SetActive(true);
            ShopObject[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.FunitureList[CurrentShopItems[i].id].image;            
        }
    }

    public void ShowCurrentFunitureDescription(int itemindex)
    {
        itemid = CurrentShopItems[itemindex].id;
        FunitureDescriptionText.text= gameData.FunitureList[itemid].description;
        FunitureCostText.text = gameData.FunitureList[itemid].cost.ToString();
    }

    public void BuyConfirm(){
        if(itemid==999){
            return;
        }
        if(gameData.PlayerInventory.Funitures[itemid].available){
            Debug.Log("이미 갖고 있는 가구입니다");
        }
        else if(gameData.CanIBuyItWithAlertWindow(gameData.FunitureList[itemid].cost)==false){
            Debug.Log("돈이 모자랍니다");
        }
        else{
            gameData.AddMoney(-gameData.FunitureList[itemid].cost);
            gameData.PlayerInventory.Funitures[itemid].available=true;
        }
        
    }

}
