using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveScript : MonoBehaviour {

    private GameData gameData;
    private GameController gameController;
    private string savePath;

	void Start () 
	{
        gameData = GetComponent<GameData>();
        gameController = GetComponent<GameController>();
        savePath = Application.persistentDataPath + "/gamesave";
	}
	
	public void SaveData(int savenum)
    {
        var save = new Save()
        {
            SavedSyokuzaiList = gameData.SyokuzaiList,
            SavedFoodList = gameData.FoodList,
            SavedSkinList = gameData.SkinList,
            SavedPlayInformation = gameData.playInformation,
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath+savenum+".save"))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved");
    }

    public void LoadData(int loadnum)
    {
        if (File.Exists(savePath+loadnum+".save"))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath+loadnum+".save", FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            gameData.SyokuzaiList = save.SavedSyokuzaiList;
            gameData.SkinList = save.SavedSkinList;
            gameData.FoodList = save.SavedFoodList;
            gameData.playInformation = save.SavedPlayInformation;

            Debug.Log("Data Loaded");
            Debug.Log(savePath);
        }
        else
        {
            Debug.LogWarning("Save file doesn't exist.");
        }
    }
}