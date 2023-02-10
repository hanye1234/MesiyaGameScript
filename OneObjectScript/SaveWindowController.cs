using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;
public class SaveWindowController : MonoBehaviour
{
    public TextMeshProUGUI SaveDataDescriptionText;
    public TextMeshProUGUI SaveDataNumText;
    public GameObject SaveButton;
    public GameObject ConfirmButtonObject;
    public GameObject SaveAlertObject;
    GameData gameData;
    SaveScript saveScript;
    string savePath;
    Save TempLoadedData;
    bool IsSaveDataExist = false;
    int CurrentSlotIndex;
    void Awake()
    {
        gameData = GameObject.Find("GameController").gameObject.GetComponent<GameData>();
        saveScript = GameObject.Find("GameController").gameObject.GetComponent<SaveScript>();
        savePath = Application.persistentDataPath + "/gamesave";
    }


    void loadSavedDescription(int loadnum){
        if (File.Exists(savePath+loadnum+".save"))
        {
            TempLoadedData = new Save();
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath+loadnum+".save", FileMode.Open))
            {
                TempLoadedData = (Save)binaryFormatter.Deserialize(fileStream);
            }
            IsSaveDataExist = true;
        }
        else
        {
            Debug.LogWarning("Save file doesn't exist.");
            IsSaveDataExist = false;
        }
        CurrentSlotIndex = loadnum;
    }

    public void ShowSaveDataDescription(int loadnum){
        loadSavedDescription(loadnum);
        SaveDataNumText.text = loadnum.ToString()+"번 세이브 데이터";
        if(IsSaveDataExist){
            SaveDataDescriptionText.text = TempLoadedData.SavedPlayInformation.Day+"일차 \n"
                                            +"소지금 "+TempLoadedData.SavedPlayInformation.Money.ToString()+"원";
        }
        else{
            SaveDataDescriptionText.text = "아직 세이브 되지 않았습니다.";
        }
    }

    public void ConfirmSave(){
        if(IsSaveDataExist){
            ConfirmButtonObject.SetActive(true);
        }else{
            saveScript.SaveData(CurrentSlotIndex);
            SaveAlertObject.SetActive(true);
        }
        
    }

    public void ConfirmLoad(){
        if(IsSaveDataExist){
            saveScript.LoadData(CurrentSlotIndex);
            SaveAlertObject.SetActive(true);
        }else{
            ConfirmButtonObject.SetActive(true);
        }
        
    }

    public void ConfirmSave2(){
        saveScript.SaveData(CurrentSlotIndex);
        SaveAlertObject.SetActive(true);
    }

}
