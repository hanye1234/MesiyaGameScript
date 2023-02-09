using System.ComponentModel.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class InventoryFuniture : MonoBehaviour
{
    GameData gameData;
    public List<GameObject> FunitureArrangementArea;
    public List<GameObject> FunitureInventoryObject;
    List<InventoryItem> CurrentFunitureList;
    List<bool> TempFunitureEquippedList;
    List<int> AreaToEquippedFuniture = new List<int>();
    int SelectedItemId;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }

    void OnEnable()
    {
        TempFunitureEquippedList=new List<bool>();
        foreach(InventoryItem temp in gameData.PlayerInventory.Funitures){
            TempFunitureEquippedList.Add(temp.equipped);
        }
        MakeCurrentFunitureList();
        MakeAreaToEquippedFuniture();
        ShowFunitureInventory();
        ShowFunitureArrangementArea();
        
    }
    
    void ShowFunitureInventory(){
        foreach(GameObject temp in FunitureInventoryObject){
            temp.SetActive(false);
        }
        for(int i=0;i<CurrentFunitureList.Count;i++){
            FunitureInventoryObject[i].SetActive(true);
            FunitureInventoryObject[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.FunitureList[CurrentFunitureList[i].id].image;
        }
        
    }

    void ShowFunitureArrangementArea(){
        foreach(GameObject temp in FunitureArrangementArea){
            temp.SetActive(false);
        }

        for(int i=0;i<AreaToEquippedFuniture.Count;i++){
            int TargetId = AreaToEquippedFuniture[i];
            if(TargetId>=0){
                FunitureArrangementArea[i].SetActive(true);
                FunitureArrangementArea[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameData.FunitureList[TargetId].image;
                FunitureArrangementArea[i].transform.GetChild(0).gameObject.GetComponent<Image>().SetNativeSize();
                }
            }
    }

    void MakeCurrentFunitureList(){
        CurrentFunitureList = new List<InventoryItem>();
        foreach(InventoryItem temp in gameData.PlayerInventory.Funitures){
            if(temp.available){
                CurrentFunitureList.Add(temp);
            }
        }
    }
    
    void MakeAreaToEquippedFuniture(){
        AreaToEquippedFuniture = new List<int>();

        for(int i=0;i<FunitureArrangementArea.Count;i++){
            AreaToEquippedFuniture.Add(-1);
        }
        for(int i=0;i<CurrentFunitureList.Count;i++){
            SelectedItemId = CurrentFunitureList[i].id;
            if(TempFunitureEquippedList[SelectedItemId]){
                int TargetAreaNum = gameData.ItemPropertyStringToInt(gameData.FunitureList[SelectedItemId].property);
                AreaToEquippedFuniture[TargetAreaNum]=SelectedItemId;
            }
        }
    }

    public void ArrangeFuniture(int itemindex){

        SelectedItemId = CurrentFunitureList[itemindex].id;
        if(AreaToEquippedFuniture.Contains(SelectedItemId)){
            AreaToEquippedFuniture[AreaToEquippedFuniture.IndexOf(SelectedItemId)]=-1;
            TempFunitureEquippedList[SelectedItemId] = false;
        }else{
            int TargetAreaNum = gameData.ItemPropertyStringToInt(gameData.FunitureList[SelectedItemId].property);
            if(AreaToEquippedFuniture[TargetAreaNum]!=-1){
                TempFunitureEquippedList[AreaToEquippedFuniture[TargetAreaNum]]=false;
            }
            AreaToEquippedFuniture[TargetAreaNum] = SelectedItemId;
            TempFunitureEquippedList[SelectedItemId] = true;
            
        }
        ShowFunitureArrangementArea();
    }

    public void ConfirmFunitureChange(){
        for(int i = 0;i<TempFunitureEquippedList.Count;i++){
            gameData.PlayerInventory.Funitures[i].equipped = TempFunitureEquippedList[i];
        }
    }

    
}
