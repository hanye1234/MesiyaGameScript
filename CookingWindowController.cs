using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingWindowController : MonoBehaviour
{
    GameData gameData;
    SceneController scene;
    public List<GameObject> IngredientButtonObject;
    public List<GameObject> InputIngredientButtonObject;
    public List<GameObject> RecipeButtonObject;
    List<Item> CurrentIngredientList;
    List<Item> CurrentRecipeList;
    List<Item> CurrentInputIngredientList;
    List<int> CurrentIngredientHavedCount;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        scene = GameObject.Find("SceneController").gameObject.GetComponent<SceneController>();
    }
    
    void OnEnable()
    {
        CurrentIngredientList = gameData.MakeCurrentAvailableItemList("Ingredient","have");
        MakeCurrentIngredientHavedCount();
        CurrentRecipeList = gameData.MakeCurrentAvailableItemList("Food","equipped");
        CurrentInputIngredientList = new List<Item>();
        gameData.ShowItemsWithCount(IngredientButtonObject,CurrentIngredientList,CurrentIngredientHavedCount);
        gameData.ShowItems(RecipeButtonObject,CurrentRecipeList);
        gameData.ShowItems(InputIngredientButtonObject,CurrentInputIngredientList);
    }

    void MakeCurrentIngredientHavedCount(){
        CurrentIngredientHavedCount = new List<int>();
        foreach(Item temp in CurrentIngredientList){
            CurrentIngredientHavedCount.Add(gameData.PlayerInventory.Ingredients[temp.id].have);
        }

    }

    void ShowWindow(){
        gameData.ShowItemsWithCount(IngredientButtonObject,CurrentIngredientList,CurrentIngredientHavedCount);
        gameData.ShowItems(InputIngredientButtonObject,CurrentInputIngredientList);
    }

    public void InsertIngredient(int PressedButtonIndex){
        if(CurrentInputIngredientList.Count<5){
            CurrentInputIngredientList.Add(CurrentIngredientList[PressedButtonIndex]);
            CurrentIngredientHavedCount[PressedButtonIndex] --;
            if(CurrentIngredientHavedCount[PressedButtonIndex]==0){
                CurrentIngredientList.RemoveAt(PressedButtonIndex);
                CurrentIngredientHavedCount.RemoveAt(PressedButtonIndex);
            }
            ShowWindow();
        }else{
            scene.AlertSomething("넣을 수 있는 재료는 5개까지입니다!");
        }
        
    }

    public void DeleteIngredient(int PressedButtonIndex){
        Item Target = CurrentInputIngredientList[PressedButtonIndex];
        CurrentInputIngredientList.RemoveAt(PressedButtonIndex);
        for(int i = 0;i<CurrentIngredientList.Count;i++){
            if(CurrentIngredientList[i].id == Target.id){
                CurrentIngredientHavedCount[i]++;
                ShowWindow();
                return;
            }
        }
        CurrentIngredientList.Add(Target);
        CurrentIngredientHavedCount.Add(1);
        ShowWindow();
    }

    public void ResetInput(){
        int looptime=CurrentInputIngredientList.Count;
        for(int i=0;i<looptime;i++){
            DeleteIngredient(0);
        }
        
    }

    public void ConfirmCooking(){

    }
}
