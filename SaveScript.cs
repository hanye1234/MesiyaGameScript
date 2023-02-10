using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveScript : MonoBehaviour {

    private GameData gameData;
    private string savePath;

	void Start () 
	{
        gameData = GetComponent<GameData>();
        savePath = Application.persistentDataPath + "/gamesave";
	}
	
	public void SaveData(int savenum)
    {
        var save = new Save()
        {
            SavedPlayerInventory = gameData.PlayerInventory,
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

            gameData.PlayerInventory = save.SavedPlayerInventory;
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