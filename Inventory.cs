using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<InventoryItem> Indegredients {get;set;}
    public List<InventoryItem> Foods {get;set;}
    public List<InventoryItem> Skins {get; set;}
    public List<InventoryItem> Funitures {get; set;}
}
