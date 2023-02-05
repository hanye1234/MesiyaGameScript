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
    GameController gameController;
    List<Syokuzai> CurrentSyokuzaiList = new List<Syokuzai>();
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        gameController = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        CurrentSyokuzaiList = new List<Syokuzai>();
        foreach(Syokuzai item in gameData.SyokuzaiList)
        {
            if(item.have>0)
            {
                CurrentSyokuzaiList.Add(item);
            }
        }
        Image im;
        TextMeshProUGUI suji;
        for(int i=0; i<CurrentSyokuzaiList.Count;i++)
        {
            ZairyoList[i].SetActive(true);
            im = ZairyoList[i].transform.Find("Ryori_image").gameObject.GetComponent<Image>();
            im.sprite = gameController.ZairyoSpriteList[CurrentSyokuzaiList[i].id];
            suji = ZairyoList[i].transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            suji.text = gameData.SyokuzaiList[CurrentSyokuzaiList[i].id].have.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeZairyoDescriptionText(int index)
    {
        ZairyoImage.sprite = gameController.ZairyoSpriteList[CurrentSyokuzaiList[index].id];
        ZairyoDescriptionName.text=gameData.SyokuzaiList[CurrentSyokuzaiList[index].id].name.ToString();
        ZairyoDescriptionText.text=gameData.SyokuzaiList[CurrentSyokuzaiList[index].id].description.ToString();
    }
}
