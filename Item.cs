using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id {get; set;}
    public string name {get; set;}
    public int cost {get; set;}
    public int have {get; set;}
    public bool available {get; set;}
    public int[] recipe {get; set;}
    public string description {get; set;}
    public Sprite image {get; set;}
    public string jname {get; set;}
    public string kname {get; set;}
    public string kdescription{get; set;}
    public string jdescription{get; set;}
    public string property {get; set;}
}
