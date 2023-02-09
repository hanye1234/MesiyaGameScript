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
    List<Item> CurrentIngredientsList = new List<Item>();
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        CurrentIngredientsList = new List<Item>();
        foreach(Item item in gameData.IngredientsList)
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
            suji.text = gameData.IngredientsList[CurrentIngredientsList[i].id].have.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeZairyoDescriptionText(int index)
    {
        ZairyoImage.sprite = gameData.IngredientsList[CurrentIngredientsList[index].id].image;
        ZairyoDescriptionName.text=gameData.IngredientsList[CurrentIngredientsList[index].id].name.ToString();
        ZairyoDescriptionText.text=gameData.IngredientsList[CurrentIngredientsList[index].id].description.ToString();
    }
}
