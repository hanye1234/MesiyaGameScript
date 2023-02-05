using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmItemController : MonoBehaviour
{
    GameData gameData;
    GameController gameController;
    public GameObject AlertChang;
    TextMeshProUGUI AlertMessageText;

    List<Syokuzai> CurrentHatakeSyokuzaiList = new List<Syokuzai>();
    public List<GameObject> HatakeGameObjectList;
    void Awake()
    {
        gameController = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
    }
    
    void OnEnable()
    {
        foreach(GameObject temp in HatakeGameObjectList){
            temp.SetActive(false);
        }
        HatakeHyouji();
    }


    public void GenerateSyokuzai(int index){
        if(CurrentHatakeSyokuzaiList.Count<HatakeGameObjectList.Count){
            CurrentHatakeSyokuzaiList.Add(new Syokuzai(){id=index,have=1});
        }
        
    }

    public void HatakeHyouji(){
        for(int i =0 ; i<CurrentHatakeSyokuzaiList.Count;i++){
            HatakeGameObjectList[i].SetActive(true);
            HatakeGameObjectList[i].GetComponent<SpriteRenderer>().sprite = gameController.ZairyoSpriteList[CurrentHatakeSyokuzaiList[i].id];
            HatakeGameObjectList[i].GetComponent<HatakeItemController>().item_id = CurrentHatakeSyokuzaiList[i].id;
            HatakeGameObjectList[i].GetComponent<HatakeItemController>().item_count = CurrentHatakeSyokuzaiList[i].have;
        }
    }
}
