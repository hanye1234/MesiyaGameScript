using UnityEngine;

[System.Serializable]
public class Food
{
    public int id {get; set;}
    public string name {get; set;}
    public int cost {get; set;}
    public int have {get; set;}
    public bool available {get; set;}
    public int[] recipe {get; set;}
}
