using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySkinController : MonoBehaviour
{
    GameData gameData;
    public List<GameObject> SkinScrollObjectList;
    public List<GameObject> AkinaSkinObjectList;
    public List<GameObject> MayuSkinObjectList;
    public List<GameObject> FuwaSkinObjectList;
    List<GameObject> CurrentShowObjectList;
    List<Item> CurrentSkinList;
    
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }

    void OnEnable()
    {
        SwitchScroll(0);
    }
    public void SwitchScroll(int index){
        
        for(int i=0;i<SkinScrollObjectList.Count;i++){
            if(i==index){
                SkinScrollObjectList[i].SetActive(true);
                if(i==0){CurrentShowObjectList=AkinaSkinObjectList;}else if(i==1){CurrentShowObjectList=MayuSkinObjectList;}else if(i==2){CurrentShowObjectList=FuwaSkinObjectList;}
                ShowSkins(i);
            }else{
                SkinScrollObjectList[i].SetActive(false);
            }
        }
    }

    void ShowSkins(int index){
        for(int i=0;i<CurrentShowObjectList.Count;i++){
            CurrentShowObjectList[i].SetActive(false);
        }
        CurrentSkinList = new List<Item>();
        foreach(InventoryItem tempitem in gameData.PlayerInventory.Skins){
            if(tempitem.available && SkinToIndexByProperty(gameData.SkinList[tempitem.id])==index){
                CurrentSkinList.Add(gameData.SkinList[tempitem.id]);
            }
        }
        for(int i=0;i<CurrentSkinList.Count;i++){
            CurrentShowObjectList[i].SetActive(true);
            CurrentShowObjectList[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = CurrentSkinList[i].image;
        }
    }

    int SkinToIndexByProperty(Item skin){
        if(skin.property.Contains("Akina")){
            return 0;
        }else if(skin.property.Contains("Mayu")){
            return 1;
        }else if(skin.property.Contains("Fuwa")){
            return 2;
        }
        return -1;
        
    }
}
