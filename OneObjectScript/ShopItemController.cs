using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemController : MonoBehaviour
{
    GameData gameData;
    GameController gameController;
    public ShopingCartController shopingCartController;
    
    public List<GameObject> ShopObject;
    List<Item> CurrentShopItems;
    int AddCount = 1;
    void Awake()
    {
        CurrentShopItems  = new List<Item>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        gameController = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
        for (int i=0;i<10;i++){
            CurrentShopItems.Add(new Item(){id=i});
        }
        ShopItemHyouji();
    }

    void OnEnable()
    {
        ShopItemHyouji();
    }

    public void ShopItemHyouji(){
        foreach(GameObject tempitem in ShopObject){
            tempitem.SetActive(false);
        }
        for(int i=0;i<CurrentShopItems.Count;i++){
            ShopObject[i].SetActive(true);
            ShopObject[i].transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.IngredientsList[CurrentShopItems[i].id].image;
            ShopObject[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = gameData.IngredientsList[CurrentShopItems[i].id].cost.ToString();
        }
    }

    public void AddShopItemToCart(int index){
        shopingCartController.AddCart(CurrentShopItems[index].id,AddCount);
    }

    public void SetAddCount(int c){
        AddCount = c;
    }
}
