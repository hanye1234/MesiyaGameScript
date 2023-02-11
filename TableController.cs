using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject TableObject;
    public void TryTableAction(){
        TableObject.SetActive(true);
    }
}
