using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayInformation
{
    //0 = korean, 1=japanese
    public int Language{get; set;}
    public int Day{get;set;}
    public bool IsEnded{get;set;}
    public int Money{get;set;}
}
