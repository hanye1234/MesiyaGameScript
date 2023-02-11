using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadyToBusinessWindowController : MonoBehaviour
{
    GameData gameData;
    SceneController scene;
    public List<GameObject> RecipeButtonObjectList;
    public List<GameObject> EquippedRecipeButtonObjectList;
    List<Item> CurrentAvailableFoodList;
    List<Item> CurrentEquippedFoodList;
    List<int> CurrentFoodCountList;
    int EquippedRecipeCount;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        scene = GameObject.Find("SceneController").gameObject.GetComponent<SceneController>();
    }
    void OnEnable()
    {
        CurrentAvailableFoodList = gameData.MakeCurrentAvailableItemList("Food","available");
        CurrentEquippedFoodList = gameData.MakeCurrentAvailableItemList("Food","equip");
        EquippedRecipeCount = CurrentEquippedFoodList.Count;
        MakeFoodCountList();
        gameData.ShowItemsWithCount(RecipeButtonObjectList,CurrentAvailableFoodList,CurrentFoodCountList);
        gameData.ShowItems(EquippedRecipeButtonObjectList,CurrentEquippedFoodList);

    }


    void MakeFoodCountList(){
        CurrentFoodCountList = new List<int>();
        foreach(Item temp in CurrentAvailableFoodList){
            CurrentFoodCountList.Add(CalculateAvailableFoodCount(temp.recipe));
        }
    }

    int CalculateAvailableFoodCount(int[] Recipe){
        int Minvalue = 99999;
        for(int i=0;i<Recipe.Length;i++){
            int TargetValue = gameData.PlayerInventory.Ingredients[Recipe[i]].have;
            if(TargetValue<Minvalue){
                Minvalue = TargetValue;
            }
        }
        return Minvalue;
    }

    public void EquipRecipe(int PressedButtonIndex){
        bool IsEquipped = CurrentEquippedFoodList.Contains(CurrentAvailableFoodList[PressedButtonIndex]);
        if(IsEquipped){
            CurrentEquippedFoodList.Remove(CurrentAvailableFoodList[PressedButtonIndex]);
            EquippedRecipeCount --;
        }else{
            if(EquippedRecipeCount<5){
            CurrentEquippedFoodList.Add(CurrentAvailableFoodList[PressedButtonIndex]);
            EquippedRecipeCount ++;
            }else{
                scene.AlertSomething("가게에 낼 수 있는 레시피는 최대 5개까지입니다.");
                return;
            }
        }
        gameData.ShowItems(EquippedRecipeButtonObjectList,CurrentEquippedFoodList);
    }

    public void UnEquipRecipe(int PressedButtonIndex){
        if(CurrentEquippedFoodList.Count>=PressedButtonIndex){
            CurrentEquippedFoodList.RemoveAt(PressedButtonIndex);
            EquippedRecipeCount--;
            gameData.ShowItems(EquippedRecipeButtonObjectList,CurrentEquippedFoodList);
        }
    }

    public void ConfirmButtonPressed(){
        if(IsAvailableStartBusiness() == false){
            return;
        }

        foreach(InventoryItem temp in gameData.PlayerInventory.Foods){
            temp.equipped = false;
        }

        foreach(Item temp in CurrentEquippedFoodList){
            gameData.PlayerInventory.Foods[temp.id].equipped = true;
        }
        scene.LoadScene(1);

    }

    bool IsAvailableStartBusiness(){
        if(CurrentEquippedFoodList.Count<1){
            scene.AlertSomething("최소 하나 이상의 레시피를 골라주세요!");
            return false;
        }
        return true;
    }
}
