using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZairyoHyouji : MonoBehaviour
{
    public List<GameObject> ZairyoList;
    public Image ZairyoImage;
    public TextMeshProUGUI ZairyoDescriptionName;
    public TextMeshProUGUI ZairyoDescriptionText;
    GameData gameData;
    List<InventoryItem> CurrentIngredientsList = new List<InventoryItem>();
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }


    void OnEnable()
    {
        CurrentIngredientsList = new List<InventoryItem>();
        foreach(InventoryItem item in gameData.PlayerInventory.Ingredients)
        {
            if(item.have>0)
            {
                CurrentIngredientsList.Add(item);
            }
        }
        Image im;
        TextMeshProUGUI suji;
        for(int i=0; i<CurrentIngredientsList.Count;i++)
        {
            ZairyoList[i].SetActive(true);
            im = ZairyoList[i].transform.Find("Ryori_image").gameObject.GetComponent<Image>();
            im.sprite = gameData.IngredientsList[CurrentIngredientsList[i].id].image;
            suji = ZairyoList[i].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            suji.text = CurrentIngredientsList[i].have.ToString();
        }
    }

    public void ChangeZairyoDescriptionText(int index)
    {
        ZairyoImage.sprite = gameData.IngredientsList[CurrentIngredientsList[index].id].image;
        ZairyoDescriptionName.text=gameData.IngredientsList[CurrentIngredientsList[index].id].name.ToString();
        ZairyoDescriptionText.text=gameData.IngredientsList[CurrentIngredientsList[index].id].description.ToString();
    }
}
