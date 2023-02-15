using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject TableObject;
    public bool IsRequested = true;
    public bool IsActivate = false;
    public bool IsThisAvailable = true;
    
    public void TryTableAction(){
        IsRequested = true;
        if(IsThisAvailable){
            TableObject.SetActive(true);
            IsActivate = true;
        }
        IsRequested = false;
        
    }
}
