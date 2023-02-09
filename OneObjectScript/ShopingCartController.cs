using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopingCartController : MonoBehaviour
{
    GameData gameData;
    public TextMeshProUGUI ShopCostText;
    public TextMeshProUGUI ExpectedMoneyText;
    public GameObject ShopChang;

    List<Item> ShoppingCartList;
    public List<GameObject> CartObjectList;
    int AddCount = 1;
    // Start is called before the first frame update
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }
    void Start()
    {
        ResetCart();
    }

    void OnEnable()
    {
        ResetCart();
        CartHyouji();
        ShopCostHyouji();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCart(int itemid,int count){
        int looptime = ShoppingCartList.Count;
        if(looptime==0){
            ShoppingCartList.Add(new Item(){id=itemid,have=count});
        }
        for(int i=0;i<looptime;i++){
            if(ShoppingCartList[i].id == itemid){
                ShoppingCartList[i].have = ShoppingCartList[i].have+count;
                if(gameData.IngredientsList[itemid].have+ShoppingCartList[i].have>=99){
                    ShoppingCartList[i].have = 99-gameData.IngredientsList[itemid].have;
                }
                break;
            }else{
                if(i==ShoppingCartList.Count-1 && gameData.IngredientsList[itemid].have<99){
                    ShoppingCartList.Add(new Item(){id=itemid,have=count});
                }
            }
        }
        CartHyouji();
        ShopCostHyouji();
    }

    public void RemoveCart(int index){
        ShoppingCartList[index].have = ShoppingCartList[index].have - AddCount;
        if(ShoppingCartList[index].have<=0){
            ShoppingCartList.RemoveAt(index);
        }
        CartHyouji();
        ShopCostHyouji();
    }


    public void CartHyouji(){
        foreach(GameObject tempitem in CartObjectList){
            tempitem.SetActive(false);
        }
        for(int i=0;i<ShoppingCartList.Count;i++){
            CartObjectList[i].SetActive(true);
            CartObjectList[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.IngredientsList[ShoppingCartList[i].id].image;
            CartObjectList[i].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ShoppingCartList[i].have.ToString();
        }
    }

    public void ShopCostHyouji(){
        if(ShoppingCartList.Count==0){
            ShopCostText.text = (0).ToString();
            ExpectedMoneyText.text = gameData.playInformation.Money.ToString();
        }else{
            int ExpectedCost = CalculateShopCost();
            ShopCostText.text = ExpectedCost.ToString();
            if(gameData.playInformation.Money - ExpectedCost<0){
                ExpectedMoneyText.color = new Color32(255,0,0,255);
            }else{
                ExpectedMoneyText.color = new Color32(0,0,0,255);
            }
            ExpectedMoneyText.text = (gameData.playInformation.Money - ExpectedCost).ToString();
        }
        
    }

    public void ResetCart(){
        ShoppingCartList = new List<Item>();
    }

    public void SetAddCount(int c){
        AddCount = c;
    }

    public int CalculateShopCost(){
        int sum = 0;
        foreach(Item tempitem in ShoppingCartList){
            sum = sum + gameData.IngredientsList[tempitem.id].cost*tempitem.have;
        }
        return sum;
    }

    public void BuyConfirm(){
        if(gameData.playInformation.Money-CalculateShopCost()>=0){
            gameData.AddMoney(-CalculateShopCost());
            foreach(Item tempitem in ShoppingCartList){
                gameData.AddIngredients(tempitem.id,tempitem.have);
            }
            ResetCart();
            ShopChang.SetActive(false);
        }
        else{
            Debug.Log("돈이 부족합니다.");
        }

    }
}
