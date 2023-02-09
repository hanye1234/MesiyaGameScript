using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save {

    public List<Item> SavedIngredientsList;
    public List<Item> SavedFoodList;
    public List<Item> SavedSkinList;
    public List<Item> SavedFunitureList;
    public Inventory SavedPlayerInventory;
    public PlayInformation SavedPlayInformation;
}